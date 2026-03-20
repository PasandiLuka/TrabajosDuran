using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestRed
{
    [Fact]
    public void CuandoCreoUnRed_DebeCrearConLosDatosCorrectos()
    {
        int ira = 10;
        Red red = new Red(ira);

        Assert.Equal(ira, red.Ira);
        Assert.Equal(1, red.VecesEnojado);
        Assert.Equal(ira * 10 * 1, red.Fuerza); // 100
        Assert.True(red.EsFuerte); // 100 > 50
    }

    [Fact]
    public void CuandoRedSeEnoja_DebeIncrementarVecesEnojado()
    {
        Red red = new Red(10);

        red.Enfadarse();

        Assert.Equal(2, red.VecesEnojado);
        Assert.Equal(10 * 10 * 2, red.Fuerza);
    }

    [Fact]
    public void CuandoRedSeEnojaVariasVeces_DebeCalcularFuerzaCorrectamente()
    {
        Red red = new Red(5);

        red.Enfadarse();
        red.Enfadarse();
        red.Enfadarse();

        Assert.Equal(4, red.VecesEnojado);
        Assert.Equal(5 * 10 * 4, red.Fuerza);
    }

    [Fact]
    public void RedConIraSuficiente_DebeSerFuerte()
    {
        Red red = new Red(1);
        red.Enfadarse(); // VecesEnojado = 2, Fuerza = 1 * 10 * 2 = 20
        red.Enfadarse(); // VecesEnojado = 3, Fuerza = 1 * 10 * 3 = 30
        red.Enfadarse(); // VecesEnojado = 4, Fuerza = 1 * 10 * 4 = 40
        red.Enfadarse(); // VecesEnojado = 5, Fuerza = 1 * 10 * 5 = 50
        red.Enfadarse(); // VecesEnojado = 6, Fuerza = 1 * 10 * 6 = 60

        Assert.True(red.EsFuerte);
    }
}
