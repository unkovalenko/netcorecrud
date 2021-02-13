using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AnyASP.Models;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AnyASP.DAL;



namespace AnyASP.Controllers
{
    public class HomeController : Controller
    {
        public IControllerExt cntExt;
        private IUnitOfWork unitOfWork;
        protected Model1 model;
        public DbSet<USERS> dbUser;

        private Users_dal<USERS, UserBigData> userbigdata;
        private EDBTable<USERS> user;
        public HomeController(IControllerExt myext, IUnitOfWork unitOfWork)
        {
            cntExt = myext;
            this.unitOfWork = unitOfWork;
            model = new Model1();
            userbigdata = new Users_dal<USERS, UserBigData>(unitOfWork);
            user = new EDBTable<USERS>(unitOfWork);
            dbUser = model.Set<USERS>();
        }

        public IActionResult Index()
        {

            return View();
        }

        [Authorize]
        public IActionResult About()
        {

            UserBigData usr = userbigdata.GetView(f => f.US_ID == 123).ToList().First();
            ViewData["Message"] = usr.US_NAME + usr.PE_NAME;
            cntExt.SQLTools.Execute("update users set us_crname='newname' where us_id=4");
            return View();
        }
        [Authorize(Roles = "admin,master,user")]
        public IActionResult Contact()
        {
            UserBigData usr = userbigdata.GetView(f => f.US_ID == 3).ToList().First();
            USERS us = user.GetByID(4);
            // unitOfWork.BeginTransaction();
            us.US_CRNAME = "=======";
            usr.US_PW = "Паро**";
            user.Update(us);
            userbigdata.Update(usr.Get());

            ViewData["Message"] = usr.US_PW;
            unitOfWork.SaveChanges();
            //  unitOfWork.Commit();
            return View();
        }

        public IActionResult dbset()
        {
            USERS us = dbUser.Find(123);
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
