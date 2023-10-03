namespace EcommerceBlazor.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Cadastro(UsuarioCadastro request);
        Task<ServiceResponse<string>> Login(UsuarioLogin request);
    }
}
