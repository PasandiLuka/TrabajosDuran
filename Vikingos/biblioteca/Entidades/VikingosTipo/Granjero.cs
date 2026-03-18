using System.ComponentModel.DataAnnotations;
using Biblitoteca.Entidades.Abstract.VikingosAbstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.CastaAbstract;

namespace Biblitoteca.Entidades.VikingosTipo;

public class Granjero : Vikingo
{
    [Range(0.01f, float.MaxValue, ErrorMessage = "Las hectáreas deben tener un valor positivo.")]
    public float Hectareas { get; private set; }

    [Range(0, int.MaxValue, ErrorMessage = "La cantidad de hijos debe ser un valor positivo.")]
    public int CantHijos { get; private set; }

    public Granjero(float hectareas, int cantHijos, CastaBase? casta = null, bool productivo = false) : base(casta, productivo)
    {
        if (hectareas <= 0)
        {
            throw new ArgumentException("Las hectáreas deben tener un valor positivo.", nameof(hectareas));
        }

        if (cantHijos < 0)
        {
            throw new ArgumentException("La cantidad de hijos debe ser un valor positivo.", nameof(cantHijos));
        }

        Hectareas = hectareas;
        CantHijos = cantHijos;
    }

    internal void AplicarBeneficioCasta()
    {
        if (Casta is KarlCasta)
        {
            Hectareas += 2;
            CantHijos += 2;
        }
    }

    public override void ChequearProductividad()
    {
        if (Hectareas < CantHijos * 2)
        {
            throw new ArgumentException(
                "El granjero no es productivo: no tiene suficientes hectáreas por hijo (mínimo 2 por hijo).");
        }

        Productivo = true;
    }

    public void SetHectareas(float hectareas)
    {
        if (hectareas <= 0)
        {
            throw new ArgumentException("Las hectáreas deben tener un valor positivo.", nameof(hectareas));
        }
        Hectareas = hectareas;
    }

    public void SetCantHijos(int cantHijos)
    {
        if (cantHijos < 0)
        {
            throw new ArgumentException("La cantidad de hijos debe ser un valor positivo.", nameof(cantHijos));
        }
        CantHijos = cantHijos;
    }
}
