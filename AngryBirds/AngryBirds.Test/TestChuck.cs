using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestChuck
{
    [Fact]
    public void CuandoCreoUnChuck_DebeCrearConLosDatosCorrectos()
    {
        int velocidad = 50;
        Chuck chuck = new Chuck(velocidad);

        Assert.Equal(velocidad, chuck.Velocidad);
        Assert.Equal(150, chuck.Fuerza); // <= 80 km/h
    }

    [Fact]
    public void CuandoVelocidadEs80_DebeTenerFuerza150()
    {
        Chuck chuck = new Chuck(80);

        Assert.Equal(150, chuck.Fuerza);
    }

    [Fact]
    public void CuandoVelocidadSupera80_DebeCalcularFuerzaAdicional()
    {
        Chuck chuck = new Chuck(90); // 10 km/h por encima de 80

        Assert.Equal(150 + 5 * 10, chuck.Fuerza); // 200
    }

    [Fact]
    public void CuandoChuckSeEnoja_DebeDuplicarVelocidad()
    {
        Chuck chuck = new Chuck(50);

        chuck.Enfadarse();

        Assert.Equal(100, chuck.Velocidad);
        Assert.Equal(150 + 5 * 20, chuck.Fuerza); // 250
    }

    [Fact]
    public void CuandoChuckSeEnojaConVelocidadAlta_DebeCalcularCorrecto()
    {
        Chuck chuck = new Chuck(60);
        chuck.Enfadarse(); // Velocidad = 120

        Assert.Equal(120, chuck.Velocidad);
        Assert.Equal(150 + 5 * 40, chuck.Fuerza); // 350
    }
}
