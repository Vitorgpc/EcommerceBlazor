global using EcommerceBlazor.Shared;
global using System.Net.Http.Json;
global using EcommerceBlazor.Client.Services.ProdutoService;
global using EcommerceBlazor.Client.Services.CategoriaService;
global using EcommerceBlazor.Client.Services.CarrinhoService;
global using EcommerceBlazor.Client.Services.AuthService;
global using EcommerceBlazor.Client.Services.PedidoService;
global using Microsoft.AspNetCore.Components.Authorization;
global using EcommerceBlazor.Client.Services.EnderecoService;
global using EcommerceBlazor.Client.Services.TipoProdutoService;

using Blazored.LocalStorage;
using EcommerceBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<ITipoProdutoService, TipoProdutoService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
