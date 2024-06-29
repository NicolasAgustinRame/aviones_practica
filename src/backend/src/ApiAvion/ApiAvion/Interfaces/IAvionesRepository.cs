using ApiAvion.Migrations;

namespace ApiAvion.Interfaces;

public interface IAvionesRepository
{
    Task<List<Avione>> GetAll();
    Task<Avione> GetByParams();
    Task<List<Avione>> GetByEmpresa();
}