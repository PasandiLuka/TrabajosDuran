using AngryBirds.Core.Entidades.Abstract;

namespace AngryBirds.Core.Entidades.Pajaros;

/// <summary>
/// Matilda. Su fuerza es el doble de su ira más la suma de la fuerza de todos sus huevos.
/// Al enojarse, pone un huevo de 2 kilos.
/// </summary>
public class Matilda : Pajaro
{
    public List<Huevo> Huevos { get; private set; }
    public override int Fuerza => (Ira * 2) + Huevos.Sum(h => h.Fuerza);

    public Matilda(int ira) : base(ira)
    {
        Huevos = new List<Huevo>();
    }

    public override void Enfadarse()
    {
        Huevos.Add(new Huevo(2));
    }

    public void AgregarHuevo(Huevo huevo)
    {
        Huevos.Add(huevo);
    }
}

/// <summary>
/// Huevo que tiene fuerza igual a su peso.
/// </summary>
public class Huevo
{
    public int Peso { get; private set; }
    public int Fuerza => Peso;

    public Huevo(int peso)
    {
        Peso = peso;
    }
}
