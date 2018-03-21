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
        }
    }
}
