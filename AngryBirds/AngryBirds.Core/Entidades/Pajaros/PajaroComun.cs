using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Pájaro común. Su fuerza es el doble de su ira.
/// </summary>
public class PajaroComun : Pajaro
{
    public override int Fuerza => Ira * 2;

    public PajaroComun(int ira) : base(ira)
    {
    }

    public override void Enfadarse()
    {
        Ira *= 2;
    }
}
