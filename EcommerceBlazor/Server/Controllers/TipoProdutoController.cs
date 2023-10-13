using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TipoProdutoController : ControllerBase
    {
        private readonly ITipoProdutoService _tipoProdutoService;

        public TipoProdutoController(ITipoProdutoService tipoProdutoService)
        {
            _tipoProdutoService = tipoProdutoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TipoProduto>>>> GetTipoProduto()
        {
            var response = await _tipoProdutoService.GetTipoProduto();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TipoProduto>>>> AdicionarTipoProduto(TipoProduto tipoProduto)
        {
            var response = await _tipoProdutoService.AdicionarTipoProduto(tipoProduto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TipoProduto>>>> AtualizarTipoProduto(TipoProduto tipoProduto)
        {
            var response = await _tipoProdutoService.AtualizarTipoProduto(tipoProduto);
            return Ok(response);
        }
    }
}
