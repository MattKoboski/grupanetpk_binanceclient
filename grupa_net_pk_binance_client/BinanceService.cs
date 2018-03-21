using grupa_net_pk_binance_client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa_net_pk_binance_client
{
    public class BinanceService : IBinanceService
    {
        private readonly IBinanceClient _client;
        public BinanceService()
        {
            _client = new BinanceClient();
        }
        public async Task<dynamic> GetAccount()
        {
            var timestamp = TimeOperations.GetTimeStampUnixInMilliseconds();
            var urlData = $"timestamp={timestamp}";
            var signature = _client.GenerateSignature(urlData);
            var endpoint = $"/api/v3/account?{urlData}&signature={signature}";
            var result = await _client.GetRequest<dynamic>(endpoint);
            return result;
        }
        public async Task<dynamic> GetPrice(string symbol)
        {
            var urlData = $"symbol={symbol}&limit=5";
            var endpoint = $"api/v1/depth?{urlData}";
            var result = await _client.GetRequest<dynamic>(endpoint);
            return result;
        }
        public async Task<dynamic> Buy(string symbol, double quantity)
        {
            var timestamp = TimeOperations.GetTimeStampUnixInMilliseconds();
            var side = "buy";
            var type = "market";
            var data = new { symbol, side, type, quantity, timestamp };
            var urlData = data.ToQueryString();
            var signature = _client.GenerateSignature(data.ToQueryString());
            var endpoint = $"api/v3/order?{urlData}&signature={signature}";
            var result = await _client.PostRequest<dynamic>(endpoint, null);
            return result;
        }
    }
    public interface IBinanceService
    {
        Task<dynamic> GetAccount();
        Task<dynamic> GetPrice(string symbol);
        Task<dynamic> Buy(string symbol, double quantity);
    }
}
