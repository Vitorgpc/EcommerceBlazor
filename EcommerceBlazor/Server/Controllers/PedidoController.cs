using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> CriarPedido()
        {
            var resultado = await _pedidoService.CriarPedido();
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PedidoOverviewResponse>>>> GetPedidos()
        {
            var resultado = await _pedidoService.GetPedidos();
            return Ok(resultado);
        }
    }
}
