namespace Biblitoteca.Entidades;

public class Iglesia
{
    public float crucifijos { get; private set; }
    public Iglesia(float crucifijos)
    {
        Validador.FloatPositivo(crucifijos, "crucifijos");
        this.crucifijos = crucifijos;
    }
    public float botinCrucifijos()
    {
        return crucifijos * 1.5f;
    }
    //SETTERS
    public void SetCrucifijos(float _crucifijos)
    {
        Validador.FloatPositivo(_crucifijos, "crucifijos");
        crucifijos = _crucifijos;
    }
}