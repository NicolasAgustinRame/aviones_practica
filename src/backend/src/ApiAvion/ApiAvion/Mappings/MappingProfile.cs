using ApiAvion.Dtos;
using ApiAvion.Migrations;
using AutoMapper;

namespace ApiAvion.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Avione, AvionesDto>();
        CreateMap<Fabricante, FabricanteDto>();
    }
}