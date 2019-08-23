using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_MVC.Models
{
    public class Pessoa
    {

        public int? idPessoa { get; set; }
        public string nome { get; set; }
        //interrogação deixa de ser obrigatório (int, float, double...)
        public int? idade { get; set; }
        public string sexo { get; set; }
        public int? peso { get; set; }

    }
}