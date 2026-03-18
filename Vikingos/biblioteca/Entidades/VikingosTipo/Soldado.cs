using System.ComponentModel.DataAnnotations;
using Biblitoteca.Entidades.Abstract.VikingosAbstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.CastaAbstract;

namespace Biblitoteca.Entidades.VikingosTipo;

public class Soldado : Vikingo
{
    [Range(1, int.MaxValue, ErrorMessage = "El arma debe tener un valor positivo.")]
    public int Arma { get; private set; }

    [Range(0, int.MaxValue, ErrorMessage = "Las vidas cobradas deben ser un valor positivo.")]
    public int VidasCobradas { get; private set; }

    public Soldado(int arma, CastaBase? casta = null, bool productivo = false) : base(casta, productivo)
    {
        if (arma < 0)
        {
            throw new ArgumentException("El arma debe tener un valor positivo.", nameof(arma));
        }

        Arma = arma;
        VidasCobradas = 0;
    }

    internal void AplicarBeneficioCasta()
    {
        if (Casta is KarlCasta)
        {
            Arma += 10;
        }
    }

    public override void ChequearProductividad()
    {
        if (Casta is JarlCasta && Arma > 0)
        {
            throw new ArgumentException("El soldado no es productivo: tiene un arma y es un Jarl.");
        }

        if (VidasCobradas < 20)
        {
            throw new ArgumentException("El soldado no es productivo: no ha cobrado suficientes vidas (mínimo 20).");
        }

        Productivo = true;
    }

    public void SetArma(int arma)
    {
        if (arma < 0)
        {
            throw new ArgumentException("El arma debe tener un valor positivo.", nameof(arma));
        }
        Arma = arma;
    }

    public void SetVidasCobradas(int vidasCobradas)
    {
        if (vidasCobradas < 0)
        {
            throw new ArgumentException("Las vidas cobradas deben ser un valor positivo.", nameof(vidasCobradas));
        }
        VidasCobradas = vidasCobradas;
    }

    public void IncrementarVidasCobradas(Soldado soldado)
    {
        soldado.VidasCobradas += 1;
    }
}
