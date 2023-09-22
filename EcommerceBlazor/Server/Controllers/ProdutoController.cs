using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly EcommerceBlazorContext _context;

        public ProdutoController(EcommerceBlazorContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            var produtos = await _context.Produto.ToListAsync();
            return Ok(produtos);
        }
    }
}
