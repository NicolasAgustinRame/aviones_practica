using ApiAvion.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAvion.Controllers;

public class AvionesController : Controller
{
    private readonly IAvionesService _avionesService;

    public AvionesController(IAvionesService avionesService)
    {
        _avionesService = avionesService;
    }

    [HttpGet("aviones/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _avionesService.GetAll();
        return Ok(response);
    }
    
    [HttpGet("aviones/GetByParams")]
    public async Task<IActionResult> GetByParams()
    {
        var response = await _avionesService.GetByParams();
        return Ok(response);
    }
    
    [HttpGet("aviones/GetByEmpresa")]
    public async Task<IActionResult> GetByEmpresa()
    {
        var response = await _avionesService.GetByEmpresa();
        return Ok(response);
    }
}