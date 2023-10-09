namespace EcommerceBlazor.Server.Services.EnderecoService
{
    public interface IEnderecoService
    {
        Task<ServiceResponse<Endereco>> GetEndereco();
        Task<ServiceResponse<Endereco>> AdicionarOuAtualizarEndereco(Endereco endereco);
    }
}
