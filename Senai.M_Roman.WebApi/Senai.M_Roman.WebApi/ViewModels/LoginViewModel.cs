using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Roman.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail é requirido")]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
