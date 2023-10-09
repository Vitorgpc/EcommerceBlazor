using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class Endereco
    {
        public int Endereco_ID { get; set; }
        public int UsuarioId { get; set; }
        public string PrimeiroNome { get; set; } = string.Empty;
        public string UltimoNome { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
    }
}
