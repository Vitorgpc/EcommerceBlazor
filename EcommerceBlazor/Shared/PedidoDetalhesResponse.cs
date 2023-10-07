using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class PedidoDetalhesResponse
    {
        public DateTime DataPedido { get; set; }
        public decimal PrecoTotal { get; set; }
        public List<ItemPedidoDetalhesReponse> Itens { get; set; }
    }
}
