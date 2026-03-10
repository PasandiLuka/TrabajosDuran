using Biblitoteca.Enum;
using Biblitoteca.Interfaces;
namespace Biblitoteca.Entidades.Abstract;

public abstract class Vikingo : IProductividad
{
    public bool productivo;
    public Casta casta;

    public abstract void SubirCasta();
    public abstract void ChequearProductividad();

    public Vikingo(Casta casta, bool productivo)
    {
        
    }
}