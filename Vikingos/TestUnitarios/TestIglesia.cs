using Biblitoteca.Entidades.Lugares;
using Xunit;

namespace TestUnitarios;

public class TestIglesia
{
    [Fact]
    public void CuandoCreoUnaIglesia_DebeTenerLosValoresCorrectamente()
    {
        Iglesia iglesia = new Iglesia(12);

        Assert.Equal(12, iglesia.Crucifijos);
    }

    [Fact]
    public void CuandoCreoUnaIglesiaConValoresNegativos_DebeDevolverUnaExcepcion()
    {
        int crucifijosNegativos = -1;

        Assert.Throws<ArgumentException>(() => new Iglesia(crucifijosNegativos));
    }

    [Fact]
    public void CuandoLeAsignoUnNuevoValorASusAtributos_DebeCambiarseCorrectamente()
    {
        int nuevoValor = 10;

        Iglesia iglesia = new Iglesia(12);
        iglesia.SetCrucifijos(nuevoValor);

        Assert.Equal(10, iglesia.Crucifijos);
    }

    [Fact]
    public void CuandoCalculoElBotinDeLaIglesia_DebeDevolverElValorCorrectamente()
    {
        Iglesia iglesia = new Iglesia(12);

        float botin = iglesia.BotinCrucifijos();
        Assert.Equal(iglesia.Crucifijos * 2.5f, botin);
    }
}
