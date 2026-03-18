using Biblitoteca.Interfaces;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;

namespace Biblitoteca.Entidades.Abstract;

/// <summary>
/// Clase abstracta que representa un vikingo con su casta y estado de productividad.
/// Implementa la interfaz IProductividad para verificar la productividad de cada tipo de vikingo.
/// </summary>
public abstract class Vikingo : IProductividad
{
    /// <summary>
    /// Indica si el vikingo es productivo.
    /// </summary>
    public bool Productivo { get; protected set; }

    /// <summary>
    /// Obtiene la casta actual del vikingo.
    /// </summary>
    public CastaBase Casta { get; protected set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Vikingo"/>.
    /// </summary>
    /// <param name="casta">La casta inicial del vikingo. Si es null, se asigna Jarl por defecto.</param>
    /// <param name="productivo">Indica si el vikingo es productivo inicialmente.</param>
    protected Vikingo(CastaBase? casta = null, bool productivo = false)
    {
        Casta = casta ?? CastaBase.Jarl;
        Productivo = productivo;
    }

    /// <summary>
    /// Sube al vikingo a la siguiente casta aplicando los beneficios correspondientes.
    /// Lanza una excepción si ya se alcanzó la casta máxima.
    /// </summary>
    /// <exception cref="InvalidOperationException">Se lanza cuando el vikingo ya está en la casta máxima.</exception>
    public void SubirCasta()
    {
        if (!Casta.CanSubirCasta())
        {
            throw new InvalidOperationException("Ha alcanzado la casta máxima, aventurero :D");
        }

        CastaBase nuevaCasta = Casta.SubirCasta()!;
        nuevaCasta.AplicarBeneficios(this);
        Casta = nuevaCasta;
    }

    /// <summary>
    /// Verifica y establece la productividad del vikingo según sus atributos específicos.
    /// Debe ser implementado por cada tipo de vikingo (Soldado, Granjero).
    /// </summary>
    /// <exception cref="ArgumentException">Se lanza cuando el vikingo no cumple los requisitos de productividad.</exception>
    public abstract void ChequearProductividad();
}
