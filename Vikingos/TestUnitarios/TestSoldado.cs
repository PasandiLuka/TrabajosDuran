using Biblitoteca.Entidades;
using Biblitoteca.Entidades.Abstract.Casta;
using Xunit;

namespace TestUnitarios;

public class TestSoldado
{
    [Fact]
    public void CuandoCreoUnSoldado_DebeCrearElSoldadoConLosDatosCorrectos()
    {
        int arma = 15;

        Soldado soldado = new Soldado(arma);

        Assert.Equal(Casta.Jarl, soldado.Casta);
        Assert.Equal(arma, soldado.Arma);
        Assert.Equal(0, soldado.VidasCobradas);
        Assert.False(soldado.Productivo);
    }

    [Fact]
    public void CuandoSetteoDistintosValores_DebeCambiarElValorEnElObjeto()
    {
        int armaDefectoValor = 13;

        int armaNuevoValor = 16;
        int vidasCobradasNuevoValor = 27;

        Soldado soldado = new Soldado(armaDefectoValor);

        soldado.SetArma(armaNuevoValor);
        soldado.SetVidasCobradas(vidasCobradasNuevoValor);

        Assert.Equal(armaNuevoValor, soldado.Arma);
        Assert.Equal(vidasCobradasNuevoValor, soldado.VidasCobradas);
    }

    [Fact]
    public void CuandoSetteoUnValorIncorrecto_DebeArrojarUnaExcepcion()
    {
        int armaDefectoValor = 28;

        int armaNuevoValor = -16;
        int vidasCobradasNuevoValor = -27;

        Soldado soldado = new Soldado(armaDefectoValor);

        Assert.Throws<ArgumentException>(() => soldado.SetArma(armaNuevoValor));
        Assert.Throws<ArgumentException>(() => soldado.SetVidasCobradas(vidasCobradasNuevoValor));
    }

    [Fact]
    public void CuandoSuboDeCastaAlSoldado_DebeSubirDeCasta()
    {
        int arma = 777;

        Soldado soldado = new Soldado(arma);

        Assert.Equal(Casta.Jarl, soldado.Casta);
        soldado.SubirCasta();

        Assert.Equal(Casta.Karl, soldado.Casta);
        soldado.SubirCasta();

        Assert.Equal(Casta.Thrall, soldado.Casta);
    }

    [Fact]
    public void CuandoSuboDeCastaEstandoEnThrall_DebeArrojarUnaExcepcion()
    {
        int arma = 666;

        Soldado soldado = new Soldado(arma);

        soldado.SubirCasta();
        soldado.SubirCasta();

        Assert.Throws<InvalidOperationException>(() => soldado.SubirCasta());
    }
}
