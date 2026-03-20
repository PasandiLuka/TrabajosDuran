using AngryBirds.Core.Entidades.Pajaros;
using Xunit;

namespace AngryBirds.Test;

public class TestMatilda
{
    [Fact]
    public void CuandoCreoUnaMatilda_DebeCrearConLosDatosCorrectos()
    {
        int ira = 15;
        Matilda matilda = new Matilda(ira);

        Assert.Equal(ira, matilda.Ira);
        Assert.Empty(matilda.Huevos);
        Assert.Equal(ira * 2, matilda.Fuerza); // Sin huevos
    }

    [Fact]
    public void CuandoMatildaSeEnoja_DebePonerUnHuevo()
    {
        Matilda matilda = new Matilda(10);

        matilda.Enfadarse();

        Assert.Single(matilda.Huevos);
        Assert.Equal(2, matilda.Huevos[0].Peso);
    }

    [Fact]
    public void CuandoMatildaSeEnojaVariasVeces_DebeTenerVariosHuevos()
    {
        Matilda matilda = new Matilda(10);

        matilda.Enfadarse();
        matilda.Enfadarse();
        matilda.Enfadarse();

        Assert.Equal(3, matilda.Huevos.Count);
    }

    [Fact]
    public void MatildaConHuevos_DebeCalcularFuerzaConHuevos()
    {
        Matilda matilda = new Matilda(10);
        matilda.Enfadarse(); // 1 huevo de 2kg

        Assert.Equal(10 * 2 + 2, matilda.Fuerza); // 22
    }

    [Fact]
    public void MatildaConVariosHuevos_DebeSumarFuerzaDeTodos()
    {
        Matilda matilda = new Matilda(5);
        matilda.Enfadarse(); // 1 huevo de 2kg
        matilda.Enfadarse(); // 2 huevos de 2kg
        matilda.AgregarHuevo(new Huevo(5)); // Huevo adicional de 5kg

        // Fuerza = 5*2 + (2 + 2 + 5) = 10 + 9 = 19
        Assert.Equal(19, matilda.Fuerza);
    }
}
