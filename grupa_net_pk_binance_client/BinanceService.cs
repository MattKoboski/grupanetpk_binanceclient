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
        private readonly BinanceClient _client;
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
    }

    public interface IBinanceService
    {
    }
}
