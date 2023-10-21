using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class ProdutoVariante
    {
        [JsonIgnore]
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int TipoProdutoId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoOriginal { get; set; }
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editando { get; set; } = false;
        [NotMapped]
        public bool Novo { get; set; } = false;
    }
}
