using Blazored.LocalStorage;

namespace EcommerceBlazor.Client.Services.CarrinhoService
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public CarrinhoService(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public event Action OnChange;

        public async Task AddToCart(ItemCarrinho itemCarrinho)
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
            OnChange.Invoke();
        }

        public async Task<List<ItemCarrinho>> GetItemCarrinhos()
        {
            var carrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");

            if (carrinho == null)
            {
                carrinho = new List<ItemCarrinho>();
            }

            return carrinho;
        }

        public async Task<List<CarrinhoProdutoResponse>> GetProdutosCarrinho()
        {
            var itensCarrinho = await _localStorage.GetItemAsync<List<ItemCarrinho>>("carrinho");

            var resposta = await _httpClient.PostAsJsonAsync("api/carrinho/produtos", itensCarrinho);

            var produtosCarrinho = await resposta.Content.ReadFromJsonAsync<ServiceResponse<List<CarrinhoProdutoResponse>>>();

            return produtosCarrinho.Data;
        }

        public async Task RemoverItemCarrinho(int produtoId, int tipoProdutoId)
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
                OnChange.Invoke();
            }
        }

        public async Task AtualizarQuantidade(CarrinhoProdutoResponse produto)
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
}
