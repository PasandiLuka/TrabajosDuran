using Biblitoteca.Enum;
using Biblitoteca.Interfaces;
namespace Biblitoteca.Entidades.Abstract;

public abstract class Vikingo : IProductividad
{
    public bool productivo;
    public Casta casta;

    public Vikingo(Casta casta = Casta.Jarl, bool productivo = false)
    {
        this.casta = Casta.Jarl;
        productivo = false;
    }

    public abstract void SubirCasta();
    public abstract void ChequearProductividad();
}