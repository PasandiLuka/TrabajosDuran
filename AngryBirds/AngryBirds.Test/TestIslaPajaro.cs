using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Entidades.Obstaculos;
using Xunit;

namespace AngryBirds.Test;

public class TestIslaPajaro
{
    [Fact]
    public void CuandoCreoUnaIslaPajaro_DebeCrearConListaVacia()
    {
        IslaPajaro isla = new IslaPajaro();

        Assert.Equal("Isla Pájaro", isla.Nombre);
        Assert.Empty(isla.Pajaros);
        Assert.Empty(isla.PajarosFuertes);
        Assert.Equal(0, isla.FuerzaTotal);
    }

    [Fact]
    public void CuandoAgregoPajaros_DebeTenerlosEnLaLista()
    {
        IslaPajaro isla = new IslaPajaro();
        isla.AgregarPajaro(new PajaroComun(30));
        isla.AgregarPajaro(new Red(10));

        Assert.Equal(2, isla.Pajaros.Count);
    }

    [Fact]
    public void CuandoHayPajarosFuertes_DebeDevolverSoloFuertes()
    {
        IslaPajaro isla = new IslaPajaro();
        isla.AgregarPajaro(new PajaroComun(30)); // Fuerza = 60, fuerte
        isla.AgregarPajaro(new PajaroComun(10)); // Fuerza = 20, no fuerte

        Assert.Single(isla.PajarosFuertes);
    }

    [Fact]
    public void CuandoHayPajarosFuertes_DebeCalcularFuerzaTotal()
    {
        IslaPajaro isla = new IslaPajaro();
        isla.AgregarPajaro(new PajaroComun(30)); // Fuerza = 60
        isla.AgregarPajaro(new PajaroComun(40)); // Fuerza = 80

        Assert.Equal(140, isla.FuerzaTotal);
    }

    [Fact]
    public void CuandoIslaAtacaCerdito_DebeEnviarPajaros()
    {
        IslaPajaro islaPajaro = new IslaPajaro();
        islaPajaro.AgregarPajaro(new PajaroComun(30));
        
        IslaCerdito islaCerdito = new IslaCerdito();
        islaCerdito.AgregarObstaculo(new CerditoObrero());

        islaPajaro.Atacar(islaCerdito);

        // El pajaro debe haber atacado el obstaculo
        var obstaculo = islaCerdito.Obstaculos[0];
        Assert.False(obstaculo.EstaEnPie); // 60 > 50
    }
}
