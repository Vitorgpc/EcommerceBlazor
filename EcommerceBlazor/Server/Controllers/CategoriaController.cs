using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> GetCategorias()
        {
            var response = await _categoriaService.GetCategorias();
            return Ok(response);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> GetAdminCategorias()
        {
            var response = await _categoriaService.GetAdminCategorias();
            return Ok(response);
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> DeletarCategoria(int id)
        {
            var response = await _categoriaService.DeletarCategoria(id);
            return Ok(response);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> CriarCategoria(Categoria categoria)
        {
            var response = await _categoriaService.CriarCategoria(categoria);
            return Ok(response);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Categoria>>>> AtualizarCategoria(Categoria categoria)
        {
            var response = await _categoriaService.AtualizarCategoria(categoria);
            return Ok(response);
        }
    }
}
