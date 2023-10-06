using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class PedidoOverviewResponse
    {
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal PrecoTotal { get; set; }
        public string NomeProduto { get; set; }
        public string UrlImagemProduto { get; set; }
    }
}
