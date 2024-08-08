using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using stajProje.UI.Models;
using System.Text.Json;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using stajProje.UI.Services;
using NuGet.Common;
using Microsoft.AspNetCore.Http;

namespace stajProje.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _contextAccesor;
        private readonly HttpClient _client;
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService, IHttpContextAccessor contextAccesor)
        {
        _client = HttpClientInstance.CreateClient();
            _loginService = loginService;
            _contextAccesor = contextAccesor;
        }
    
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Users/login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JWTResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
                    );
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("blogtoken", tokenModel.Token));
                        var claimsidentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authProps);
                        var userRole = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                        if (userRole == "User")
                        {
                            return RedirectToAction("Index", "Home", new { area = "user" });
                        }
                        else if (userRole == "Author")
                        {
                            return RedirectToAction("Index", "Home", new { area = "author" });
                        }
                        else return RedirectToAction("Index", "Home", new { area = "admin" });




                    }
                }

            }
            return View();
        }

        }
    }
