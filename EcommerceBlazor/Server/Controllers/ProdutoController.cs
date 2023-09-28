using Azure;
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
    }
}
