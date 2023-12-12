
using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Helpers;


namespace WebApp.RealStateApp.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse userViewModels = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (userViewModels == null)
            {
                return false;
            }
            return true;
        }
    }
}
