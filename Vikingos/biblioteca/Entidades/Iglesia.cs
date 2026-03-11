namespace Biblitoteca.Entidades;

public class Iglesia
{
    public float crucifijos { get; private set; }

    public double botinCrucifijos()
    {
        return crucifijos * 1.5;
    }

    //SETTERS
    public void SetCrucifijos(float _crucifijos)
    {
        Validador.FloatPositivo(_crucifijos, "crucifijos");
        crucifijos = _crucifijos;
    }
}