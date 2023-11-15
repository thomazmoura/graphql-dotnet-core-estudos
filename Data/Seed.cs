using Exemplo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo02.Data;

public class Seed
{
    public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Contexto(
                serviceProvider.GetRequiredService<DbContextOptions<Contexto>>()))
            {
                if (context.Produtos.Any())
                {
                    return;
                }
                context.Produtos.AddRange(
                    new Produto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "IPhone",
                        Descricao = "IPhone 14",
                        Preco = 120000,
                        Estoque = 100
                    },
                    new Produto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Samsung TV",
                        Descricao = "Smart TV",
                        Preco = 400000,
                        Estoque = 120
                    });
                context.SaveChanges();
            }
        }
}