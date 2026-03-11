using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Biblitoteca.Entidades.Abstract;
using Biblitoteca.Enum;

namespace Biblitoteca.Entidades;

public class Granjero : Vikingo
{
    public float hectareas { get; set; }
    public int cantHijos { get; set; } 
    public Granjero(Casta casta, bool productivo)   : base (casta, productivo)
    {
        
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
                hectareas += 2;
                cantHijos += 2;
            } break;
        }
    }

    public override void ChequearProductividad()
    {
        if(hectareas >= cantHijos * 2) productivo = true;
        else throw new ArgumentException("El granjero no es productivo, no tiene suficientes hectareas por hijo");
    }

}
