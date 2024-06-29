namespace ApiAvion.Dtos;

public class AvionesDto
{
    public string? Modelo { get; set; }
    public int? CantidadAsientos { get; set; }
    public int? CantidadMotores { get; set; }
    public FabricanteDto IdFabricanteNavigation { get; set; }
}