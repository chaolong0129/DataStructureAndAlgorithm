using System;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using System.Collections.Generic;

namespace RestSharpExample
{
    class NetworkCommunicationService
    {
        private IRestClient Client;
        private IRestRequest request;
        private List<string> Stock;
        public List<string> StockInfo {
            get { return (Stock.Count !=0 ) ? Stock : null; }
        }

        public bool IsSuccess { get; private set; }

        public NetworkCommunicationService(string url)
        {
            this.Client = new RestClient(url);
            request = new RestRequest();
            Stock = new List<string>();
        }

        private void HttpGetResponse(IRestResponse resp, RestRequestAsyncHandle handle)
        {
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Stock.Add(resp.Content);
                IsSuccess = true;
            }
                
            handle.Abort();
        }

        public void ExecuteGetAsync()
        {
            if (Client == null)
                return;
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
