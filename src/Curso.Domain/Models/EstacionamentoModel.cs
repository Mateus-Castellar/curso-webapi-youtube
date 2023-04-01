namespace Curso.Domain.Models;

public class EstacionamentoModel
{
    public EstacionamentoModel()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required int Capacidade { get; set; }
    public required string Estado { get; set; }
    public required string Cidade { get; set; }
    public required string Bairro { get; set; }
    public required string Logradouro { get; set; }
    public required string Numero { get; set; }
    public string? Complemento { get; set; }
}