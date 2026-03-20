using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Islas;

/// <summary>
/// Isla Cerdito donde los cerdos tienen los huevos robados y obstáculos.
/// </summary>
public class IslaCerdito : IIsla
{
    public string Nombre { get; private set; } = "Isla Cerdito";
    public List<IObstaculo> Obstaculos { get; private set; }

    public bool HuevosRecuperados => Obstaculos.Count == 0 || Obstaculos.All(o => !o.EstaEnPie);

    public IslaCerdito()
    {
        Obstaculos = new List<IObstaculo>();
    }

    public IslaCerdito(List<IObstaculo> obstaculos)
    {
        Obstaculos = obstaculos;
    }

    public void AgregarObstaculo(IObstaculo obstaculo)
    {
        Obstaculos.Add(obstaculo);
    }

    public void RecibirAtaque(IPajaro pajaro)
    {
        var obstaculo = Obstaculos.FirstOrDefault(o => o.EstaEnPie);
        if (obstaculo != null)
        {
            obstaculo.RecibirAtaque(pajaro.Fuerza);
        }
    }

    public void LimpiarObstaculosDestruidos()
    {
        Obstaculos.RemoveAll(o => !o.EstaEnPie);
    }
}
