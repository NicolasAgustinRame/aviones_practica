using System;
using System.Collections.Generic;

namespace ApiAvion.Migrations;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Password { get; set; }

    public Guid? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
