using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Obstaculos;
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Interfaces;
using Xunit;

namespace AngryBirds.Test;

public class TestIslaCerdito
{
    [Fact]
    public void CuandoCreoUnaIslaCerdito_DebeCrearConListaVacia()
    {
        IslaCerdito isla = new IslaCerdito();

        Assert.Equal("Isla Cerdito", isla.Nombre);
        Assert.Empty(isla.Obstaculos);
        Assert.True(isla.HuevosRecuperados);
    }

    [Fact]
    public void CuandoAgregoObstaculos_DebeTenerlosEnLaLista()
    {
        IslaCerdito isla = new IslaCerdito();
        isla.AgregarObstaculo(new CerditoObrero());
        isla.AgregarObstaculo(new ParedVidrio(5));

        Assert.Equal(2, isla.Obstaculos.Count);
    }

    [Fact]
    public void CuandoTodosObstaculosDestruidos_DebeTenerHuevosRecuperados()
    {
        IslaCerdito isla = new IslaCerdito();
        var obstaculo = new CerditoObrero();
        isla.AgregarObstaculo(obstaculo);
        
        // Atacar hasta destruir
        obstaculo.RecibirAtaque(100);

        Assert.True(isla.HuevosRecuperados);
    }

    [Fact]
    public void CuandoHayObstaculosEnPie_NoDebeTenerHuevosRecuperados()
    {
        IslaCerdito isla = new IslaCerdito();
        isla.AgregarObstaculo(new CerditoObrero());

        Assert.False(isla.HuevosRecuperados);
    }

    [Fact]
    public void CuandoRecibeAtaque_DebeImpactarEnPrimerObstaculo()
    {
        IslaCerdito isla = new IslaCerdito();
        isla.AgregarObstaculo(new ParedVidrio(2)); // Resistencia = 20
        isla.AgregarObstaculo(new CerditoObrero()); // Resistencia = 50

        IPajaro pajaro = new PajaroComun(30); // Fuerza = 60
        isla.RecibirAtaque(pajaro);

        Assert.False(isla.Obstaculos[0].EstaEnPie);
        Assert.True(isla.Obstaculos[1].EstaEnPie);
    }

    [Fact]
    public void CuandoLimpiaObstaculosDestruidos_DebeMantenerSoloEnPie()
    {
        IslaCerdito isla = new IslaCerdito();
        var obstaculo1 = new CerditoObrero();
        var obstaculo2 = new CerditoObrero();
        isla.AgregarObstaculo(obstaculo1);
        isla.AgregarObstaculo(obstaculo2);

        obstaculo1.RecibirAtaque(100);
        isla.LimpiarObstaculosDestruidos();

        Assert.Single(isla.Obstaculos);
        Assert.Contains(obstaculo2, isla.Obstaculos);
    }
}
