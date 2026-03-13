using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        Assert.Equal(aldea, lugar.aldea);
        Assert.Equal(aldea.iglesia, lugar.aldea.iglesia);
        Assert.Equal(aldea.iglesia.crucifijos, lugar.aldea.iglesia.crucifijos);
        Assert.Equal(capital, lugar.capital);
        Assert.Equal(capital.cantDefensores, lugar.capital.cantDefensores);
        Assert.Equal(capital.riquezaTierra, lugar.capital.riquezaTierra);
    }
    [Fact]
    public void CuandoCreoUnLugarConValoresNulos_DebeLanzarUnaExcepcion()
    {
        Assert.Throws<InvalidOperationException>(() => new Lugar(null, null));
    }
}