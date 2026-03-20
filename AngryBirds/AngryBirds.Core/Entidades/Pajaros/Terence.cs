using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Terence. Su fuerza depende de su ira, la cantidad de veces que se enojó y un multiplicador.
/// </summary>
public class Terence : Pajaro
{
    public int VecesEnojado { get; private set; }
    public int Multiplicador { get; private set; }
    public override int Fuerza => Ira * VecesEnojado * Multiplicador;

    public Terence(int ira, int multiplicador = 1) : base(ira)
    {
        VecesEnojado = 1;
        Multiplicador = multiplicador;
    }

    public override void Enfadarse()
    {
        VecesEnojado++;
    }

    public void SetMultiplicador(int multiplicador)
    {
        if (multiplicador <= 0)
        {
            throw new ArgumentException("El multiplicador debe ser positivo.", nameof(multiplicador));
        }
        Multiplicador = multiplicador;
    }
}
