using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService) 
        {
            _carrinhoService = carrinhoService;
        }

        [HttpPost("produtos")]
        public async Task<ActionResult<ServiceResponse<List<CarrinhoProdutoResponse>>>> GetProdutosCarrinho(List<ItemCarrinho> itensCarrinho)
        {
            var resultado = await _carrinhoService.GetProdutosCarrinho(itensCarrinho);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CarrinhoProdutoResponse>>>> GravarItensCarrinho(List<ItemCarrinho> itensCarrinho)
        {
            var resultado = await _carrinhoService.GravarItensCarrinho(itensCarrinho);
            return Ok(resultado);
        }

        [HttpGet("quantidade")]
        public async Task<ActionResult<ServiceResponse<int>>> GetQuantidadeItens()
        {
            return await _carrinhoService.GetQuantidadeItens();
        }
    }
}
