using AngryBirds.Core.Entidades.Abstract;
using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Islas;

/// <summary>
/// Isla Pájaro donde viven los pájaros.
/// </summary>
public class IslaPajaro : IIsla
{
    public string Nombre { get; private set; } = "Isla Pájaro";
    public List<IPajaro> Pajaros { get; private set; }

    public IEnumerable<IPajaro> PajarosFuertes => Pajaros.Where(p => p.EsFuerte);
    public int FuerzaTotal => PajarosFuertes.Sum(p => p.Fuerza);

    public IslaPajaro()
    {
        Pajaros = new List<IPajaro>();
    }

    public IslaPajaro(List<IPajaro> pajaros)
    {
        Pajaros = pajaros;
    }

    public void AgregarPajaro(IPajaro pajaro)
    {
        Pajaros.Add(pajaro);
    }

    public void AplicarEvento(IEvento evento)
    {
        evento.Aplicar(this);
    }

    public void Atacar(IslaCerdito islaCerdito)
    {
        foreach (var pajaro in Pajaros)
        {
            islaCerdito.RecibirAtaque(pajaro);
        }
    }
}
