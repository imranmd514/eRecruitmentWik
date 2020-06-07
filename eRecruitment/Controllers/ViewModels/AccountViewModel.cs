using eRecruitment.Security;
using Models;
namespace eRecruitment.Controllers.ViewModels
{
    public class AccountViewModel
    {
        public ErrorDisplay ErrorDisplay = null;
        public UserBO busUser = null;
        public AppUserState AppUserState = null;
    }
}