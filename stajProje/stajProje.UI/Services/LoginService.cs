using Microsoft.AspNetCore.Http;
using stajProje.UI.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace stajProje.UI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccesor;
      
       
        public LoginService(IHttpContextAccessor contextAccesor)
        {
          
            _contextAccesor = contextAccesor;
        }



        public string GetUserId=> _contextAccesor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;



       
    }
}
