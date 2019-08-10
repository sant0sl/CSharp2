using Aula_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_MVC.Controllers
{
    public class PessoaController : Controller
    {
        //há 3 métodos de passar dados por parâmetro do controller pra view

        // GET: Pessoa
        public ActionResult Index()
        {

            //viewdata - aceita qualquer coisa, like a var
            ViewData["idPessoa"] = 1;
            ViewData["nome"] = "Fabiano";
            ViewData["idade"] = 32;

            //viewbag - mesmo que viewdata mas não é o mais ideal para ser utilizado
            Pessoa p1 = new Pessoa();
            p1.idPessoa = 2;
            p1.nome = "Leonardo SDS";
            p1.idade = 20;

            ViewBag._Id = p1.idPessoa;
            ViewBag._Nome = p1.nome;
            ViewBag._Idade = p1.idade;

            return View();
        }

        public ActionResult Details()
        {
            //viewtype - podemos retornar na View() um tipo de algo, objeto, lista...
            Pessoa p1 = new Pessoa();
            p1.idPessoa = 3;
            p1.nome = "Hellem";
            p1.idade = 56;

            return View(p1);
        }

    }
}