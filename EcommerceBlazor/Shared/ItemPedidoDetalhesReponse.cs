using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class ItemPedidoDetalhesReponse
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string TipoProduto { get; set; }
        public string UrlImagemProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
