using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa_net_pk_binance_client
{
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
            Task.WaitAll(getAccountTask);
            var account = getAccountTask.Result;
            Console.WriteLine(account.balances[0]);

        }
    }
}
