using Biblitoteca.Entidades.Abstract.VikingosAbstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.VikingosTipo;

namespace Biblitoteca.Entidades.CastaAbstract;

public class JarlCasta : CastaBase
{
    public override CastaBase? SubirCasta()
    {
        return CastaBase.Karl;
    }

    public override bool CanSubirCasta()
    {
        return true;
    }

    public override void AplicarBeneficios(Vikingo vikingo)
    {
        if (vikingo is Soldado soldado)
        {
            soldado.AplicarBeneficioCasta();
        }
        else if (vikingo is Granjero granjero)
        {
            granjero.AplicarBeneficioCasta();
        }
    }
}
