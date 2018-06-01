using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0;
            var client = new NetworkCommunicationService("https://tw.stock.yahoo.com/q/q?s=2317");
            while (cnt < 2)
            {
                client.ExecuteGetAsync();
                cnt++;
            }
            while (!client.IsSuccess)
            {
                if (client.StockInfo == null)
                    continue;
                foreach (var stock in client.StockInfo.ToArray())
                {
                    Console.WriteLine(stock);
                }
                break;
            }
            Console.ReadLine();
        }
    }
}
