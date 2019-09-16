using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade1.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bone()
        {
            return View();
        }

        public ActionResult Meia()
        {
            return View();
        }

        public ActionResult Sapato()
        {
            return View();
        }

    }
}