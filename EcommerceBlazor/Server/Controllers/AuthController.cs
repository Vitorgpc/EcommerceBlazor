using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UsuarioLogin request)
        {
            var response = await _authService.Login(request.Email, request.Senha);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("trocar-senha"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> TrocarSenha([FromBody] string novaSenha)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resposta = await _authService.TrocarSenha(int.Parse(usuarioId), novaSenha);

            if (!resposta.Success)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
    }
}
