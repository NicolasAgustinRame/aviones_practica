using ApiAvion.Interfaces.Services;
using ApiAvion.Querys;
using Microsoft.AspNetCore.Mvc;

namespace ApiAvion.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("usuarios/login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await _usuarioService.Login(query.NombreUsuario, query.Password);
        return Ok(response);
    }
} 