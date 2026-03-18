using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades.Lugares;

public class Amurallada
{
    [Range(1, int.MaxValue, ErrorMessage = "El mínimo de vikingos debe ser un valor positivo.")]
    public int MinimoVikingos { get; set; }

    public Amurallada(int minimoVikingos)
    {
        if (minimoVikingos <= 0)
        {
            throw new ArgumentException("El mínimo de vikingos debe ser un valor positivo.", nameof(minimoVikingos));
        }
        MinimoVikingos = minimoVikingos;
    }
}
