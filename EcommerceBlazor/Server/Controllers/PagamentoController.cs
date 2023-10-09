using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost("checkout"), Authorize]
        public async Task<ActionResult<string>> CriarSessaoCheckout()
        {
            var session = await _pagamentoService.CriarSessaoCheckout();
            return Ok(session.Url);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> FulfillPedido()
        {
            var resposta = await _pagamentoService.FulfillPedido(Request);
            if (!resposta.Success)
            {
                return BadRequest(resposta.Message);
            }

            return Ok(resposta);
        }
    }
}
