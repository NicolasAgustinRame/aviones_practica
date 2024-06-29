using ApiAvion.Context;
using ApiAvion.Interfaces;
using ApiAvion.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ApiAvion.Repositories.Usuarios;

public class UsuarioRepository : IUsuariosRespository
{
    private readonly ContextDb _contextDb;

    public UsuarioRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<Usuario> GetByEmailAndPassword(string email, string password)
    {
        var usuario = await _contextDb.Usuarios
            .Include(u => u.IdRolNavigation)
            .Where(u => u.NombreUsuario == email && u.Password == password)
            .FirstOrDefaultAsync();
        return usuario;
    }
}