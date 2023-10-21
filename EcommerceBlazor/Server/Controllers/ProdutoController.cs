using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService) 
        {
            _produtoService = produtoService;
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Produto>>>> GetAdminProdutos()
        {
            var response = await _produtoService.GetAdminProdutos();
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Produto>>>> GetProdutos()
        {
            var response = await _produtoService.GetProdutosAsync();
            return Ok(response);
        }

        [HttpGet("{idProduto}")]
        public async Task<ActionResult<ServiceResponse<Produto>>> GetProduto(int idProduto)
        {
            var response = await _produtoService.GetProdutoAsync(idProduto);
            return Ok(response);
        }

        [HttpGet("categoria/{urlCategoria}")]
        public async Task<ActionResult<ServiceResponse<List<Produto>>>> GetProdutosPorCategoria(string urlCategoria)
        {
            var response = await _produtoService.GetProdutosPorCategoria(urlCategoria);
            return Ok(response);
        }

        [HttpGet("pesquisa/{pesquisa}/{pagina}")]
        public async Task<ActionResult<ServiceResponse<PesquisaProdutoResult>>> PesquisarProdutos(string pesquisa, int pagina = 1)
        {
            var response = await _produtoService.PesquisaProdutos(pesquisa, pagina);
            return Ok(response);
        }

        [HttpGet("sugestao-pesquisa/{pesquisa}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetSugestaoProduto(string pesquisa)
        {
            var response = await _produtoService.GetSugestaoPesquisa(pesquisa);
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Produto>>>> GetFeaturedProdutos()
        {
            var response = await _produtoService.GetFeaturedProdutos();
            return Ok(response);
        }
    }
}
