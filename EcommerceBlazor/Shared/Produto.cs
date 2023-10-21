using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBlazor.Shared
{
    public class Produto
    {
        public int Produto_ID { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string UrlImagem { get; set; } = string.Empty;
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }
        public bool Featured { get; set; } = false;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editando { get; set; } = false;
        [NotMapped]
        public bool Novo { get; set; } = false;

        public List<ProdutoVariante> Variantes { get; set; } = new List<ProdutoVariante>();
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
    }
}
