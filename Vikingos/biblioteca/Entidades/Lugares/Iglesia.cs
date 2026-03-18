using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades.Lugares;

public class Iglesia
{
    [Range(0.01f, float.MaxValue, ErrorMessage = "Los crucifijos deben tener un valor positivo.")]
    public float Crucifijos { get; private set; }

    public Iglesia(float crucifijos)
    {
        if (crucifijos <= 0)
        {
            throw new ArgumentException("Los crucifijos deben tener un valor positivo.", nameof(crucifijos));
        }
        Crucifijos = crucifijos;
    }

    public float BotinCrucifijos()
    {
        return Crucifijos * 2.5f;
    }

    public void SetCrucifijos(float crucifijos)
    {
        if (crucifijos <= 0)
        {
            throw new ArgumentException("Los crucifijos deben tener un valor positivo.", nameof(crucifijos));
        }
        Crucifijos = crucifijos;
    }
}
