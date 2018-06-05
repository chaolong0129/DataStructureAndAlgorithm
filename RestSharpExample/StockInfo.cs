using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpExample
{
    public class Information
    {
        public BasicStatus Basic { get; set; }
        public TotalStatus Total { get; set; }
    }

    public class BasicStatus
    {
        public string Price { get; set; }
        public string Change { get; set; }
        public string ChangeRate { get; set; }
        public override string ToString()
        {
            return $"\"股價\":\"{Price}\", \"漲跌\":\"{Change}\", \"漲跌百分比\":\"{ChangeRate}\"";
        }
    }

    public class TotalStatus
    {
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Last { get; set; }
        public string Volume { get; set; }
        public string Value { get; set; }
        public string Ratio { get; set; }
        public string P_E_Ratio { get; set; }
        public string Partial_Rratio { get; set; }
        public string Price_Fraction { get; set; }
        public string Issue_Warrants { get; set; }
        public string SeasonAvage { get; set; }
    }
}
