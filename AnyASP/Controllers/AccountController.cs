using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Security.Claims;

using AnyASP.Models;







namespace AnyASP
{
    public class LoginDate
    {
        string Name { get; set; }
        string Password { get; set; }
    }
    public class AccountController : Controller
    {
        public EWebUsers _users;
        public IControllerExt cntExt;
        public AccountController(IControllerExt myext, Model1 _context)
		{
			_users = new EWebUsers(myext.Configuration, _context);
            cntExt = myext;			
		}


		[HttpGet]
		[Route("Login")]
		public IActionResult Login()
        {
			return View();
        }


		
		[Route("LoginDate")]
        [HttpPost]
		public async Task<IActionResult> Post([FromBody]LoginDate dt)
		{
            LoginModel  model=new LoginModel();
            if (ModelState.IsValid)
            {

                User user = _users.GetUser(model.Name, model.Password);
                if (user != null)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    bool checkOutConnect;
                    try
                    {
                        checkOutConnect = (cntExt.Configuration["CheckOutConnect"]) == "1";
                    }
                    catch
                    {
                        checkOutConnect = false;
                    }

                    int cookiesExpiresDay;
                    try
                    {
                        cookiesExpiresDay = Convert.ToInt32(cntExt.Configuration["CookiesExpiresDay"]);
                    }
                    catch
                    {
                        cookiesExpiresDay = Constants.CookiesExpiresDay;
                    }
                    if (checkOutConnect)
                    {
                        //if (user.ACLEVEL == 0)
                        {
                            ModelState.AddModelError("", "Disable connect");
                            HttpContext.Response.Cookies.Delete("peid");
                            HttpContext.Response.Cookies.Delete("pename");
                            HttpContext.Response.Cookies.Delete("prid");
                            HttpContext.Response.Cookies.Delete("prname");


                            return View(model);
                        }
                    }

                    if (cookiesExpiresDay == 0)
                        cookiesExpiresDay = Constants.CookiesExpiresDay;
                    cookieOptions.Expires = DateTimeOffset.Now.AddDays(cookiesExpiresDay);
                    HttpContext.Response.Cookies.Append("peid", user.PE_ID.ToString(), cookieOptions);
                    HttpContext.Response.Cookies.Append("pename", user.FIO, cookieOptions);

                    HttpContext.Response.Cookies.Append("name", user.name, cookieOptions);
                    HttpContext.Response.Cookies.Append("role", user.role, cookieOptions);

                    await Authenticate(user, cookieOptions.Expires); // аутентификация
                    //HttpContext.Response.Cookies.Append(".AspNetCore.Cookies", user.name, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


        private async Task Authenticate(User user, DateTimeOffset? expired)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = expired
                });
        }


        [HttpPost]
		[Route("Logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("peid");
            HttpContext.Response.Cookies.Delete("pename");
            HttpContext.Response.Cookies.Delete("name");
            HttpContext.Response.Cookies.Delete("role");
            return RedirectToAction("Login", "Account");
		}

        [HttpGet]
        public IActionResult AccessDenied(string ReturnUrl=null)
        {
            return RedirectToAction(nameof(Login));
        }

    }
}