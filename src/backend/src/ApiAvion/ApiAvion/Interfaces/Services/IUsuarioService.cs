using ApiAvion.Dtos;
using ApiAvion.Response;

namespace ApiAvion.Interfaces.Services;

public interface IUsuarioService
{
    Task<ApiResponse<LoginDto>> Login(string nombreUsuario, string passwod);
}