using Biblitoteca.Entidades.Abstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;

namespace Biblitoteca.Entidades.Castas;

/// <summary>
/// Representa la casta Thrall, la casta máxima de los vikingos.
/// 
/// REFACTORIZACIÓN DE ATRIBUTOS ESTÁTICOS:
/// ----------------------------------------
/// Esta clase es instanciada únicamente por la propiedad estática Casta.Thrall.
/// Al ser una clase concreta que extiende de Casta, hereda los beneficios del
/// patrón Singleton implementado en la clase base.
/// 
/// Funcionamiento:
/// - Cuando se accede a Casta.Thrall, se crea una única instancia de ThrallCasta.
/// - Esta instancia se reutiliza en toda la aplicación para todos los vikingos Thrall.
/// - No es necesario crear nuevas instancias de ThrallCasta manualmente.
/// 
/// Ejemplo:
///   // Forma correcta (usa el singleton):
///   if (vikingo.casta == Casta.Thrall) { ... }
///   
///   // Forma incorrecta (crea instancia nueva innecesaria):
///   if (vikingo.casta == new ThrallCasta()) { ... } // EVITAR
/// </summary>
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
