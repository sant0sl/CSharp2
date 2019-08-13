using Aula_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_MVC.Controllers
{
    public class AlunoController : Controller
    {
        //Dados da view para controller - existem 4 formas
        

        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        ////1º Modo (Mais trabalhosa) - parâmetros devem ter o mesmo nome que o id e name dados aos campos
        [HttpPost]
        public ActionResult Create(int txtID, string txtNome, int txtIdade, string lista_alunos)
        {
            if (txtIdade < 18)
            {
                ViewBag._Erro = "A idade não pode ser menor que 18 anos";
                ViewBag._Id = txtID;
                ViewBag._Nome = txtNome;
                ViewBag._Idade = txtIdade;
            }
            else
            {
                Aluno a1 = new Aluno();
                a1.idPessoa = txtID;
                a1.nome = txtNome;
                a1.idade = txtIdade;
                lista_alunos += "  /  " + a1.idPessoa + " - " + a1.nome + " - " + a1.idade;
                ViewData["lista_alunos"] = lista_alunos;
                ViewBag._Id = "";
                ViewBag._Nome = "";
                ViewBag._Idade = "";
            }

            return View();
        }

        //2º Modo


    }
}