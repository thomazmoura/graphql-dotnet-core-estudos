namespace Exemplo02.Models;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Preco { get; set; }
    public int Estoque { get; set; }
}