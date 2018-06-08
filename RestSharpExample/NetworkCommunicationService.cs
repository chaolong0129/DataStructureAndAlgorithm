using System;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace RestSharpExample
{
    class NetworkCommunicationService
    {
        private IRestClient Client;
        private IRestRequest request;
        private Stock stock;
        private string Sno;
        private long Time;
        public Stock StockInfo {
            get { return stock ?? null; }
        }

        public bool IsSuccess { get; private set; }

        public NetworkCommunicationService(string url, string stockNo, long time)
        {
            this.Client = new RestClient()
            {
                BaseUrl = new Uri(url),
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36"
            };
        
            request = new RestRequest();
            Sno = stockNo;
            Time = time;
        }

        public void SetUrl(string url)
        {
            Console.WriteLine(url);
            this.Client.BaseUrl = new Uri(url);
            IsSuccess = false;
        }

        private void HttpGetResponse(IRestResponse resp, RestRequestAsyncHandle handle)
        {
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                DocParser doc = new DocParser();
                var sinfo = doc.GetStackInfo(resp.Content);
                if (sinfo != null)
                {
                    stock = new Stock() { Num = Sno, Info = sinfo };
                    IsSuccess = true;
                }
            }
            handle.Abort();
        }

        public void ExecuteGetAsync()
        {
            if (Client == null)
                return;
            request = new RestRequest();
            request.Method = Method.GET;
            ExecuteGetAsync(request).Wait();
        }

        private async Task ExecuteGetAsync(IRestRequest req)
        {
            if (Client == null)
                return;
            await Task.Delay(1);
            Client.ExecuteAsyncGet(req, HttpGetResponse, "Get");
        }
    }
}
