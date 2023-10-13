using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class TipoProduto
    {
        public int TipoProduto_ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        [NotMapped]
        public bool Editando { get; set; } = false;

        [NotMapped]
        public bool Novo { get; set; } = false;
    }
}
