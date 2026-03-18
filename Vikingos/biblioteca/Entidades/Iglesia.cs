using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa una iglesia en una aldea.
/// Las iglesias almacenan crucifijos que pueden ser convertidos en botín.
/// </summary>
public class Iglesia
{
    /// <summary>
    /// Obtiene la cantidad de crucifijos en la iglesia.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(0.01f, float.MaxValue, ErrorMessage = "Los crucifijos deben tener un valor positivo.")]
    public float Crucifijos { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Iglesia"/>.
    /// </summary>
    /// <param name="crucifijos">La cantidad de crucifijos en la iglesia.</param>
    /// <exception cref="ArgumentException">Se lanza cuando los crucifijos tienen un valor negativo.</exception>
    public Iglesia(float crucifijos)
    {
        if (crucifijos <= 0)
        {
            throw new ArgumentException("Los crucifijos deben tener un valor positivo.", nameof(crucifijos));
        }
        Crucifijos = crucifijos;
    }

    /// <summary>
    /// Calcula el botín obtenido de los crucifijos.
    /// </summary>
    /// <returns>El valor del botín (crucifijos * 2.5).</returns>
    public float BotinCrucifijos()
    {
        return Crucifijos * 2.5f;
    }

    /// <summary>
    /// Establece una nueva cantidad de crucifijos.
    /// </summary>
    /// <param name="crucifijos">La nueva cantidad de crucifijos.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetCrucifijos(float crucifijos)
    {
        if (crucifijos <= 0)
        {
            throw new ArgumentException("Los crucifijos deben tener un valor positivo.", nameof(crucifijos));
        }
        Crucifijos = crucifijos;
    }
}
