using Kazillian.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kazillian.Controllers
{
    public class ProfileController : Controller
    { 
        public ActionResult Seller(string id)
        {
            var ProfileInfo = ProfileService.GetSalesperson(id);

            return View(ProfileInfo);
        }

        public ActionResult Employer(string id)
        {
            return View();
        }

        public ActionResult Me()
        {
            return View();
        }

        public ActionResult Job(string id)
        {
            return View();
        }
    }
}