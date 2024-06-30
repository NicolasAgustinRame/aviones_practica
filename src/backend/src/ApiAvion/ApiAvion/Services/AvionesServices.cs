using System.Net;
using ApiAvion.Dtos;
using ApiAvion.Interfaces;
using ApiAvion.Interfaces.Services;
using ApiAvion.Migrations;
using ApiAvion.Querys;
using ApiAvion.Response;
using AutoMapper;

namespace ApiAvion.Services;

public class AvionesServices : IAvionesService
{
    private readonly IAvionesRepository _avionesRepository;
    private readonly IMapper _mapper;

    public AvionesServices(IAvionesRepository avionesRepository, IMapper mapper)
    {
        _avionesRepository = avionesRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<AvionesDto>>> GetAll()
    {
        var response = new ApiResponse<List<AvionesDto>>();
        var aviones = await _avionesRepository.GetAll();
        if (aviones != null && aviones.Count > 0)
        {
            response.Data = _mapper.Map<List<AvionesDto>>(aviones);
            return response;
        }
        else
        {
            response.SetError("No hay aviones registrados", HttpStatusCode.BadRequest);
            return response;
        }
    }

    public async Task<ApiResponse<AvionesDto>> GetByParams()
    {
        var response = new ApiResponse<AvionesDto>();
        var avion = await _avionesRepository.GetByParams();
        if (avion != null)
        {
            response.Data = _mapper.Map<AvionesDto>(avion);
            return response;
        }
        else
        {
            response.SetError("No hay registros del avion", HttpStatusCode.NotFound);
            return response;
        }
    }

    public async Task<ApiResponse<List<AvionesDto>>> GetByEmpresa()
    {
        var response = new ApiResponse<List<AvionesDto>>();
        var aviones = await _avionesRepository.GetByEmpresa();
        if (aviones != null && aviones.Count > 0)
        {
            response.Data = _mapper.Map<List<AvionesDto>>(aviones);
           
        }
        return response;
    }

    public async Task<ApiResponse<AvionesDto>> PutAvion(UpdateAvionQuery avionQuery)
    {
        var response = new ApiResponse<AvionesDto>();
        var avion = await _avionesRepository.GetById(avionQuery.Id);
        if (avion == null)
        {
            response.SetError("No existe este avion", HttpStatusCode.NotFound);
            return response;
        }

        var updateAvion = new Avione()
        {
            Id = avionQuery.Id,
            Modelo = avionQuery.Modelo,
            CantidadAsientos = avionQuery.CantidadAsientos,
            CantidadMotores = avionQuery.Motores,
            DatosVarios = avionQuery.DatosVarios
        };

        updateAvion = await _avionesRepository.PutAvion(updateAvion);
        response.Data = _mapper.Map<AvionesDto>(updateAvion);
        return response;
    }
}