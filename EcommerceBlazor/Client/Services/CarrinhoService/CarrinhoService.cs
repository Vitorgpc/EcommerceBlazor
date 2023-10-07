using Blazored.LocalStorage;
using EcommerceBlazor.Client.Pages;

namespace EcommerceBlazor.Client.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;

        public CarrinhoService(ILocalStorageService localStorage, HttpClient httpClient, IAuthService authService)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _authService = authService;
        }

        public event Action OnChange;

        public async Task AddToCart(ItemCarrinho itemCarrinho)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _httpClient.PostAsJsonAsync("api/carrinho/adicionar", itemCarrinho);
            }
            else
            {
                var carrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");

                if (carrinho == null)
                {
                    carrinho = new List<ItemCarrinho>();
                }

                var mesmoItem = carrinho.Find(x => x.ProdutoId == itemCarrinho.ProdutoId && x.TipoProdutoId == itemCarrinho.TipoProdutoId);

                if (mesmoItem == null)
                {
                    carrinho.Add(itemCarrinho);
                }
                else
                {
                    mesmoItem.Quantidade += itemCarrinho.Quantidade;
                }

                await _localStorage.SetItemAsync("carrinho", carrinho);
            }
            
            await GetQuantidadeItens();
        }

        public async Task<List<CarrinhoProdutoResponse>> GetProdutosCarrinho()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var resposta = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CarrinhoProdutoResponse>>>("api/carrinho");
                return resposta.Data;
            }
            else
            {
                var itensCarrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");
                if (itensCarrinho == null)
                    return new List<CarrinhoProdutoResponse>();

                var resposta = await _httpClient.PostAsJsonAsync("api/carrinho/produtos", itensCarrinho);
                var produtosCarrinho = await resposta.Content.ReadFromJsonAsync<ServiceResponse<List<CarrinhoProdutoResponse>>>();

                return produtosCarrinho.Data;
            }
        }

        public async Task RemoverItemCarrinho(int produtoId, int tipoProdutoId)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _httpClient.DeleteAsync($"api/carrinho/{produtoId}/{tipoProdutoId}");
            }
            else
            {
                var carrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");
                if (carrinho == null)
                {
                    return;
                }

                var item = carrinho.Find(x => x.ProdutoId == produtoId && x.TipoProdutoId == tipoProdutoId);

                if (item != null)
                {
                    carrinho.Remove(item);
                    await _localStorage.SetItemAsync("carrinho", carrinho);
                }
            }
        }

        public async Task AtualizarQuantidade(CarrinhoProdutoResponse produto)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var request = new ItemCarrinho 
                { 
                    ProdutoId = produto.ProdutoId,
                    TipoProdutoId = produto.TipoProdutoId,
                    Quantidade = produto.Quantidade
                };

                await _httpClient.PutAsJsonAsync("api/carrinho/atualizar-quantidade", request);
            }
            else
            {
                var carrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");
                if (carrinho == null)
                {
                    return;
                }

                var item = carrinho.Find(x => x.ProdutoId == produto.ProdutoId && x.TipoProdutoId == produto.TipoProdutoId);

                if (item != null)
                {
                    item.Quantidade = produto.Quantidade;
                    await _localStorage.SetItemAsync("carrinho", carrinho);
                }
            }
        }

        public async Task GravarItensCarrinho(bool carrinhoLocalVazio = false)
        {
            var carrinhoLocal = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");
            if (carrinhoLocal == null)
            {
                return;
            }

            await _httpClient.PostAsJsonAsync("api/carrinho", carrinhoLocal);

            if (carrinhoLocalVazio)
            {
                await _localStorage.RemoveItemAsync("carrinho");
            }
        }

        public async Task GetQuantidadeItens()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var resultado = await _httpClient.GetFromJsonAsync<ServiceResponse<int>>("api/carrinho/quantidade");
                var quantidade = resultado.Data;

                await _localStorage.SetItemAsync<int>("quantidadeCarrinho", quantidade);
            }
            else
            {
                var carrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");
                await _localStorage.SetItemAsync<int>("quantidadeCarrinho", carrinho != null ? carrinho.Count : 0);
            }

            OnChange.Invoke();
        }
    }
}
