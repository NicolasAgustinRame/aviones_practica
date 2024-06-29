using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ApiAvion.Dtos;
using ApiAvion.Interfaces;
using ApiAvion.Interfaces.Services;
using ApiAvion.Migrations;
using ApiAvion.Response;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace ApiAvion.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuariosRespository _usuariosRespository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    
    public UsuarioService(IUsuariosRespository usuariosRespository, IMapper mapper, IConfiguration configuration)
    {
        _usuariosRespository = usuariosRespository;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<ApiResponse<LoginDto>> Login(string nombreUsuario, string passwod)
    {
        var response = new ApiResponse<LoginDto>();
        var usuario = await _usuariosRespository.GetByEmailAndPassword(nombreUsuario, passwod);
        if (usuario == null)
        {
            response.SetError("No hay usuarios registrados", HttpStatusCode.BadRequest);
            return response;
        }

        var token = GenerateToken(usuario);

        response.Data = new LoginDto()
        {
            NombreUsuario = nombreUsuario,
            Password = passwod,
            Token = token
        };

        return response;

    }

    public string GenerateToken(Usuario usu)
    {
        var claim = new[]
        {
            new Claim(ClaimTypes.Name, usu.NombreUsuario),
            new Claim("Password", usu.Password),
            new Claim(ClaimTypes.Role, usu.IdRolNavigation.Nombre)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claim,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }

}