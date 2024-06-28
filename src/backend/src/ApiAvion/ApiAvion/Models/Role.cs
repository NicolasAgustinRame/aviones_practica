using System;
using System.Collections.Generic;

namespace ApiAvion.Migrations;

public partial class Role
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
