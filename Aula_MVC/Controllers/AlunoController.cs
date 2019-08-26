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



        //2º Modo - FORM COLLECTION (Puxa o html da view no parâmetro, e pega as informações que quiser e faz o que quiser)
        public ActionResult newAluno()
        {
            return View();
        }


        [HttpPost]
        public ActionResult newAluno(FormCollection form)
        {
            Pessoa p1 = new Pessoa();
            p1.nome = form["txtNome"];
            p1.idade = Convert.ToInt32(form["txtIdade"]);
            return View();
        }



        //3º Modo - View tipada, define na view um model, inputs com ID E NAME do mesmo nome que as variáveis da classe, e pega a classe montada
        public ActionResult novoAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult novoAluno(Aluno aluno, FormCollection form)
        {

            if (!aluno.idPessoa.HasValue)
            {
                ModelState.AddModelError("", "O campo idPessoa é obrigatório!");
            }
            if (string.IsNullOrEmpty(aluno.nome))
            {
                ModelState.AddModelError("","O campo nome não pode ser vazio.");
            }
            if (!aluno.idade.HasValue)
            {
                ModelState.AddModelError("", "O campo idade é obrigatório!");
            }
            if (!aluno.peso.HasValue)
            {
                ModelState.AddModelError("", "O peso é um campo obrigatório.");
            }
            else
            {
                if (aluno.peso < 0 || aluno.peso > 300)
                {
                    ModelState.AddModelError("", "O peso deve ser superior a 0 e inferior a 300");
                }
            }
            if (string.IsNullOrEmpty(aluno.sexo))
            {
                ModelState.AddModelError("", "O campo sexo não pode ser nulo!");
            }
            else
            {
                if (aluno.sexo != "M" && aluno.sexo != "F")
                {
                    ModelState.AddModelError("", "O campo sexo deve ser M ou F!");
                }
            }
            return View();
        }



    }
}