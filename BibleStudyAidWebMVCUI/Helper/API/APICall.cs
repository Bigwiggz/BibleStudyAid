using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BibleStudyAidWebMVCUI.Helper.API
{
    public class APICall
    {
        private readonly IAPIHelper _apiHelper;

        public APICall(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /*
        //Call to Get everything
        public async Task<T> GetAllAsync(string endpoint)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync<Task>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //Call to
        public async Task<T> GetAsync(string endpoint, Object sentContent)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(sentContent), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(endpoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        */
    }
}
