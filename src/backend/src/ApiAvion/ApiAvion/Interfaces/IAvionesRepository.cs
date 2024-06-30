using ApiAvion.Migrations;

namespace ApiAvion.Interfaces;

public interface IAvionesRepository
{
    Task<List<Avione>> GetAll();
    Task<Avione> GetById(Guid id);
    Task<Avione> GetByParams();
    Task<List<Avione>> GetByEmpresa();
    Task<Avione> PutAvion(Avione avione);
}