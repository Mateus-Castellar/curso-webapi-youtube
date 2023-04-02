using AutoMapper;
using Curso.API.DTO;
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
    private readonly IMapper _mapper;

    public EstacionamentoController(AppMonitoramentoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(AdicionarEstacionamentoDTO estacionamento)
    {
        try
        {
            _context.Estacionamentos.Add(_mapper.Map<EstacionamentoModel>(estacionamento));
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0 ? Ok(estacionamento) : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        try
        {
            var estacionamentos = await _context.Estacionamentos
                .ToListAsync();

            if (estacionamentos.Count == 0) return NoContent();

            return Ok(_mapper.Map<List<ListarEstacionamentosDTO>>(estacionamentos));
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        try
        {
            var estacionamento = await _context.Estacionamentos
                .FirstOrDefaultAsync(lbda => lbda.Id == id);

            if (estacionamento is null) return NotFound();

            _context.Estacionamentos.Remove(estacionamento);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, AtualizarEstacionamentoDTO atualizar)
    {
        try
        {
            var estacionamento = await _context.Estacionamentos
                .FirstOrDefaultAsync(lbda => lbda.Id == id);

            if (estacionamento is null) return NotFound();

            estacionamento.Nome = atualizar.Nome;
            estacionamento.Capacidade = atualizar.Capacidade;

            _context.Estacionamentos.Update(estacionamento);
            var resultado = await _context.SaveChangesAsync();

            return resultado > 0 ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
