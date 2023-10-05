using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class ItemCarrinho
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int TipoProdutoId { get; set; }
        public int Quantidade { get; set; } = 1;
    }
}
