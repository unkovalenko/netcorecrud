using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyASP.Models;
using Google.Cloud.Storage.V1;


using Microsoft.EntityFrameworkCore;
//using FirebirdSql.EntityFrameworkCore.Firebird;




namespace AnyASP.Controllers
{
    public class HomeController : Controller
    {
        protected Model1 model;
        public DbSet<USERS> dbUser;
        
        private Users_dal<USERS, USERS> user;

        public HomeController()
        {
            model = new Model1();
            user = new Users_dal<USERS, USERS>(model);
            dbUser = model.Set<USERS>();
        }

        public IActionResult Index()
        { 
       
            return View();
        }

        [Authorize]
        public IActionResult About()
        {

            USERS usr = user.GetByID(123);
            ViewData["Message"] = usr.US_NAME;
            return View();
        }
        [Authorize(Roles = "admin,master,user")]
        public IActionResult Contact()
        {
            int cnt = dbUser.Count();
            //    USERS us = dbUser.Find(123);
            /* PERSONAL pr = personal.GetByID(15);
             pr.PE_ID = 13;
             personal.Insert(pr);
             personal.Save();
             ViewData["Message"] = "Your contact page.";
             */
            USERS us = dbUser.Find(123);
            ViewData["Message"] = cnt.ToString() + us.US_NAME;
            return View();
        }

        public IActionResult dbset()
        {
            USERS us =  dbUser.Find(123);
            /* PERSONAL pr = personal.GetByID(15);
             pr.PE_ID = 13;
             personal.Insert(pr);
             personal.Save();
             ViewData["Message"] = "Your contact page.";
             */
            ViewData["Message"] = us.US_NAME;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
