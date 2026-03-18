using Biblitoteca.Entidades.Abstract.VikingosAbstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.VikingosTipo;

namespace Biblitoteca.Entidades.CastaAbstract;

public class ThrallCasta : CastaBase
{
    public override CastaBase? SubirCasta()
    {
        return null;
    }

    public override bool CanSubirCasta()
    {
        return false;
    }

    public override void AplicarBeneficios(Vikingo vikingo)
    {
        // Thrall es la casta máxima, no hay beneficios adicionales
    }
}
