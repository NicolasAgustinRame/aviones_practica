namespace ApiAvion.Querys;

public class UpdateAvionQuery
{
    public Guid Id { get; set; }
    public string Modelo { get; set; }
    public int CantidadAsientos { get; set; }
    public int Motores { get; set; }
    public string DatosVarios { get; set; }
}