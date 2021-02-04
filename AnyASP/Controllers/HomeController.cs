using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyASP.Models;
using Google.Cloud.Storage.V1;



namespace AnyASP.Controllers
{
    public class HomeController : Controller
    {
        protected Model1 model;
        private Users_dal<USERS, USERS> user;

        public HomeController()
        {
            model = new Model1();
            user = new Users_dal<USERS, USERS>(model);
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
           /* PERSONAL pr = personal.GetByID(15);
            pr.PE_ID = 13;
            personal.Insert(pr);
            personal.Save();
            ViewData["Message"] = "Your contact page.";
            */
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
