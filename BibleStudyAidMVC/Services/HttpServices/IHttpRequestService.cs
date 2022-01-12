using BibleStudyAidMVC.ViewModels;

namespace BibleStudyAidMVC.Services.HttpServices
{
    public interface IHttpRequestService
    {
        Task<BibleTextAPIViewModel> GetBibleVersesText(string bibleCitation);
    }
}