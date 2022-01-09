
namespace BibleStudyAidMVC.Services.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string emailTo, string subject, string htmlMessage);
    }
}