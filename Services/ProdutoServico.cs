using Exemplo02.Data;
using Exemplo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo02.Services;

public class ProdutoServico : IProdutoServico
    {
        private readonly Contexto dbContextClass;
        public ProdutoServico(Contexto dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }
        public async Task<List<Produto>> Produtos()
        {
            return await dbContextClass.Produtos.ToListAsync();
        }
        public async Task<Produto> RecuperarProdutoPorId(Guid productId)
        {
            return await dbContextClass.Produtos.Where(ele => ele.Id == productId).FirstOrDefaultAsync();
        }
        public async Task<bool> InserirProdutoAsync(Produto productDetails)
        {
            await dbContextClass.Produtos.AddAsync(productDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> AlterarProdutoAsync(Produto productDetails)
        {
            var isProduct = ProductDetailsExists(productDetails.Id);
            if (isProduct)
            {
                dbContextClass.Produtos.Update(productDetails);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> ExcluirProdutoAsync(Guid productId)
        {
            var findProductData = dbContextClass.Produtos.Where(_ => _.Id == productId).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.Produtos.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool ProductDetailsExists(Guid productId)
        {
            return dbContextClass.Produtos.Any(e => e.Id == productId);
        }
    }
