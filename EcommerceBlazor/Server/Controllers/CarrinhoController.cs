using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CarrinhoProdutoResponse>>>> GetProdutosCarrinhoDB()
        {
            var resultado = await _carrinhoService.GetProdutosCarrinhoDB();
            return Ok(resultado);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ServiceResponse<bool>>> AdicionarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            var resultado = await _carrinhoService.AdicionarItemCarrinho(itemCarrinho);
            return Ok(resultado);
        }

        [HttpPut("atualizar-quantidade")]
        public async Task<ActionResult<ServiceResponse<bool>>> AtualizarQauntidade(ItemCarrinho itemCarrinho)
        {
            var resultado = await _carrinhoService.AtualizarQuantidade(itemCarrinho);
            return Ok(resultado);
        }

        [HttpDelete("{produtoId}/{tipoProdutoId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoverItemCarrinho(int produtoId, int tipoProdutoId)
        {
            var resultado = await _carrinhoService.RemoverItemCarrinho(produtoId, tipoProdutoId);
            return Ok(resultado);
        }
    }
}
