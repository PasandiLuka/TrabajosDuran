using Biblioteca.Entidades;
using Biblioteca.Interfaces;

namespace Tests;

public class AleatorioFijo : IAzar
{
    public int ObtenerAleatorio(int tope) => 0;
}
public class BolilleroTest
{
    static AleatorioFijo _azar = new(); 
    Bolillero bolillero = new Bolillero(10, _azar);

    [Fact]
    public void CuandoJuegoParaGanar_DebeDevolverTrue()
    {
        List<int> jugada = new(){0,1,2,3,4};

        Assert.True(bolillero.JugarGana(jugada));
    }

    [Fact]
    public void CuandoJuegoParaPerder_DebeDevolverTrue()
    {
        List<int> jugada = new(){0,1,2,3,4};

        Assert.True(bolillero.JugarGana(jugada));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void CuandoJuegoNCantidadDeVeces_DebeDevolverTrue(int cantVeces)
    {
        List<int> jugada = new(){0,1,2,3,4};

        Assert.Equal(cantVeces, bolillero.GanarNVeces(jugada, cantVeces));
    } 

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void CuandoJuegoNCantidadDeVecesYLaJugadaNoCoincide_DebeDevolverFalse(int cantVeces)
    {        
        List<int> jugada = new(){1,2,3,4,5};

        Assert.NotEqual(cantVeces, bolillero.GanarNVeces(jugada, cantVeces));
    }
}