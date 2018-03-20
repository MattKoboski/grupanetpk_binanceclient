using grupa_net_pk_binance_client.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace grupa_net_pk_binance_client
{
    public class BinanceClient : IBinanceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://api.binance.com";
        public BinanceClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiUrl)
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", BinanceConfiguration.ApiKey);
        }

        public async Task<T> PostRequest<T>(string endpoint, object data)
        {
            var payload = StringOperations.GetPayload(data);
            var response = await _httpClient.PostAsync(endpoint, payload);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<T> GetRequest<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public string GenerateSignature(string data)
        {
            var shaHmac256 = new HMACSHA256(Encoding.UTF8.GetBytes(BinanceConfiguration.ApiSecret));
            var hash = shaHmac256.ComputeHash(Encoding.UTF8.GetBytes(data));
            var hashedString = BitConverter.ToString(hash).Replace("-", string.Empty);
            return hashedString;
        }

    }

    public interface IBinanceClient
    {
    }
}
