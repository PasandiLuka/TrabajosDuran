using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades;
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
        
        Assert.Equal(12, aldea.iglesia.crucifijos);
        Assert.Equal(10, aldea1.amurallada.minimoVikingos);
    }
    [Fact]
    public void CuandoCreaUnaAldeaConDosLocaciones_DebeDevolverLaExcepcion()
    {
        Iglesia iglesia = new Iglesia(12);
        Amurallada amurallada = new Amurallada(10);

        Assert.Throws<InvalidOperationException>(() => new Aldea(iglesia, amurallada));
    }
    [Fact]
    public void CuandoCreoUnaAldeaSinNingunaLocacion_DebeDevlverLaExcepcion()
    {
        Assert.Throws<InvalidOperationException>(() => new Aldea(null, null));
        Assert.Throws<InvalidOperationException>(() => new Aldea());
    }
}