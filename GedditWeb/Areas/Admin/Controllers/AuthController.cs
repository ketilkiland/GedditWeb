using GedditWeb.Areas.Admin.Models.Auth;
using GedditWeb.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GedditWeb.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _accountService.Authenticate(model.Email, model.Password);

            //Temp!
            if (response.Success)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Sid, response.Result.UserID),
                    new Claim(ClaimTypes.Name, response.Result.DisplayName)
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {

                ModelState.AddModelError("", "Wrong username or password");

                return View(model);
            }
        }


        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut();

            return RedirectToAction("Login", "Auth", new { area = "Admin" });
        }


        public ActionResult Register()
        {
            return View();
        }
    }
}