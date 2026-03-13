namespace Biblitoteca.Entidades;

public class Lugar
{
    public Capital? capital { get; private set; }
    public Aldea? aldea { get; private set; }
    public Lugar(Capital? capital, Aldea? aldea)
    {
        if (capital is null && aldea is null) throw new InvalidOperationException("La aldea debe ser amurallada o poseer una iglesia, más no debe poseer las dos");
        this.capital = capital;
        this.aldea = aldea;
    }
}