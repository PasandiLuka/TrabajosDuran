namespace Biblitoteca.Entidades;

public class Lugar
{
    public Capital? capital { get; private set; }
    public Aldea? aldea { get; private set; }
    public Lugar(Capital? capital, Aldea? aldea)
    {
        this.capital = capital;
        this.aldea = aldea;
    }
}