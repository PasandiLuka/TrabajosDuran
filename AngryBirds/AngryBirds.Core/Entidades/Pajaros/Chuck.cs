using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Chuck. Su fuerza depende de la velocidad. Hasta 80 km/h es 150, luego suma 5 * cada km que se pase de 80.
/// Cuando se enoja, duplica su velocidad.
/// </summary>
public class Chuck : Pajaro
{
    public int Velocidad { get; private set; }
    public override int Fuerza => CalcularFuerza();

    public Chuck(int velocidad) : base(velocidad)
    {
        Velocidad = velocidad;
        Ira = velocidad;
    }

    private int CalcularFuerza()
    {
        if (Velocidad <= 80)
        {
            return 150;
        }
        return 150 + 5 * (Velocidad - 80);
    }

    public override void Enfadarse()
    {
        Velocidad *= 2;
        Ira = Velocidad;
    }
}
