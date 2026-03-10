using Biblitoteca.Enum;
using Biblitoteca.Interfaces;
namespace Biblitoteca.Entidades.Abstract;

public abstract class Vikingo : Productividad
{
    public bool productivo;
    public Casta casta;

    public void SubirCasta()
    {
        if (casta == Casta.Thrall) throw new InvalidOperationException("Ha alcanzado la casta máxima aventurero :D");
        
    }
    public void ChequearProductividad() => throw new NotImplementedException();
}