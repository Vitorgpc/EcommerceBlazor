using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EcommerceBlazor.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly EcommerceBlazorContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(EcommerceBlazorContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task<ServiceResponse<string>> Login(string email, string senha)
        {
            var response = new ServiceResponse<string>();

            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => 
                x.Email.ToLower().Equals(email.ToLower()));

            if (usuario == null)
            {
                response.Success = false;
                response.Message = "Usuario não encontrado";
            }
            else if (!VerificarHashSenha(senha, usuario.SenhaHash, usuario.SenhaSalt))
            {
                response.Success = false;
                response.Message = "Senha está incorreta!";
            }
            else
            {
                response.Data = CriarToken(usuario);
            }

            return response;
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

        private bool VerificarHashSenha(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512(senhaSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computedHash.SequenceEqual(senhaHash);
            }
        }

        private string CriarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario_ID.ToString()),
                new Claim(ClaimTypes.Name, usuario.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
