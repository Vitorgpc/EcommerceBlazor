using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBlazor.Shared
{
    public class Pedido
    {
        public int Pedido_ID { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotal { get; set; }
        public List<ItemPedido> Itens { get; set; }
    }
}
