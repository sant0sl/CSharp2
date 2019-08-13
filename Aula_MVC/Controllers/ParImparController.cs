using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_MVC.Controllers
{
    public class ParImparController : Controller
    {
        int numAntigo = 0;

        // GET: ParImpar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sum()
        {
            ViewBag._NumeroAntigo = numAntigo;
            return View();
        }

        [HttpPost]
        public ActionResult Sum(int txtNumeroNovo, int txtNumeroAntigo)
        {
            if (txtNumeroNovo > 0)
            {
                txtNumeroAntigo = txtNumeroAntigo + txtNumeroNovo;
                string parouimpar = ParOuImpar(txtNumeroAntigo);
                if (parouimpar.Contains("IMPAR"))
                {
                    @ViewBag._Cor = "red";
                }
                else
                {
                    @ViewBag._Cor = "lawngreen";
                }
                ViewBag._NumeroNovo = txtNumeroNovo;
                ViewBag._NumeroAntigo = txtNumeroAntigo;
                ViewBag._ParOuImpar = parouimpar;
            }
            else
            {
                ViewBag._ParOuImpar = "Não foi possível realizar esta operação";
            }

            return View();
        }

        public String ParOuImpar(int numero)
        {
            string resposta = string.Empty;
            if (numero % 2 == 0)
            {
                resposta = numero + " - PAR";
            }
            else
            {
                resposta = numero + " - IMPAR";
            }
            return resposta;
        }
    }
}