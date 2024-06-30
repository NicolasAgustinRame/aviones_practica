using ApiAvion.Context;
using ApiAvion.Interfaces;
using ApiAvion.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ApiAvion.Repositories.Aviones;

public class AvionesRepository : IAvionesRepository
{
    private readonly ContextDb _contextDb;

    public AvionesRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Avione>> GetAll()
    {
        var aviones = await _contextDb.Aviones
            .Include(a => a.IdFabricanteNavigation)
            .ToListAsync();
        return aviones;
    }

    public async Task<Avione> GetById(Guid id)
    {
        var avion = await _contextDb.Aviones
            .FirstOrDefaultAsync(a => a.Id == id);
        return avion;
    }

    public async Task<Avione> GetByParams()
    {
        var avion = await _contextDb.Aviones
            .Include(a => a.IdFabricanteNavigation)
            .Where(a => a.CantidadMotores == 1 && a.IdFabricanteNavigation.Nombre != "Boeing" && a.CantidadAsientos < 5)
            .FirstOrDefaultAsync();
        return avion;
    }

    public async Task<List<Avione>> GetByEmpresa()
    {
        var aviones = await _contextDb.Aviones
            .Include(a => a.IdFabricanteNavigation)
            .Where(a => a.IdFabricanteNavigation.Nombre == "Boeing" || a.IdFabricanteNavigation.Nombre == "Airbus")
            .ToListAsync();
        return aviones;
    }

    public async Task<Avione> PutAvion(Avione avione)
    {
        var avion = await _contextDb.Aviones
            .Include(a => a.IdFabricanteNavigation)
            .FirstOrDefaultAsync(a => a.Id == avione.Id);

        avion.Id = avione.Id;
        avion.Modelo = avione.Modelo;
        avion.CantidadAsientos = avione.CantidadAsientos;
        avion.CantidadMotores = avione.CantidadMotores;
        avion.DatosVarios = avione.DatosVarios;

        _contextDb.Update(avion);
        _contextDb.SaveChanges();

        return avion;
    }
}