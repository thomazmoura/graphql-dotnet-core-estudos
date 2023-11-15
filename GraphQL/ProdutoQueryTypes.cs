using Exemplo02.Models;
using Exemplo02.Services;
using HotChocolate;

namespace Exemplo02.GraphQL;

 public class ProdutoQueryTypes
    {
        public async Task<List<Produto>> Produtos([Service] IProdutoServico productService)
        {
            return await productService.Produtos();
        }
        public async Task<Produto> ProdutoPorId([Service] IProdutoServico productService, Guid productId)
        {
            return await productService.RecuperarProdutoPorId(productId);
        }
    }