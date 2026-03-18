using System.ComponentModel.DataAnnotations;
using Biblitoteca.Entidades.Abstract;
using CastaBase = Biblitoteca.Entidades.Abstract.Casta.Casta;
using Biblitoteca.Entidades.Castas;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa un vikingo de tipo Soldado.
/// Los soldados son productivos cuando han cobrado al menos 20 vidas.
/// </summary>
public class Soldado : Vikingo
{
    /// <summary>
    /// Obtiene o establece el nivel del arma del soldado.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "El arma debe tener un valor positivo.")]
    public int Arma { get; private set; }

    /// <summary>
    /// Obtiene o establece la cantidad de vidas cobradas por el soldado.
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "Las vidas cobradas deben ser un valor positivo.")]
    public int VidasCobradas { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Soldado"/>.
    /// </summary>
    /// <param name="arma">El nivel del arma del soldado.</param>
    /// <param name="casta">La casta inicial del soldado. Por defecto es Jarl.</param>
    /// <param name="productivo">Indica si el soldado es productivo inicialmente.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el arma tiene un valor negativo.</exception>
    public Soldado(int arma, CastaBase? casta = null, bool productivo = false) : base(casta, productivo)
    {
        if (arma < 0)
        {
            throw new ArgumentException("El arma debe tener un valor positivo.", nameof(arma));
        }

        Arma = arma;
        VidasCobradas = 0;
    }

    /// <summary>
    /// Aplica los beneficios de subir de casta al soldado.
    /// Solo aplica cuando sube de Jarl a Karl, incrementando el arma en 10 puntos.
    /// </summary>
    internal void AplicarBeneficioCasta()
    {
        if (Casta is KarlCasta)
        {
            Arma += 10;
        }
    }

    /// <summary>
    /// Verifica la productividad del soldado.
    /// Un soldado es productivo si ha cobrado al menos 20 vidas.
    /// Un soldado Jarl no puede tener un arma mayor a 0.
    /// </summary>
    /// <exception cref="ArgumentException">Se lanza cuando el soldado no cumple los requisitos de productividad.</exception>
    public override void ChequearProductividad()
    {
        if (Casta is JarlCasta && Arma > 0)
        {
            throw new ArgumentException("El soldado no es productivo: tiene un arma y es un Jarl.");
        }

        if (VidasCobradas < 20)
        {
            throw new ArgumentException("El soldado no es productivo: no ha cobrado suficientes vidas (mínimo 20).");
        }

        Productivo = true;
    }

    /// <summary>
    /// Establece un nuevo valor para el arma del soldado.
    /// </summary>
    /// <param name="arma">El nuevo valor del arma.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el arma tiene un valor negativo.</exception>
    public void SetArma(int arma)
    {
        if (arma < 0)
        {
            throw new ArgumentException("El arma debe tener un valor positivo.", nameof(arma));
        }
        Arma = arma;
    }

    /// <summary>
    /// Establece un nuevo valor para las vidas cobradas.
    /// </summary>
    /// <param name="vidasCobradas">La nueva cantidad de vidas cobradas.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetVidasCobradas(int vidasCobradas)
    {
        if (vidasCobradas < 0)
        {
            throw new ArgumentException("Las vidas cobradas deben ser un valor positivo.", nameof(vidasCobradas));
        }
        VidasCobradas = vidasCobradas;
    }

    /// <summary>
    /// Incrementa en 1 las vidas cobradas de otro soldado.
    /// </summary>
    /// <param name="soldado">El soldado al que se le incrementan las vidas cobradas.</param>
    public void IncrementarVidasCobradas(Soldado soldado)
    {
        soldado.VidasCobradas += 1;
    }
}
