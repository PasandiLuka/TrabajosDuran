using Biblitoteca.Entidades.Lugares;
using Xunit;

namespace TestUnitarios;

public class TestCapital
{
    [Fact]
    public void CuandoCreoUnaCapital_DebeCrearseConSusValoresCorrectamente()
    {
        Capital capital = new Capital(2, 1.5f);

        Assert.Equal(2, capital.CantDefensores);
        Assert.Equal(1.5f, capital.RiquezaTierra);
    }

    [Fact]
    public void CuandoCreoUnaCapitalConValoresNegativos_DebeDevolverUnaExcepcion()
    {
        int negativo = -2;
        Assert.Throws<ArgumentException>(() => new Capital(negativo, negativo));
    }

    [Fact]
    public void CuandoLeAsignoUnNuevoValor_DebeCambiarCorrectamente()
    {
        int nuevoValor = 2;
        float nuevoValor2 = 2.5f;
        float nuevoValor3 = 2.6f;

        Capital capital = new Capital(1, 1);

        capital.SetBotin(nuevoValor2);
        capital.SetCantDefensores(2);
        capital.SetRiquezaTierra(nuevoValor3);

        Assert.Equal(nuevoValor, capital.CantDefensores);
        Assert.Equal(nuevoValor2, capital.Botin);
        Assert.Equal(nuevoValor3, capital.RiquezaTierra);
    }

    [Fact]
    public void CuandoEjecutoElMetodoBotinTotal_DebeDevolverElCalculoDelBotinEntreRiquezaDeTierrasYCantidadDeDefensores()
    {
        Capital capital = new Capital(2, 2.5f);
        float botinTotal = capital.BotinTotal();

        Assert.Equal(2 * 2.5f, botinTotal);
    }
}
