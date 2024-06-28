using System;
using System.Collections.Generic;

namespace ApiAvion.Migrations;

public partial class Avione
{
    public Guid Id { get; set; }

    public Guid? IdFabricante { get; set; }

    public int? CantidadAsientos { get; set; }

    public string? Modelo { get; set; }

    public int? CantidadMotores { get; set; }

    public string? DatosVarios { get; set; }

    public virtual Fabricante? IdFabricanteNavigation { get; set; }
}
