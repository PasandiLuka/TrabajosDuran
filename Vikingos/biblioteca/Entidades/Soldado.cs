using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblitoteca.Entidades.Abstract;
using Biblitoteca.Enum;

namespace Biblitoteca.Entidades;

public class Soldado : Vikingo
{
    public int arma { get; set; }
    public int vidasCobradas { get; set; }

    public Soldado(Casta casta, bool productivo) : base(casta, productivo)
    {
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
}
