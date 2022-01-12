using BibleStudyAidMVC.ViewModels;

namespace BibleStudyAidMVC.Services.HttpServices
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpRequestService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<BibleTextAPIViewModel> GetBibleVersesText(string bibleCitation)
        {

            var client = _clientFactory.CreateClient("BibleTextAPI");
            var result = await client.GetFromJsonAsync<BibleTextAPIViewModel>(bibleCitation);
            return result;

        }
    }
}
