using AngryBirds.Core.Entidades.Obstaculos;
using Xunit;

namespace AngryBirds.Test;

public class TestObstaculos
{
    [Fact]
    public void CuandoCreoParedVidrio_DebeCalcularResistenciaCorrecta()
    {
        ParedVidrio pared = new ParedVidrio(5);

        Assert.Equal(5, pared.Ancho);
        Assert.Equal(50, pared.Resistencia);
        Assert.True(pared.EstaEnPie);
    }

    [Fact]
    public void CuandoParedVidrioRecibeAtaque_DebeDisminuirResistencia()
    {
        ParedVidrio pared = new ParedVidrio(5);

        pared.RecibirAtaque(30);

        Assert.Equal(20, pared.ResistenciaActual);
        Assert.True(pared.EstaEnPie);
    }

    [Fact]
    public void CuandoParedVidrioRecibeAtaqueFuerte_DebeDerrumbarse()
    {
        ParedVidrio pared = new ParedVidrio(2); // Resistencia = 20

        pared.RecibirAtaque(25);

        Assert.False(pared.EstaEnPie);
    }

    [Fact]
    public void CuandoCreoParedMadera_DebeCalcularResistenciaCorrecta()
    {
        ParedMadera pared = new ParedMadera(4);

        Assert.Equal(100, pared.Resistencia);
    }

    [Fact]
    public void CuandoCreoParedPiedra_DebeCalcularResistenciaCorrecta()
    {
        ParedPiedra pared = new ParedPiedra(3);

        Assert.Equal(150, pared.Resistencia);
    }

    [Fact]
    public void CuandoCreoCerditoObrero_DebeTenerResistencia50()
    {
        CerditoObrero cerdito = new CerditoObrero();

        Assert.Equal(50, cerdito.Resistencia);
    }

    [Fact]
    public void CuandoCreoCerditoArmado_DebeCalcularResistenciaCorrecta()
    {
        CerditoArmado cerdito = new CerditoArmado(15);

        Assert.Equal(150, cerdito.Resistencia);
    }

    [Fact]
    public void CuandoCerditoArmadoRecibeAtaque_DebeDisminuirResistencia()
    {
        CerditoArmado cerdito = new CerditoArmado(10); // Resistencia = 100

        cerdito.RecibirAtaque(60);

        Assert.Equal(40, cerdito.ResistenciaActual);
        Assert.True(cerdito.EstaEnPie);
    }
}
