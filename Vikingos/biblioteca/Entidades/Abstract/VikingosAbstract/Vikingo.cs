using Biblitoteca.Interfaces;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;

namespace Biblitoteca.Entidades.Abstract.VikingosAbstract;

public abstract class Vikingo : IProductividad
{
    public bool Productivo { get; protected set; }

    public CastaBase Casta { get; protected set; }

    protected Vikingo(CastaBase? casta = null, bool productivo = false)
    {
        Casta = casta ?? CastaBase.Jarl;
        Productivo = productivo;
    }

    public void SubirCasta()
    {
        if (!Casta.CanSubirCasta())
        {
            throw new InvalidOperationException("Ha alcanzado la casta máxima, aventurero :D");
        }

        CastaBase nuevaCasta = Casta.SubirCasta()!;
        nuevaCasta.AplicarBeneficios(this);
        Casta = nuevaCasta;
    }

    public abstract void ChequearProductividad();
}
