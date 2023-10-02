using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class CarrinhoProdutoResponse
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int TipoProdutoId { get; set; }
        public string TipoProduto { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
