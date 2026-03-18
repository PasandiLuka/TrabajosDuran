using Biblitoteca.Entidades.CastaAbstract;
using Biblitoteca.Entidades.Abstract.VikingosAbstract;

namespace Biblitoteca.Entidades.Abstract.Casta;

public abstract class Casta
{
    public static Casta Jarl { get; } = new JarlCasta();

    public static Casta Karl { get; } = new KarlCasta();

    public static Casta Thrall { get; } = new ThrallCasta();

    public abstract Casta? SubirCasta();

    public abstract bool CanSubirCasta();

    public abstract void AplicarBeneficios(Vikingo vikingo);
}
