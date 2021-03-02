using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BibleStudyAidWebMVCUI.Helper.API
{
    public class APIHelper : IAPIHelper
    {
        private readonly IConfiguration _config;

        public HttpClient _apiClient { get; set; }
        public APIHelper(IConfiguration config)
        {
            _config = config;
        }

        private void InitializeClient()
        {
            string apiBaseUrl = _config.GetValue<string>("BibleWebAPIConfig", "ApplicationURL");
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(apiBaseUrl);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient ApiClient
        {
            get { return _apiClient; }
        }


    }
}
