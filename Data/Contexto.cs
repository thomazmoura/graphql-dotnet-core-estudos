using Exemplo02.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo02.Data;

public class Contexto: DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
    public DbSet<Produto> Produtos { get; set; }
}