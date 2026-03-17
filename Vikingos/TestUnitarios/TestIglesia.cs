using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades;
using Xunit;

namespace TestUnitarios;

public class TestIglesia
{
    [Fact]
    public void CuandoCreoUnaIglesia_DebeTenerLosValoresCorrectamente()
    {
        Iglesia iglesia = new Iglesia(12);

        Assert.Equal(12, iglesia.crucifijos);
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

        Assert.Equal(10, iglesia.crucifijos);
    }
    [Fact]
    public void CuandoCalculoElbotinDeLaIglesia_DebeDevolverElValorCorrectamente()
    {
        Iglesia iglesia = new Iglesia(12);

        float botin = iglesia.botinCrucifijos();
        Assert.Equal(iglesia.crucifijos * 1.5f,botin);
    }
}