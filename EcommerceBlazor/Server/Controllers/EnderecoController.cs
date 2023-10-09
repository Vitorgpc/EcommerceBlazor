using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Endereco>>> GetEndereco()
        {
            return await _enderecoService.GetEndereco();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Endereco>>> AdicionarOuAtualizarEndereco(Endereco endereco)
        {
            return await _enderecoService.AdicionarOuAtualizarEndereco(endereco);
        }
    }
}
