using AngryBirds.Core.Entidades.Eventos;
using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Interfaces;
using Xunit;

namespace AngryBirds.Test;

public class TestEventos
{
    [Fact]
    public void CuandoOcurreSesionManejoIra_DebeDisminuirIraDePajaros()
    {
        IslaPajaro isla = new IslaPajaro();
        PajaroComun pajaro = new PajaroComun(20);
        isla.AgregarPajaro(pajaro);

        SesionManejoIra evento = new SesionManejoIra();
        isla.AplicarEvento(evento);

        Assert.Equal(15, pajaro.Ira);
    }

    [Fact]
    public void CuandoOcurreSesionManejoIra_ChuckNoSeTranquiliza()
    {
        IslaPajaro isla = new IslaPajaro();
        Chuck chuck = new Chuck(50);
        isla.AgregarPajaro(chuck);

        SesionManejoIra evento = new SesionManejoIra();
        isla.AplicarEvento(evento);

        Assert.Equal(50, chuck.Ira);
        Assert.Equal(50, chuck.Velocidad);
    }

    [Fact]
    public void CuandoOcurreInvasionCerditos_DebeEnojarPajaros()
    {
        IslaPajaro isla = new IslaPajaro();
        Red red = new Red(10);
        isla.AgregarPajaro(red);

        InvasionCerditos evento = new InvasionCerditos(300); // 3 veces
        isla.AplicarEvento(evento);

        Assert.Equal(4, red.VecesEnojado); // 1 inicial + 3 por invasion
    }

    [Fact]
    public void CuandoOcurreInvasionCerditos_PocosCerditos_NoEnoja()
    {
        IslaPajaro isla = new IslaPajaro();
        Red red = new Red(10);
        isla.AgregarPajaro(red);

        InvasionCerditos evento = new InvasionCerditos(50); // Menos de 100

        isla.AplicarEvento(evento);

        Assert.Equal(1, red.VecesEnojado);
    }

    [Fact]
    public void CuandoOcurreFiestaSorpresa_ConHomenajeados_DebeEnojarHomenajeados()
    {
        IslaPajaro isla = new IslaPajaro();
        Red red = new Red(10);
        PajaroComun comun = new PajaroComun(20);
        isla.AgregarPajaro(red);
        isla.AgregarPajaro(comun);

        FiestaSorpresa evento = new FiestaSorpresa(new List<IPajaro> { red });
        isla.AplicarEvento(evento);

        Assert.Equal(2, red.VecesEnojado);
        Assert.Equal(20, comun.Ira); // No se enoja
    }

    [Fact]
    public void CuandoOcurreFiestaSorpresa_SinHomenajeados_NoPasaNada()
    {
        IslaPajaro isla = new IslaPajaro();
        Red red = new Red(10);
        isla.AgregarPajaro(red);

        FiestaSorpresa evento = new FiestaSorpresa(new List<IPajaro>());
        isla.AplicarEvento(evento);

        Assert.Equal(1, red.VecesEnojado);
    }

    [Fact]
    public void CuandoOcurreSerieEventos_Desafortunados_DebeAplicarTodos()
    {
        IslaPajaro isla = new IslaPajaro();
        Red red = new Red(10);
        isla.AgregarPajaro(red);

        var eventos = new List<IEvento>
        {
            new InvasionCerditos(100), // Enoja 1 vez
            new SesionManejoIra() // Disminuye ira en 5
        };
        SerieEventosDesafortunados serie = new SerieEventosDesafortunados(eventos);

        isla.AplicarEvento(serie);

        Assert.Equal(2, red.VecesEnojado);
        Assert.Equal(5, red.Ira); // 10 - 5
    }
}
