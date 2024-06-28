using System;
using System.Collections.Generic;

namespace ApiAvion.Migrations;

public partial class Fabricante
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Avione> Aviones { get; set; } = new List<Avione>();
}
