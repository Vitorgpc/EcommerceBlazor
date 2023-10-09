using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class Usuario
    {
        public int Usuario_ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Endereco Endereco { get; set; }
    }
}
