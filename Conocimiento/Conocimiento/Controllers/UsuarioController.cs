using Conocimiento.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conocimiento.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationUserManager _userManager;
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.USUARIOS =  UserManager.Users.ToList();
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}