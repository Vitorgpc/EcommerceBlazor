using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<ServiceResponse<int>>> Cadastrar(UsuarioCadastro request)
        {
            var response = await _authService.Cadastro(new Usuario 
            { 
                Email = request.Email 
            }, request.Senha);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
