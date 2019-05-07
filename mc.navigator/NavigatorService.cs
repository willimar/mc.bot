using mc.navigator.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace mc.navigator
{ 
    public class NavigatorService : INavigator
    {
        private HttpClient httpClient = new HttpClient();

        public Method RequestMethod { get; set; }
        public HttpHeaders Headers => httpClient.DefaultRequestHeaders;

        public int TimeOut { get; set; } = 5000;
        public Dictionary<string, string> Form { get; set; }

        public NavigatorService()
        {
            this.Form = new Dictionary<string, string>();
        }

        public string Navigate(Uri uri, Method method)
        {
            HttpResponseMessage responseMessage = null;
            switch (RequestMethod)
            {
                case Method.get:
                    var get = this.httpClient.GetAsync(uri);
                    get.Wait(this.TimeOut);
                    responseMessage = get.Result;
                    break;
                case Method.post:
                    var form = new FormUrlEncodedContent(this.Form);
                    var post = this.httpClient.PostAsync(uri, form);
                    post.Wait(this.TimeOut);
                    responseMessage = post.Result;
                    break;
            }

            string response = responseMessage?.Content.ReadAsStringAsync().Result;
            
            return response;
        }
    }
}
