using System.Net.Http;

namespace BibleStudyAidWebMVCUI.Helper.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
    }
}