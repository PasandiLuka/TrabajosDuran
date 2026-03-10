using Biblitoteca.Enum;
using Biblitoteca.Interfaces;
namespace Biblitoteca.Entidades.Abstract;

public abstract class Vikingo : Productividad
{
    public bool productivo;
    public Casta casta;

    public void ChequearProductividad() => throw new NotImplementedException();
}