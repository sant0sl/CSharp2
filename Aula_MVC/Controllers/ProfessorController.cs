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

        //DataAnnotation - Validação de campos mais simples
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
                List<string> listaCPF = new List<string>();
                if (Session["listaCPFSession"] != null)
                {
                    listaCPF = (List<string>)Session["listaCPFSession"];
                }
                
                listaCPF.Add(prof.Cpf);

                Session["listaCPFSession"] = listaCPF;

                return View();
            }
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


        //Validação CPF e email
        public ActionResult validacaoCPF(string cpf/*, string email*/)
        {
            //if (!email.Contains("@"))
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            if (Session["listaCPFSession"] != null)
            {
                List<string> listaCPF;
                //no caso de banco, dá o select aqui pra carregar a lista, e verifica...
                listaCPF = (List<string>)Session["listaCPFSession"];
                if (listaCPF.Contains(cpf))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}