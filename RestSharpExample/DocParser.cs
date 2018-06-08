using HtmlAgilityPack;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestSharpExample
{
    public class DocParser
    {

        public Information GetStackInfo(string content)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            var htmlNodeContents = ParserHtmlNodeContnet(doc);
            if (htmlNodeContents.Count == 0)
                return null;
            return GetStackBasicInfo(htmlNodeContents);
        }

        private List<HtmlNode[]> ParserHtmlNodeContnet(HtmlDocument dom)
        {
            return dom.DocumentNode.Descendants()
                .Where(x => (x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("idx-quotes")))
                .Select(d => d.Elements("div").ToArray())
            .ToList();
        }

        private Information GetStackBasicInfo(List<HtmlNode[]> nodes)
        {
            if (nodes.Count < 0)
                return null;
            var node = nodes[0];
            var basic = GetStockBasicStatus(node[0]);
            var total = GetStockTotalStatus(node[1]);
            return new Information() { Basic = basic, Total = total };
        }

        private static TotalStatus GetStockTotalStatus(HtmlNode node)
        {
            var ul = node.Element("ul");
            var ts =  ul.Elements("li").ToArray();//.ToArray();
            var sOpen = ts[0].InnerText.Replace("\r\n", "").Trim();
            var sHigh = ts[1].InnerText.Replace("\r\n", "").Trim();
            var sLow = ts[2].InnerText.Replace("\r\n", "").Trim();
            var sLast = ts[3].InnerText.Replace("\r\n", "").Trim();
            var sVolume = ts[4].InnerText.Replace("\r\n", "").Trim();
            var sValue = ts[5].InnerText.Replace("\r\n", "").Trim();
            var sRatio = ts[6].InnerText.Replace("\r\n", "").Trim();
            var sP_E_Ratio = ts[7].InnerText.Replace("\r\n", "").Trim();
            var sPartial_Ratio = ts[8].InnerText.Replace("\r\n", "").Trim();
            var sPrice_Fraction = ts[9].InnerText.Replace("\r\n", "").Trim();
            var sIssue_Warrants = ts[10].InnerText.Replace("\r\n", "").Trim();
            var sSeasonAvg = ts[11].InnerText.Replace("\r\n", "").Trim();
            return new TotalStatus() {
                Open = sOpen, High = sHigh, Low = sLow, Last = sLast,
                Volume = sVolume, Value = sValue,
                Ratio = sRatio, P_E_Ratio = sP_E_Ratio, Partial_Rratio = sPartial_Ratio,
                Price_Fraction = sPrice_Fraction, Issue_Warrants = sIssue_Warrants, SeasonAvage = sSeasonAvg
            };
        }

        private static BasicStatus GetStockBasicStatus(HtmlNode node)
        {
            var es = node.Elements("span").ToArray();
            var sPrice = es[0].InnerText.Replace("\r\n", "").Trim();
            var sChange = es[1].InnerText.Replace("\r\n", "").Trim();
            var sChangeRate = es[2].InnerText.Replace("\r\n", "").Trim();
            return new BasicStatus() {
                Price = sPrice, Change = sChange, ChangeRate = sChangeRate
            };
        }
    }
}
