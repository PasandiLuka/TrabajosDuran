namespace Biblitoteca.Entidades.Lugares;

public class Aldea
{
    public Iglesia? Iglesia { get; private set; }

    public Amurallada? Amurallada { get; private set; }

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
