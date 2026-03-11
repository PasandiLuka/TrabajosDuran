using Biblitoteca.Entidades;
using Biblitoteca.Enum;

namespace TestUnitarios
{
    public class TestGranjero
    {
        [Fact]
        public void CuandoCreoUnSoldado_SeDebeCrearCorrectamente()
        {
            float hectareas = 2.3f;
            int cantHijos = 2;

            Granjero granjero = new Granjero(hectareas, cantHijos);
            Assert.Equal(Casta.Jarl, granjero.casta);
            Assert.Equal(2, granjero.cantHijos);
            Assert.Equal(2.3f, granjero.hectareas);
        }
    }
}