namespace Biblitoteca.Entidades;

/// <summary>
/// Representa un lugar que puede contener una capital y/o una aldea.
/// </summary>
public class Lugar
{
    /// <summary>
    /// Obtiene la capital del lugar, si existe.
    /// </summary>
    public Capital? Capital { get; private set; }

    /// <summary>
    /// Obtiene la aldea del lugar, si existe.
    /// </summary>
    public Aldea? Aldea { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Lugar"/>.
    /// El lugar debe tener al menos una capital o una aldea.
    /// </summary>
    /// <param name="capital">La capital del lugar. Puede ser null.</param>
    /// <param name="aldea">La aldea del lugar. Puede ser null.</param>
    /// <exception cref="InvalidOperationException">
    /// Se lanza cuando el lugar no tiene ni capital ni aldea.
    /// </exception>
    public Lugar(Capital? capital, Aldea? aldea)
    {
        if (capital is null && aldea is null)
        {
            throw new InvalidOperationException(
                "El lugar debe tener una capital o una aldea, o ambos.");
        }

        Capital = capital;
        Aldea = aldea;
    }
}
