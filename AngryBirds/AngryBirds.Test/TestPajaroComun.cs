using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestPajaroComun
{
    [Fact]
    public void CuandoCreoUnPajaroComun_DebeCrearConLosDatosCorrectos()
    {
        int ira = 20;
        PajaroComun pajaro = new PajaroComun(ira);

        Assert.Equal(ira, pajaro.Ira);
        Assert.Equal(ira * 2, pajaro.Fuerza);
    }

    [Fact]
    public void CuandoPajaroComunSeEnoja_DebeDuplicarIra()
    {
        PajaroComun pajaro = new PajaroComun(15);

        pajaro.Enfadarse();

        Assert.Equal(30, pajaro.Ira);
        Assert.Equal(60, pajaro.Fuerza);
    }

    [Fact]
    public void PajaroComunConIraMayorA25_DebeSerFuerte()
    {
        PajaroComun pajaro = new PajaroComun(26);

        Assert.True(pajaro.EsFuerte);
    }

    [Fact]
    public void PajaroComunConIraMenorOIgualA25_NoDebeSerFuerte()
    {
        PajaroComun pajaro = new PajaroComun(25);

        Assert.False(pajaro.EsFuerte);
    }
}
