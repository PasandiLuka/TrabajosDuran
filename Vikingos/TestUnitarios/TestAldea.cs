using Biblitoteca.Entidades.Lugares;
using Xunit;

namespace TestUnitarios;

public class TestAldea
{
    [Fact]
    public void CuandoCreoUnaAldea_DebeCrearseConLosDatosCorrectos()
    {
        Iglesia iglesia = new Iglesia(12);
        Amurallada amurallada = new Amurallada(10);

        Aldea aldea = new Aldea(iglesia);
        Aldea aldea1 = new Aldea(null, amurallada);

        Assert.Equal(12, aldea.Iglesia.Crucifijos);
        Assert.Equal(10, aldea1.Amurallada.MinimoVikingos);
    }

    [Fact]
    public void CuandoCreaUnaAldeaConDosLocaciones_DebeDevolverLaExcepcion()
    {
        Iglesia iglesia = new Iglesia(12);
        Amurallada amurallada = new Amurallada(10);

        Assert.Throws<InvalidOperationException>(() => new Aldea(iglesia, amurallada));
    }

    [Fact]
    public void CuandoCreoUnaAldeaSinNingunaLocacion_DebeDevolverLaExcepcion()
    {
        Assert.Throws<InvalidOperationException>(() => new Aldea(null, null));
        Assert.Throws<InvalidOperationException>(() => new Aldea());
    }
}
