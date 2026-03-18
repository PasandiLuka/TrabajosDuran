namespace Biblitoteca.Entidades;

/// <summary>
/// Representa una aldea que puede tener una iglesia o ser amurallada, pero no ambas.
/// </summary>
public class Aldea
{
    /// <summary>
    /// Obtiene la iglesia de la aldea, si existe.
    /// </summary>
    public Iglesia? Iglesia { get; private set; }

    /// <summary>
    /// Obtiene la información de amurallado de la aldea, si existe.
    /// </summary>
    public Amurallada? Amurallada { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Aldea"/>.
    /// La aldea debe tener una iglesia o ser amurallada, pero no ambas.
    /// </summary>
    /// <param name="iglesia">La iglesia de la aldea. Puede ser null.</param>
    /// <param name="amurallada">La información de amurallado. Puede ser null.</param>
    /// <exception cref="InvalidOperationException">
    /// Se lanza cuando la aldea no tiene iglesia ni es amurallada, o tiene ambas.
    /// </exception>
    public Aldea(Iglesia? iglesia = null, Amurallada? amurallada = null)
    {
        bool tieneIglesia = iglesia is not null;
        bool tieneAmurallada = amurallada is not null;

        if (tieneIglesia == tieneAmurallada)
        {
            throw new InvalidOperationException(
                "La aldea debe tener una iglesia o ser amurallada, pero no ambas.");
        }

        Iglesia = iglesia;
        Amurallada = amurallada;
    }
}
