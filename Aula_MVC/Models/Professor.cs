using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_MVC.Models
{
    public class Professor
    {

        //Required é requisição de campo obrigatorio por exemplo, com uma mensagem
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nome { get; set; }


        //StringLength controla o tamanho de uma string de campo
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O sobrenome não pode ter mais que 10 caracteres, nem menos que 3")]
        public string Sobrenome { get; set; }


        //Range é o controle da numeração que pode ser usada em um campo inteiro
        [Range(18,50, ErrorMessage = "A idade não pode ser inferior a 18, nem maior que 50.")]
        public int Idade { get; set; }


        //Compare compara campos por exemplo
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "Senha não confere.")]
        public string ConfirmaSenha { get; set; }


        //Remote - validação customizada Remote("método de verificação", "controller onde está o método", "mensagem caso seja falso o retorno")
        [System.Web.Mvc.Remote("validacao", "Professor", ErrorMessage = "Opção de sexo inválido.")]
        public string Sexo { get; set; }


        //valida CPF com Remote
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 números.")]
        [System.Web.Mvc.Remote("validacaoCPF", "Professor", AdditionalFields = "Email", ErrorMessage = "CPF já está cadastrado na lista.")]
        public string Cpf { get; set; }

        
        public string Email { get; set; }

    }
}