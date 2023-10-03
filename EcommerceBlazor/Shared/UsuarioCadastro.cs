using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class UsuarioCadastro
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 8)]
        public string Senha { get; set; } = string.Empty;

        [Compare("Senha", ErrorMessage = "As senhas não correspondem!")]
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}
