namespace Biblitoteca.Entidades.Lugares;

public class Lugar
{
    public Capital? Capital { get; private set; }

    public Aldea? Aldea { get; private set; }

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
