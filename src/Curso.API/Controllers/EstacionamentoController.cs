using Curso.Domain.Models;
using Curso.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.Controllers;

[Route("api/estacionamentos")]
[ApiController]
public class EstacionamentoController : ControllerBase
{
    private readonly AppMonitoramentoContext _context;

    public EstacionamentoController(AppMonitoramentoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(EstacionamentoModel estacionamento)
    {
        _context.Estacionamentos.Add(estacionamento);
        var resultado = await _context.SaveChangesAsync();
        return resultado > 0 ? Ok() : BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var estacionamentos = await _context.Estacionamentos.ToListAsync();
        return Ok(estacionamentos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        var estacionamento = await _context.Estacionamentos
            .FirstOrDefaultAsync(lbda => lbda.Id == id);

        _context.Estacionamentos.Remove(estacionamento);
        var resultado = await _context.SaveChangesAsync();

        return resultado > 0 ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, string nome, int capacidade)
    {
        var estacionamento = await _context.Estacionamentos
            .FirstOrDefaultAsync(lbda => lbda.Id == id);

        estacionamento.Nome = nome;
        estacionamento.Capacidade = capacidade;

        _context.Estacionamentos.Update(estacionamento);
        var resultado = await _context.SaveChangesAsync();

        return resultado > 0 ? Ok() : BadRequest();
    }
}
