namespace EcommerceBlazor.Client.Services.EnderecoService
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEndereco();
        Task<Endereco> AdicionarOuAtualizarEndereco(Endereco endereco);
    }
}
