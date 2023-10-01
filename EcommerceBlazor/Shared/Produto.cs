using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class Produto
    {
        public int Produto_ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProdutoVariante> Variantes { get; set; } = new List<ProdutoVariante>();
    }
}
