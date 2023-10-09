namespace EcommerceBlazor.Server.Services.EnderecoService
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IAuthService _authService;
        private readonly EcommerceBlazorContext _context;

        public EnderecoService(EcommerceBlazorContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<Endereco>> AdicionarOuAtualizarEndereco(Endereco endereco)
        {
            var response = new ServiceResponse<Endereco>();

            var dbEndereco = (await GetEndereco()).Data;

            if (dbEndereco == null)
            {
                endereco.UsuarioId = _authService.GetUsuarioId();
                _context.Endereco.Add(endereco);
                response.Data = endereco;
            }
            else
            {
                dbEndereco.PrimeiroNome = endereco.PrimeiroNome;
                dbEndereco.UltimoNome = endereco.UltimoNome;
                dbEndereco.Pais = endereco.Pais;
                dbEndereco.Estado = endereco.Estado;
                dbEndereco.Cidade = endereco.Cidade;
                dbEndereco.Cep = endereco.Cep;
                dbEndereco.Rua = endereco.Rua;
            }

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<ServiceResponse<Endereco>> GetEndereco()
        {
            int usuarioId = _authService.GetUsuarioId();

            var endereco = await _context.Endereco.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);

            return new ServiceResponse<Endereco> { Data = endereco };
        }
    }
}
