using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArabaK.Models;

namespace ArabaK.Controllers
{
    public class AdminController : Controller
    {
        private SOAProjeEntities2 db = new SOAProjeEntities2();
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