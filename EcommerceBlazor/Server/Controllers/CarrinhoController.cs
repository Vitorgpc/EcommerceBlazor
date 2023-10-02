using Microsoft.AspNetCore.Http;
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
    }
}
