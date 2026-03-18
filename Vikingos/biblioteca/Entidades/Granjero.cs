using System.ComponentModel.DataAnnotations;
using Biblitoteca.Entidades.Abstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.Castas;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa un vikingo de tipo Granjero.
/// Los granjeros son productivos cuando tienen al menos 2 hectáreas por hijo.
/// </summary>
public class Granjero : Vikingo
{
    /// <summary>
    /// Obtiene o establece la cantidad de hectáreas que posee el granjero.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(0.01f, float.MaxValue, ErrorMessage = "Las hectáreas deben tener un valor positivo.")]
    public float Hectareas { get; private set; }

    /// <summary>
    /// Obtiene o establece la cantidad de hijos del granjero.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad de hijos debe ser un valor positivo.")]
    public int CantHijos { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Granjero"/>.
    /// </summary>
    /// <param name="hectareas">La cantidad de hectáreas que posee el granjero.</param>
    /// <param name="cantHijos">La cantidad de hijos del granjero.</param>
    /// <param name="casta">La casta inicial del granjero. Por defecto es Jarl.</param>
    /// <param name="productivo">Indica si el granjero es productivo inicialmente.</param>
    /// <exception cref="ArgumentException">Se lanza cuando hectáreas o cantidad de hijos son negativos.</exception>
    public Granjero(float hectareas, int cantHijos, CastaBase? casta = null, bool productivo = false) : base(casta, productivo)
    {
        if (hectareas <= 0)
        {
            throw new ArgumentException("Las hectáreas deben tener un valor positivo.", nameof(hectareas));
        }

        if (cantHijos < 0)
        {
            throw new ArgumentException("La cantidad de hijos debe ser un valor positivo.", nameof(cantHijos));
        }

        Hectareas = hectareas;
        CantHijos = cantHijos;
    }

    /// <summary>
    /// Aplica los beneficios de subir de casta al granjero.
    /// Incrementa 2 hectáreas y 2 hijos cuando sube de Jarl a Karl.
    /// </summary>
    internal void AplicarBeneficioCasta()
    {
        if (Casta is KarlCasta)
        {
            Hectareas += 2;
            CantHijos += 2;
        }
    }

    /// <summary>
    /// Verifica la productividad del granjero.
    /// Un granjero es productivo cuando tiene al menos 2 hectáreas por hijo.
    /// </summary>
    /// <exception cref="ArgumentException">Se lanza cuando el granjero no tiene suficientes hectáreas por hijo.</exception>
    public override void ChequearProductividad()
    {
        if (Hectareas < CantHijos * 2)
        {
            throw new ArgumentException(
                "El granjero no es productivo: no tiene suficientes hectáreas por hijo (mínimo 2 por hijo).");
        }

        Productivo = true;
    }

    /// <summary>
    /// Establece un nuevo valor para las hectáreas.
    /// </summary>
    /// <param name="hectareas">La nueva cantidad de hectáreas.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetHectareas(float hectareas)
    {
        if (hectareas <= 0)
        {
            throw new ArgumentException("Las hectáreas deben tener un valor positivo.", nameof(hectareas));
        }
        Hectareas = hectareas;
    }

    /// <summary>
    /// Establece un nuevo valor para la cantidad de hijos.
    /// </summary>
    /// <param name="cantHijos">La nueva cantidad de hijos.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetCantHijos(int cantHijos)
    {
        if (cantHijos < 0)
        {
            throw new ArgumentException("La cantidad de hijos debe ser un valor positivo.", nameof(cantHijos));
        }
        CantHijos = cantHijos;
    }
}
