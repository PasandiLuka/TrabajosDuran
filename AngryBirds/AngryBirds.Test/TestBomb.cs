using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestBomb
{
    [Fact]
    public void CuandoCreoUnBomb_DebeCrearseConLosDatosCorrectos()
    {
        int ira = 100;
        Bomb bomb = new Bomb(ira);

        Assert.Equal(ira, bomb.Ira);
        Assert.Equal(ira * 2, bomb.Fuerza);
    }

    [Fact]
    public void CuandoBombSeEnoja_DebeDuplicarIra()
    {
        Bomb bomb = new Bomb(100);

        bomb.Enfadarse();

        Assert.Equal(200, bomb.Ira);
        Assert.Equal(400, bomb.Fuerza);
    }

    [Fact]
    public void CuandoFuerzaSuperaTope_DebeRespetarTopeMaximo()
    {
        Bomb bomb = new Bomb(5000);
        bomb.Enfadarse(); // Ira = 10000, Fuerza deberia ser 9000 (tope)

        Assert.Equal(9000, bomb.Fuerza);
    }

    [Fact]
    public void CuandoCambiaTopeMaximo_DebeRespetarNuevoTope()
    {
        int topeOriginal = Bomb.TopeMaximoActual;
        try
        {
            Bomb.TopeMaximoActual = 5000;
            Bomb bomb = new Bomb(3000);
            bomb.Enfadarse(); // Ira = 6000, Fuerza deberia ser 5000

            Assert.Equal(5000, bomb.Fuerza);
        }
        finally
        {
            Bomb.TopeMaximoActual = topeOriginal;
        }
    }

    [Fact]
    public void BombConFuerzaMenorATope_DebeCalcularNormal()
    {
        Bomb bomb = new Bomb(100);
        bomb.Enfadarse();
        bomb.Enfadarse();

        Assert.Equal(800, bomb.Fuerza);
    }
}
