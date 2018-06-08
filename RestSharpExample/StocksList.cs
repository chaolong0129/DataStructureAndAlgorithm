using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using RestSharp;

namespace RestSharpExample
{
    public class StocksList
    {
        public static List<string> GetStocksList(string url)
        {
            var Client = new RestClient()
            {
                BaseUrl = new Uri(url),
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36"
            };
            var request = new RestRequest();
            var response = Client.Execute(request);
            return ToParseStocksListContent(response.Content);
        }

        private static List<string> ToParseStocksListContent(string content)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            return doc.DocumentNode
                .Descendants("tr").Skip(2)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").First().InnerText.Substring(0, 4))
                .ToList();
        }
    }
}
