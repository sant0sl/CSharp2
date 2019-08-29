using Aula_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_MVC.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            return View();
        }

        //DataNotation - Validação de campos mais simples
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Professor prof)
        {
            if (!ModelState.IsValid)
            {
                return View(prof);
            }
            else
            {
                //Salva no banco...
            }
            return View(prof);
        }

        //Validação do sexo
        public ActionResult validacao(string sexo)
        {
            if (sexo.ToUpper() == "M" || sexo.ToUpper() == "F")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

    }
}