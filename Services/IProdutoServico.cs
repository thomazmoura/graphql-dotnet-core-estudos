using Exemplo02.Models;

namespace Exemplo02.Services;

 public interface IProdutoServico
    {
        public Task<List<Produto>> Produtos();
        public Task<Produto> RecuperarProdutoPorId(Guid productId);
        public Task<bool> InserirProdutoAsync(Produto productDetails);
        public Task<bool> AlterarProdutoAsync(Produto productDetails);
        public Task<bool> ExcluirProdutoAsync(Guid productId);
    }