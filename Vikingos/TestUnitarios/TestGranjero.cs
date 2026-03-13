using Biblitoteca;
using Biblitoteca.Entidades;
using Biblitoteca.Enum;

namespace TestUnitarios;

public class TestGranjero
{
    [Fact]
    public void CuandoCreoUnGranjero_SeDebeCrearConSusDatosCorrectamente()
    {
        float hectareas = 2.3f;
        int cantHijos = 2;

        Granjero granjero = new Granjero(hectareas, cantHijos);

        Assert.Equal(Casta.Jarl, granjero.casta);
        Assert.Equal(2, granjero.cantHijos);
        Assert.Equal(2.3f, granjero.hectareas);
        Assert.False(granjero.productivo);
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

        Assert.True(granjero1.productivo);
    }
    [Fact]
    public void CuandoSetteoUnNuevoValor_DebeCambiarseCorrectamente()
    {
        float hectareas = 12;
        float NuevaHectareas = 14;
        int cantHijos = 3;
        int nuevaCantHijos = 10;

        Granjero granjero = new Granjero(hectareas, cantHijos);

        granjero.SetCantHijos(nuevaCantHijos);
        granjero.SetHectareas(NuevaHectareas);

        Assert.Equal(14, granjero.hectareas);
        Assert.Equal(10, granjero.cantHijos);
    }
    [Fact]
    public void CuandoSuboDeCasta_DebeSubirLaCasta()
    {
        Granjero granjero = new Granjero(12, 3);

        granjero.SubirCasta();

        Assert.Equal(Casta.Karl, granjero.casta);
        granjero.SubirCasta();
        Assert.Equal(Casta.Thrall, granjero.casta);

    }
    [Fact]
    public void CuandoRecibeUnValorNegativoAlgunAtributo_DebeDevolverLaExcepcion()
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