
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;


using Microsoft.AspNetCore.Http;

namespace AnyASP.Models
{
    public class CurUserShow:ViewComponent
    {
		public IConfiguration Configuration { get; }
     	//public AnyGridModel model;//типовая  настройка табличной сетки 
		
        public ISQLToolsRepository SQLToolsRepository;
		public CurUserShow(
			IConfiguration configuration, Model1 _context,ISQLToolsRepository _sqltoolsRepository)
		{
			Configuration = configuration;
			
            SQLToolsRepository = _sqltoolsRepository;
		}

		public string Invoke()
		{
            string name = HttpContext.Request.Cookies["pename"];
            string username = HttpContext.Request.Cookies["name"];
            string userrole = HttpContext.Request.Cookies["role"];
            if (name == null || username == null || userrole == null)
            {
                return "Вход не выполнен";
            }
            else
            {
                if (!HttpContext.User.Identity.IsAuthenticated)
                {
                    var claims = new List<Claim>
                    {
                      new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                      new Claim(ClaimsIdentity.DefaultRoleClaimType, userrole)
                    };
                    // создаем объект ClaimsIdentity
                    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    // установка аутентификационных куки
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id),
                       new AuthenticationProperties
                       {
                           IsPersistent = true
                       });
                }
                return "Welcome " + HttpContext.Request.Cookies["pename"];
            }
        }
	}
}
