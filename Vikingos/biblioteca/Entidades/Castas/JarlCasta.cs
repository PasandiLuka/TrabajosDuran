using Biblitoteca.Entidades.Abstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;

namespace Biblitoteca.Entidades.Castas;

/// <summary>
/// Representa la casta Jarl, la casta inicial de los vikingos.
/// 
/// REFACTORIZACIÓN DE ATRIBUTOS ESTÁTICOS:
/// ----------------------------------------
/// Esta clase es instanciada únicamente por la propiedad estática Casta.Jarl.
/// Al ser una clase concreta que extiende de Casta, hereda los beneficios del
/// patrón Singleton implementado en la clase base.
/// 
/// Funcionamiento:
/// - Cuando se accede a Casta.Jarl, se crea una única instancia de JarlCasta.
/// - Esta instancia se reutiliza en toda la aplicación para todos los vikingos Jarl.
/// - No es necesario crear nuevas instancias de JarlCasta manualmente.
/// 
/// Ejemplo:
///   // Forma correcta (usa el singleton):
///   Vikingo v = new Granjero(10, 2, Casta.Jarl);
///   
///   // Forma incorrecta (crea instancia nueva innecesaria):
///   Vikingo v = new Granjero(10, 2, new JarlCasta()); // EVITAR
/// </summary>
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
