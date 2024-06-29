using ApiAvion.Dtos;
using ApiAvion.Migrations;
using ApiAvion.Response;

namespace ApiAvion.Interfaces.Services;

public interface IAvionesService
{
    Task<ApiResponse<List<AvionesDto>>> GetAll();
    Task<ApiResponse<AvionesDto>> GetByParams();
    Task<ApiResponse<List<AvionesDto>>> GetByEmpresa();
}