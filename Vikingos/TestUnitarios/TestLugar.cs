using Biblitoteca.Entidades;
using Xunit;

namespace TestUnitarios;

public class TestLugar
{
    [Fact]
    public void CuandoCreoUnLugar_DebeTenerLosValoresCorrectos()
    {
        int cantDefensores = 2;
        float riquezaTierra = 1.2f;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Iglesia iglesia = new Iglesia(12);
        Aldea aldea = new Aldea(iglesia);

        Lugar lugar = new Lugar(capital, aldea);

        Assert.Equal(aldea, lugar.Aldea);
        Assert.Equal(aldea.Iglesia, lugar.Aldea.Iglesia);
        Assert.Equal(aldea.Iglesia.Crucifijos, lugar.Aldea.Iglesia.Crucifijos);
        Assert.Equal(capital, lugar.Capital);
        Assert.Equal(capital.CantDefensores, lugar.Capital.CantDefensores);
        Assert.Equal(capital.RiquezaTierra, lugar.Capital.RiquezaTierra);
    }

    [Fact]
    public void CuandoCreoUnLugarConValoresNulos_DebeLanzarUnaExcepcion()
    {
        Assert.Throws<InvalidOperationException>(() => new Lugar(null, null));
    }
}
