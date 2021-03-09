using BibleStudyBWAUI.ViewModels;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticatedUserModel> Login(AuthenticationUserModel userForAuthentication);
        Task LogOut();
    }
}