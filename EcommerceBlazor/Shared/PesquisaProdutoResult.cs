using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class PesquisaProdutoResult
    {
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public int Paginas { get; set; }
        public int PaginaAtual { get; set; }
    }
}
