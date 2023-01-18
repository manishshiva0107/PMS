using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PMS.AuthenticateService;
using PMS.Core.Entities.User;
using PMS.Core.Services.User;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMS.Controllers.UserAdmin
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            UserDetails userDetails = new UserDetails();
            

            return View("~/Views/Home/UserLogin.cshtml", userDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDetails userDetails)
        {
            userDetails.Password=PasswordEncrypter.Instance.Encrypt(userDetails.Password, _configuration["AppSettings:PasswordKey"]);

            UserDetails response = null;

            try
            {
                response = await _userService.Login(userDetails);


                if(response!=null)
                {
                    PresistUserAccount(response);
                    HttpContext.Session.SetInt32("UserId", response.Id);
                }
            }
            catch(Exception ex)
            {

            }

            return View("~/Views/Home/Dashboard.cshtml");
        }


        #region Private Method

        private void PresistUserAccount(UserDetails authenticateAccount)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, authenticateAccount.UserName) }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = authenticateAccount.RememberMe,
                ExpiresUtc = DateTime.UtcNow.AddHours(5)
            }).Wait();
        }

        #endregion
    }
}
