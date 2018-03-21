using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa_net_pk_binance_client
{
    //https://github.com/binance-exchange/binance-official-api-docs
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Naciśnij ESC by zatrzymać wykonywanie programu");
            //do
            //{
            //    while (!Console.KeyAvailable)
            //    {
            //        Start();
            //    }
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Start();
            Console.ReadKey();
        }
        static void Start()
        {
            var binanceService = new BinanceService();
            var getAccountTask = binanceService.GetAccount();
            //Task.WaitAll(getAccountTask);
            //var account = getAccountTask.Result;
            //if (account.updateTime != null)
            //    Console.WriteLine(account.updateTime * 2);
            //Console.WriteLine(account);

            //var getPricingTask = binanceService.GetPrice("LTCBTC");
            //Task.WaitAll(getPricingTask);
            //var prices = getPricingTask.Result;
            //Console.WriteLine(prices);

            var buyLTCwithBTC = binanceService.Buy("LTCBTC", 1);
            Task.WaitAll(buyLTCwithBTC);
            var buyResult = buyLTCwithBTC.Result;
            Console.WriteLine(buyResult);
        }
    }
}
