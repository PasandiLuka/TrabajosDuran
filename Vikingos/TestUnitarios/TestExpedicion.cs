using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades;
using Biblitoteca.Entidades.Abstract;
using Biblitoteca.Enum;
using Xunit;

namespace TestUnitarios;

public class TestExpedicion
{
    [Fact]
    public void CuandoCreoUnaExpedicion_DebeCrearseCorrectamenteConUnChequeoDeProductividad()
    {
        Soldado soldado = new Soldado(5);
        
        soldado.SetVidasCobradas(20);
        soldado.SubirCasta();
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        
        Expedicion expedicion = new Expedicion(vikingos);
        System.Console.WriteLine(soldado.casta.ToString());

        Assert.Equal(vikingos.Count, expedicion.vikingos.Count);
    }
    [Fact]
    public void CuandoCreoUnaExpedicionConUnVikingoNoProductivo_NoDebeContarlo()
    {
        Soldado soldadoNoProductivo = new Soldado(5);
        soldadoNoProductivo.SubirCasta();
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldadoNoProductivo,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        
        Assert.Equal(vikingos.Count - 1, expedicion.vikingos.Count);
    }
    [Fact]
    public void CuandoLeAgregoUnNuevoVikingo_SeDebeAgregarCorrectamente()
    {
        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        
        Soldado soldado2 = new Soldado(5);
        soldado2.SubirCasta();
        soldado2.SetVidasCobradas(20);

        Expedicion expedicion = new Expedicion(vikingos);
        expedicion.SetNewVikingo(soldado2);

        Assert.Equal(vikingos.Count + 1, expedicion.vikingos.Count);
    }
    [Fact]
    public void CuandoLeAgregoUnaNuevaListaDeVikingos_DebeReemplazarALaAnteriorCorrectamente()
    {
        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);

        Assert.Equal(vikingos, expedicion.vikingos);

        List<Vikingo> vikingos1 = new List<Vikingo>
        {
            new Granjero(12,5),
            new Granjero(8,3)
        };
        expedicion.SetNewListVikingos(vikingos1);

        Assert.Equal(vikingos1, expedicion.vikingos);
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionConAmbasLocaciones_DebeDevolverElNumero5()
    {
        int cantDefensores = 2;
        float riquezaTierra = 1.2f;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Iglesia iglesia = new Iglesia(12);
        Aldea aldea = new Aldea(iglesia);

        Lugar lugar = new Lugar(capital, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        
        Assert.Equal(5, expedicion.RealizarExpedicion(lugar));
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionSinLosVikingosNecesarios_DebeDevolverLaExcepcion()
    {
        int cantDefensores = 3;
        float riquezaTierra = 1.2f;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Iglesia iglesia = new Iglesia(12);
        Aldea aldea = new Aldea(iglesia);

        Lugar lugar = new Lugar(capital, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        Assert.Throws<ArgumentException>(() => expedicion.RealizarExpedicion(lugar));
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionCuandoLaCapitalNoEsRentable_DebeDevolverLaExcepcion()
    {
        int cantDefensores = 1;
        float riquezaTierra = 1/3;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Lugar lugar = new Lugar(capital, null);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        Assert.Throws<ArgumentException>(() => expedicion.RealizarExpedicion(lugar));
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionQueSuAldeaNoAmuralladaNoEsRentable_DebeDevolverLaExcepcion()
    {

        Iglesia iglesia = new Iglesia(1);
        Aldea aldea = new Aldea(iglesia);

        Lugar lugar = new Lugar(null, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        
        Assert.Throws<ArgumentException>(() => expedicion.RealizarExpedicion(lugar));
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionQueLaAldeaAmuralladaNoEsRentable_DebeDevolverLaExcepcion()
    {

        Amurallada amurallada = new Amurallada(4);
        Aldea aldea = new Aldea(null, amurallada);
        Lugar lugar = new Lugar(null, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);

        Assert.Throws<ArgumentException>(() => expedicion.RealizarExpedicion(lugar));
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionQueSuCapitalEsRentablePeroLaAldeaNo_DebeDevolverElNumero4()
    {
        int cantDefensores = 2;
        float riquezaTierra = 2f;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Iglesia iglesia = new Iglesia(2);
        Aldea aldea = new Aldea(iglesia, null);
        Lugar lugar = new Lugar(capital, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);
        int valor = expedicion.RealizarExpedicion(lugar);

        Assert.Equal(4, valor);
    }
    [Fact]
    public void CuandoRealizoUnaExpedicionQueLaAldeaEsRentablePeroLaCapitalNo_DebeDevolverElNumero3()
    {
        int cantDefensores = 1;
        float riquezaTierra = 1/3;
        Capital capital = new Capital(cantDefensores, riquezaTierra);

        Iglesia iglesia = new Iglesia(12);
        Aldea aldea = new Aldea(iglesia);

        Lugar lugar = new Lugar(capital, aldea);

        Soldado soldado = new Soldado(5);
        soldado.SubirCasta();
        soldado.SetVidasCobradas(20);
        List<Vikingo> vikingos = new List<Vikingo>
        {
            soldado,
            new Granjero(10,4)
        };
        Expedicion expedicion = new Expedicion(vikingos);

        int valor = expedicion.RealizarExpedicion(lugar);
        
        Assert.Equal(3, valor);
    }
}