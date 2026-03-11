using Biblitoteca.Entidades.Abstract;
using Biblitoteca.Enum;

namespace Biblitoteca.Entidades;

public class Granjero : Vikingo
{
    public float hectareas { get; private set; }
    public int cantHijos { get; private set; } 
    public Granjero(float hectareas, int cantHijos, Casta casta, bool productivo) : base (casta, productivo)
    {
        Validador.FloatPositivo(hectareas, "El parametro'hectareas' debe ser positivo.");
        Validador.EnteroPositivo(cantHijos, " El parametro 'cantHijos' debe ser positivo.");
        this.hectareas = hectareas;
        this.cantHijos = cantHijos;
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

    //SETTERS
    public void SetHectareas(float _hectareas)
    {
        Validador.FloatPositivo(_hectareas, "hectareas");
        hectareas = _hectareas;
    }
    public void SetCantHijos(int _cantHijos)
    {
        Validador.EnteroPositivo(_cantHijos, "cantHijos");
        cantHijos = _cantHijos;
    }

}