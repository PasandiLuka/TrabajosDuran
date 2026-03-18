using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa una aldea amurallada.
/// Las aldeas amuralladas requieren una cantidad mínima de vikingos para ser saqueadas.
/// </summary>
public class Amurallada
{
    /// <summary>
    /// Obtiene o establece la cantidad mínima de vikingos requeridos para saquear la aldea.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "El mínimo de vikingos debe ser un valor positivo.")]
    public int MinimoVikingos { get; set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Amurallada"/>.
    /// </summary>
    /// <param name="minimoVikingos">La cantidad mínima de vikingos requeridos.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el mínimo de vikingos es negativo.</exception>
    public Amurallada(int minimoVikingos)
    {
        if (minimoVikingos <= 0)
        {
            throw new ArgumentException("El mínimo de vikingos debe ser un valor positivo.", nameof(minimoVikingos));
        }
        MinimoVikingos = minimoVikingos;
    }
}
