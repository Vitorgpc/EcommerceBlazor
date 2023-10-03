using System.Security.Cryptography;

namespace EcommerceBlazor.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly EcommerceBlazorContext _context;

        public AuthService(EcommerceBlazorContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Cadastro(Usuario usuario, string senha)
        {
            if (await UsuarioExiste(usuario.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Usuario já existe!"
                };
            }

            CriarSenhaHash(senha, out byte[] senhaHash, out byte[] senhaSalt);

            usuario.SenhaHash = senhaHash;
            usuario.SenhaSalt = senhaSalt;

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = usuario.Usuario_ID,
                Message = "Cadastro realizado com sucesso!"
            };
        }

        public async Task<bool> UsuarioExiste(string email)
        {
            if (await _context.Usuario.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }

            return false;
        }

        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt) 
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }
    }
}
