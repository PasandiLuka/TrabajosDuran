using Biblitoteca.Entidades;
using Biblitoteca.Enum;
namespace TestUnitarios;

public class UnitTest1
{
    [Fact]
    public void CuandoCreoUnSoldado_DebeCrearElSoldadoConLosDatosCorrectos()
    {
        int arma = 15;

        Soldado soldado = new Soldado(arma);
        
        Assert.Equal(Casta.Jarl, soldado.casta);
        Assert.Equal(arma, soldado.arma);
        Assert.Equal(0, soldado.vidasCobradas);
        Assert.False(soldado.productivo);
    }

    [Fact]
    public void CuandoSetteoDistintosValores_DebeCambiarElValorEnElObjeto()
    {
        int armaDefectoValor = 13;

        int armaNuevoValor = 16;
        int vidasCobradasNuevoValor = 27;

        Soldado soldado = new Soldado(armaDefectoValor);

        soldado.SetArmas(armaNuevoValor);
        soldado.SetVidasCobradas(vidasCobradasNuevoValor);

        Assert.Equal(armaNuevoValor, soldado.arma);
        Assert.Equal(vidasCobradasNuevoValor, soldado.vidasCobradas);
    }

    [Fact]
    public void CuandoSetteoUnValorIncorrecto_DebeArrojarUnaExcepcion()
    {
        int armaDefectoValor = 28;

        int armaNuevoValor = -16;
        int vidasCobradasNuevoValor = -27;

        Soldado soldado = new Soldado(armaDefectoValor);

        Assert.Throws<ArgumentException>(() => soldado.SetArmas(armaNuevoValor));
        Assert.Throws<ArgumentException>(() => soldado.SetVidasCobradas(vidasCobradasNuevoValor));
    }

    [Fact]
    public void CuandoSuboDeCastaAlSoldado_DebeSubirDeCasta()
    {
        int arma = 777;

        Soldado soldado = new Soldado(arma);

        Assert.Equal(Casta.Jarl, soldado.casta);
        soldado.SubirCasta();

        Assert.Equal(Casta.Karl, soldado.casta);
        soldado.SubirCasta();

        Assert.Equal(Casta.Thrall, soldado.casta);
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