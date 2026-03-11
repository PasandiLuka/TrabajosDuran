using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades.Abstract;
using Biblitoteca.Enum;

namespace Biblitoteca.Entidades;

public class Soldado : Vikingo
{
    public int arma { get; private set; }
    public int vidasCobradas { get; private set; }

    public Soldado(int arma, Casta casta, bool productivo) : base(casta, productivo)
    {
        Validador.EnteroPositivo(arma, "arma");
        this.arma = arma;
        this.vidasCobradas = 0;
    }
    public override void ChequearProductividad()
    {
        if(casta == Casta.Jarl && arma > 0) throw new ArgumentException("El soldado no es productivo, tiene un arma y es un Jarl");
        if(vidasCobradas < 20) throw new ArgumentException("El soldado no es productivo, no ha cobrado suficientes vidas");
        productivo = true;
    }

    public override void SubirCasta()
    {
        switch (casta)
        {
            case Casta.Thrall:
                throw new InvalidOperationException("Ha alcanzado la casta máxima aventurero :D");
            case Casta.Karl: casta = Casta.Thrall; break;
            case Casta.Jarl: {
                casta = Casta.Karl;
                arma += 10;
                } break;
        }
    }

    //SETTERS
    public void SetArmas(int _arma)
    {
        Validador.EnteroPositivo(_arma, "arma");
        arma = _arma;
    }
    public void SetVidasCobradas(int _vidasCobradas)
    {
        Validador.EnteroPositivo(_vidasCobradas, "vidasCobradas");
    }
}
