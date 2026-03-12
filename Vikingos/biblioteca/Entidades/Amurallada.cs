namespace Biblitoteca.Entidades;

public class Amurallada
{
    public int minimoVikingos { get; set; }
    
    public Amurallada(int minimoVikingos)
    {
        Validador.EnteroPositivo(minimoVikingos, "minimoVikingos");
        this.minimoVikingos = minimoVikingos;
    }
}