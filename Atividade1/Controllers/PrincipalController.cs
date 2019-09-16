using Atividade1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade1.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        //Página de cadastro
        public ActionResult Create()
        {
            return View();
        }

        //Salva
        [HttpPost]
        public ActionResult Create(Noticia n)
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            listaNoticias.Add(n);
            Session["Noticias"] = listaNoticias;

            return RedirectToAction("Principal");
        }

        //Redireciona para a página de alteração com as info
        public ActionResult Update(int id)
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            var n1 = listaNoticias.Find(x => x.idNoticia == id);
            return View(n1);
        }

        //Altera
        [HttpPost]
        public ActionResult Update(Noticia n)
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            var n1 = listaNoticias.Find(x => x.idNoticia == n.idNoticia);

            listaNoticias.Remove(n1);
            listaNoticias.Add(n);
            Session["Noticias"] = listaNoticias;

            return RedirectToAction("Principal");
        }

        //Deleta
        public ActionResult Delete(int id)
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            var n1 = listaNoticias.Find(x => x.idNoticia == id);

            listaNoticias.Remove(n1);
            Session["Noticias"] = listaNoticias;

            return RedirectToAction("Principal");
        }

        //Instancia a página principal e joga na sessão a situação de quem ta acessando se é adm ou n
        public ActionResult Principal()
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            return View(listaNoticias);

            //if (Session["Admin"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    Session["Admin"] = 0;
            //    return View();
            //}
        }

        //Gerenciar
        public ActionResult GerenciarNoticias()
        {
            return View();
        }

        //Página login
        public ActionResult Login()
        {
            Session["Admin"] = 0;
            return View();
        }

        //Efetuar login
        [HttpPost]
        public ActionResult Login(FormCollection form, string txtSenha)
        {
            Usuario u = new Usuario();
            u.login = form["txtLogin"];
            u.senha = txtSenha;
            if (u.login.Equals("admin") && u.senha.Equals("admin"))
            {
                Session["Admin"] = 1;
                return RedirectToAction("Logado");
            }
            else
            {
                ModelState.AddModelError("", "Login incorreto!");
                return View();
            }
        }

        //Logado
        public ActionResult Logado()
        {
            List<Noticia> listaNoticias = new List<Noticia>();
            if (Session["Noticias"] != null)
            {
                listaNoticias = (List<Noticia>)Session["Noticias"];
            }

            return View(listaNoticias);
        }

    }
}