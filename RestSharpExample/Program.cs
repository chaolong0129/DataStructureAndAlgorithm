using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestSharpExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var stocks_list_url = "http://isin.twse.com.tw/isin/C_public.jsp?strMode=2";

            var snolist = StocksList.GetStocksList(stocks_list_url);

            foreach (var sno in snolist) {

                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var time = (long)(DateTime.UtcNow - epoch).TotalMilliseconds;
                var url = $"https://www.wantgoo.com/stock/{sno}";
                var ncService = new NetworkCommunicationService(url, sno, time);
                ncService.ExecuteGetAsync();
                if (!WaitToResponseData(ncService))
                    continue;
                SaveToFiles(time, ncService);
                if (string.Compare(sno, "9958", StringComparison.Ordinal) == 0)
                    break;
            }
        }

        private static void SaveToFiles(long time, NetworkCommunicationService ncService)
        {
            var filename = ncService.StockInfo.Num + ".txt";
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var json = ToJsonFormat(ncService.StockInfo, time) + Environment.NewLine;
                var bjson = Encoding.UTF8.GetBytes(json);
                fs.Seek(0, SeekOrigin.End);
                fs.WriteAsync(bjson, 0, bjson.Length).Wait();
                fs.Close();
            }
        }

        private static bool WaitToResponseData(NetworkCommunicationService client)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (!client.IsSuccess)
            {
                var elapsed = sw.ElapsedMilliseconds;
                if (elapsed > 3000) break;
                continue;
            }
            sw.Stop();
            return (client.StockInfo == null) ? false : true;
        }

        private static string ToJsonFormat(Stock stock, long time)
        {
            stock.time = time;
            var json = JsonConvert.SerializeObject(stock);
            return json;
        }
    }
}
