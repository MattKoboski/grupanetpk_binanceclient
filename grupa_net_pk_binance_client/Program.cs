using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa_net_pk_binance_client
{
    //Binance API docs
    //https://github.com/binance-exchange/binance-official-api-docs
    //github proj
    //https://github.com/MattKoboski/grupanetpk_binanceclient
    //konto do założenia na https://www.binance.com/
    class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.ReadKey();
        }
        static void Start()
        {
            var binanceService = new BinanceService();
            var getAccountTask = binanceService.GetAccount();
            Task.WaitAll(getAccountTask);
            var account = getAccountTask.Result;
            Console.WriteLine(account);

            var getLTCprice = binanceService.GetPrice("LTCBTC");
            Task.WaitAll(getLTCprice);
            var prices = getLTCprice.Result;
            var bestPrice = prices.bids[0][0];
            var quantity = prices.bids[0][1];
            var totalPrice = (double)bestPrice * (double)quantity;
            Console.WriteLine(bestPrice);
            Console.WriteLine(quantity);
            Console.WriteLine(totalPrice);

            var buyLtcWithBtc = binanceService.Buy("LTCBTC", 2);
            Task.WaitAll(buyLtcWithBtc);
            var result = buyLtcWithBtc.Result;
            Console.WriteLine(result);

        }
    }
}
