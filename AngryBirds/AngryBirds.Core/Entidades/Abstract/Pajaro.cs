using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Abstract;

public abstract class Pajaro : IPajaro
{
    public int Ira { get; set; }
    public abstract int Fuerza { get; }
    public bool EsFuerte => Fuerza > 50;

    protected Pajaro(int ira)
    {
        Ira = ira;
    }

    public abstract void Enfadarse();
}
