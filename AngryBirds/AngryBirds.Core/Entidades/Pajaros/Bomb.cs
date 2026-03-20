using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Bomb. Su fuerza es el doble de su ira, con un tope máximo de 9000.
/// </summary>
public class Bomb : Pajaro
{
    private const int TopeMaximoFuerza = 9000;
    public static int TopeMaximoActual { get; set; } = TopeMaximoFuerza;

    public override int Fuerza
    {
        get
        {
            int fuerza = Ira * 2;
            return Math.Min(fuerza, TopeMaximoActual);
        }
    }

    public Bomb(int ira) : base(ira)
    {
    }

    public override void Enfadarse()
    {
        Ira *= 2;
    }
}
