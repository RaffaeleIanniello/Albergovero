using Albergo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Albergo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin a)
        {
            if (ModelState.IsValid)
            {
                DB.GetAdmin(a);
                if (User.Identity.Name != "")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.Errore = "Utente non trovato";
            return View();
        }

    }
}