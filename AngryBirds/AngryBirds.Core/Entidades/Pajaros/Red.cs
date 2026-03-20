using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Red. Su fuerza es su ira * 10 * la cantidad de veces que se enojó.
/// </summary>
public class Red : Pajaro
{
    public int VecesEnojado { get; private set; }
    public override int Fuerza => Ira * 10 * VecesEnojado;

    public Red(int ira) : base(ira)
    {
        VecesEnojado = 1;
    }

    public override void Enfadarse()
    {
        VecesEnojado++;
    }
}
