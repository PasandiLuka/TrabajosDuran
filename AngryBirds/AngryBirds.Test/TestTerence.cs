using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestTerence
{
    [Fact]
    public void CuandoCreoUnTerence_DebeCrearConLosDatosCorrectos()
    {
        int ira = 20;
        Terence terence = new Terence(ira);

        Assert.Equal(ira, terence.Ira);
        Assert.Equal(1, terence.VecesEnojado);
        Assert.Equal(1, terence.Multiplicador);
        Assert.Equal(ira * 1 * 1, terence.Fuerza);
    }

    [Fact]
    public void CuandoTerenceSeEnoja_DebeIncrementarVecesEnojado()
    {
        Terence terence = new Terence(10);

        terence.Enfadarse();

        Assert.Equal(2, terence.VecesEnojado);
        Assert.Equal(10 * 2 * 1, terence.Fuerza);
    }

    [Fact]
    public void CuandoSeteoMultiplicador_DebeActualizarFuerza()
    {
        Terence terence = new Terence(10, 2);

        terence.SetMultiplicador(3);

        Assert.Equal(3, terence.Multiplicador);
        Assert.Equal(10 * 1 * 3, terence.Fuerza);
    }

    [Fact]
    public void CuandoSeteoMultiplicadorInvalido_DebeArrojarExcepcion()
    {
        Terence terence = new Terence(10);

        Assert.Throws<ArgumentException>(() => terence.SetMultiplicador(0));
        Assert.Throws<ArgumentException>(() => terence.SetMultiplicador(-5));
    }

    [Fact]
    public void TerenceConMultiplicadorYEnojo_DebeCalcularFuerzaCorrectamente()
    {
        Terence terence = new Terence(5, 3);
        terence.Enfadarse();
        terence.Enfadarse();

        Assert.Equal(3, terence.VecesEnojado);
        Assert.Equal(5 * 3 * 3, terence.Fuerza); // 45
    }
}
