using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ArabaK.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Sirketler()
        {
            return View();
        }
        public ActionResult Calisanlar()
        {
            return View();
        }
    }
}