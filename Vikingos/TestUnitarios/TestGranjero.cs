using Biblitoteca.Entidades;
using Biblitoteca.Entidades.Abstract.Casta;
using Xunit;

namespace TestUnitarios;

public class TestGranjero
{
    [Fact]
    public void CuandoCreoUnGranjero_SeDebeCrearConSusDatosCorrectamente()
    {
        float hectareas = 2.3f;
        int cantHijos = 2;

        Granjero granjero = new Granjero(hectareas, cantHijos);

        Assert.Equal(Casta.Jarl, granjero.Casta);
        Assert.Equal(2, granjero.CantHijos);
        Assert.Equal(2.3f, granjero.Hectareas);
        Assert.False(granjero.Productivo);
    }

    [Fact]
    public void CuandoEjecutoElMetodoChequearProductividad_DebeVerificarSuProductividad()
    {
        float hectareas = 2.3f;
        int cantHijos = 2;

        Granjero granjero = new Granjero(hectareas, cantHijos);
        Assert.Throws<ArgumentException>(() => granjero.ChequearProductividad());

        float hectareas1 = 4;
        int cantHijos1 = 2;

        Granjero granjero1 = new Granjero(hectareas1, cantHijos1);
        granjero1.ChequearProductividad();

        Assert.True(granjero1.Productivo);
    }

    [Fact]
    public void CuandoSetteoUnNuevoValor_DebeCambiarseCorrectamente()
    {
        float hectareas = 12;
        float nuevaHectareas = 14;
        int cantHijos = 3;
        int nuevaCantHijos = 10;

        Granjero granjero = new Granjero(hectareas, cantHijos);

        granjero.SetCantHijos(nuevaCantHijos);
        granjero.SetHectareas(nuevaHectareas);

        Assert.Equal(14, granjero.Hectareas);
        Assert.Equal(10, granjero.CantHijos);
    }

    [Fact]
    public void CuandoSuboDeCasta_DebeSubirLaCasta()
    {
        Granjero granjero = new Granjero(12, 3);

        granjero.SubirCasta();

        Assert.Equal(Casta.Karl, granjero.Casta);
        granjero.SubirCasta();
        Assert.Equal(Casta.Thrall, granjero.Casta);
    }

    [Fact]
    public void CuandoReciboUnValorNegativoEnAlgunAtributo_DebeDevolverLaExcepcion()
    {
        float hectareas = -12;
        int cantHijos = -2;

        Granjero granjero = new Granjero(12, 2);

        Assert.Throws<ArgumentException>(() => granjero.SetHectareas(hectareas));
        Assert.Throws<ArgumentException>(() => granjero.SetCantHijos(cantHijos));
    }

    [Fact]
    public void CuandoSuboDeCastaSiendoUnThrall_DebeDevolverUnaExcepcion()
    {
        Granjero granjero = new Granjero(12, 2);

        granjero.SubirCasta();
        granjero.SubirCasta();

        Assert.Throws<InvalidOperationException>(() => granjero.SubirCasta());
    }
}
