using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class ItemPedido
    {
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int TipoProdutoId { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotal { get; set; }
    }
}
