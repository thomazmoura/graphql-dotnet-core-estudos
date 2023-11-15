using Exemplo02.Models;
using Exemplo02.Services;
using HotChocolate;

namespace Exemplo02.Mutations;

public class ProdutoMutations
    {
        public async Task<bool> InserirProduto([Service] IProdutoServico produtoServico,
    Produto produto)
        {
            return await produtoServico.InserirProdutoAsync(produto);
        }
        public async Task<bool> AlterarProduto([Service] IProdutoServico produtoServico,
    Produto produto)
        {
            return await produtoServico.AlterarProdutoAsync(produto);
        }
        public async Task<bool> ExcluirProduto([Service] IProdutoServico produtoServico,
   Guid produtoId)
        {
            return await produtoServico.ExcluirProdutoAsync(produtoId);
        }
    }