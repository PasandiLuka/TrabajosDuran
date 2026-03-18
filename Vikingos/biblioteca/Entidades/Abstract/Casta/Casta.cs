using Biblitoteca.Entidades.Castas;

namespace Biblitoteca.Entidades.Abstract.Casta;

/// <summary>
/// Clase abstracta que representa la casta de un vikingo.
/// Implementa el patrón Strategy para encapsular el comportamiento de cada casta.
/// 
/// REFACTORIZACIÓN DE ATRIBUTOS ESTÁTICOS:
/// ----------------------------------------
/// Los atributos estáticos Jarl, Karl y Thrall implementan el patrón Singleton.
/// Cada uno proporciona una única instancia de su respectiva casta que se comparte
/// en toda la aplicación. Esto evita crear múltiples objetos de casta innecesarios
/// y garantiza que todas las referencias a una casta apunten al mismo objeto.
/// 
/// Beneficios de esta implementación:
/// 1. Memoria eficiente: Solo una instancia por tipo de casta en toda la aplicación.
/// 2. Consistencia: Todas las referencias a Casta.Jarl apuntan al mismo objeto.
/// 3. Performance: No se crean objetos nuevos cada vez que se necesita una casta.
/// 4. Thread-safe: Las propiedades estáticas son inicializadas de forma segura.
/// 
/// Ejemplo de uso:
///   Vikingo v = new Vikingo(Casta.Jarl);  // Reusa la instancia singleton
///   if (vikingo.casta == Casta.Thrall)    // Compara con la misma instancia
/// </summary>
public abstract class Casta
{
    /// <summary>
    /// Obtiene la instancia singleton de la casta Jarl (casta inicial).
    /// </summary>
    public static Casta Jarl { get; } = new JarlCasta();

    /// <summary>
    /// Obtiene la instancia singleton de la casta Karl (casta intermedia).
    /// </summary>
    public static Casta Karl { get; } = new KarlCasta();

    /// <summary>
    /// Obtiene la instancia singleton de la casta Thrall (casta máxima).
    /// </summary>
    public static Casta Thrall { get; } = new ThrallCasta();

    /// <summary>
    /// Obtiene la instancia de casta superior.
    /// </summary>
    /// <returns>La casta superior, o null si es la máxima.</returns>
    public abstract Casta? SubirCasta();

    /// <summary>
    /// Verifica si se puede subir de casta.
    /// </summary>
    /// <returns>True si hay una casta superior, False si es la máxima.</returns>
    public abstract bool CanSubirCasta();

    /// <summary>
    /// Aplica los beneficios de subir de casta al vikingo.
    /// </summary>
    /// <param name="vikingo">El vikingo que sube de casta.</param>
    public abstract void AplicarBeneficios(Vikingo vikingo);
}
