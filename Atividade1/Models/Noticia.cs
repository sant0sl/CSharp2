using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atividade1.Models
{
    public class Noticia
    {

        public int idNoticia { get; set; }

        public int idCategoria { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "A descrição deve conter mais que 1 e menos que 255 caracteres")]
        public string Descricao { get; set; }

        public Noticia()
        {

        }
    }
}