using AutoMapper;
using Curso.API.DTO;
using Curso.Domain.Models;

namespace Curso.API.AutoMapper;

public class EstacionamentoProfile : Profile
{
    public EstacionamentoProfile()
    {
        CreateMap<AdicionarEstacionamentoDTO, EstacionamentoModel>();
        CreateMap<EstacionamentoModel, ListarEstacionamentosDTO>();
    }
}
