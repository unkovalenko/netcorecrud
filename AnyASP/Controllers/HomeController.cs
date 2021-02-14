using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using AnyASP.Models;

using AnyASP.DAL;



namespace AnyASP.Controllers
{
    public class HomeController : Controller
    {
        public IControllerExt cntExt;
        private EUnitOfWork unitOfWork;
        protected Model1 model;
       

        private DBView<USERS, UserExtensionData> userview;
        private DBTable<USERS> user;
        public HomeController(IControllerExt myext, EUnitOfWork unitOfWork)
        {
            cntExt = myext;
            this.unitOfWork = unitOfWork;
            model = new Model1();
            userview = unitOfWork.ViewUsers;
            user = unitOfWork.TblUsers;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            // sample UnitOfWork data repository  
            UserExtensionData usr = userview.GetView(f => f.US_ID == 123).ToList().First();
            ViewData["Message"] = usr.US_NAME + usr.PE_NAME;
            ViewData["Message"] = unitOfWork.ViewUsersPost(52).ToList().First().PE_NAME;
            // sample SQLTools
            cntExt.SQLTools.Execute("update users set us_crname='newname' where us_id=4");
            return View();
        }
        [Authorize(Roles = "admin,master,user")]
        public IActionResult Contact()
        {
            // sample UnitOfWork data repository 
            UserExtensionData usr = userview.GetView(f => f.US_ID == 3).ToList().First();
            USERS us = user.GetByID(4);           
            us.US_CRNAME = "=======";
            usr.US_PW = "Паро**";
            user.Update(us);
            userview.Update(usr.GetEntity());
            ViewData["Message"] = usr.US_PW;
            unitOfWork.SaveChanges();            
            return View();
        }

        public void dbset()
        {
            userview.Delete(1);
            userview.Save();
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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


    }
}
