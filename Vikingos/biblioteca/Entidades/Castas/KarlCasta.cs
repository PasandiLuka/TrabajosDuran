using Biblitoteca.Entidades.Abstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;

namespace Biblitoteca.Entidades.Castas;

/// <summary>
/// Representa la casta Karl, la casta intermedia de los vikingos.
/// 
/// REFACTORIZACIÓN DE ATRIBUTOS ESTÁTICOS:
/// ----------------------------------------
/// Esta clase es instanciada únicamente por la propiedad estática Casta.Karl.
/// Al ser una clase concreta que extiende de Casta, hereda los beneficios del
/// patrón Singleton implementado en la clase base.
/// 
/// Funcionamiento:
/// - Cuando se accede a Casta.Karl, se crea una única instancia de KarlCasta.
/// - Esta instancia se reutiliza en toda la aplicación para todos los vikingos Karl.
/// - No es necesario crear nuevas instancias de KarlCasta manualmente.
/// 
/// Ejemplo:
///   // Forma correcta (usa el singleton):
///   Vikingo v = new Soldado(50, Casta.Karl);
///   
///   // Forma incorrecta (crea instancia nueva innecesaria):
///   Vikingo v = new Soldado(50, new KarlCasta()); // EVITAR
/// </summary>
public class KarlCasta : CastaBase
{
    public override CastaBase? SubirCasta()
    {
        return CastaBase.Thrall;
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
