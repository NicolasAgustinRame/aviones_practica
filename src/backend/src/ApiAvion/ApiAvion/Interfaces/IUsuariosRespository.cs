using ApiAvion.Migrations;

namespace ApiAvion.Interfaces;

public interface IUsuariosRespository
{
    Task<Usuario> GetByEmailAndPassword(string email, string password);
}