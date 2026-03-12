using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades;
using Xunit;

namespace TestUnitarios;

public class TestCapital
{
    [Fact]
    public void CuandoCreoUnaCapital_DebeCrearseConSusValoresCorrectamente()
    {
        Capital capital = new Capital(2, 1.5f);

        Assert.Equal(2, capital.cantDefensores);
        Assert.Equal(1.5f, capital.botin);
        Assert.Equal(1.5f, capital.riquezaTierra);
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

        Capital capital = new Capital(1,1);

        capital.SetBotin(nuevoValor2);
        capital.SetCantDefensores(2);
        capital.SetRiquezaTotal(nuevoValor3);

        Assert.Equal(nuevoValor, capital.cantDefensores);
        Assert.Equal(nuevoValor2, capital.botin);
        Assert.Equal(nuevoValor3, capital.riquezaTierra);
    }
    [Fact]
    public void CuantoEjecutoElMetodoBotinTotal_DebeDevolverElCalculoDelBotinEntreRiquezaDeTierrasYCantidadDeDefensores()
    {
        Capital capital = new Capital(2,2.5f);
        float botinTotal = capital.BotinTotal();

        Assert.Equal(2 * 2.5f, botinTotal);
    }
}