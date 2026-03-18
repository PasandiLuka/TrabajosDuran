using Biblitoteca.Entidades;
using Xunit;

namespace TestUnitarios;

public class TestAmurallada
{
    [Fact]
    public void CuandoCreoElObjetoAmurallada_DebeCrearseConSusValoresCorrectamente()
    {
        Amurallada amurallada = new Amurallada(12);

        Assert.Equal(12, amurallada.MinimoVikingos);
    }

    [Fact]
    public void CuandoCreoElObjetoAmuralladaConUnValorNegativo_DebeDevolverUnaExcepcion()
    {
        int valorNegativo = -2;
        Assert.Throws<ArgumentException>(() => new Amurallada(valorNegativo));
    }
}
