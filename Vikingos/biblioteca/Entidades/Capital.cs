using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa una capital que puede ser saqueada por una expedición vikinga.
/// </summary>
public class Capital
{
    /// <summary>
    /// Obtiene o establece la cantidad de defensores de la capital.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de defensores debe ser un valor positivo.")]
    public int CantDefensores { get; private set; }

    /// <summary>
    /// Obtiene o establece el botín actual de la capital.
    /// </summary>
    [Range(0, float.MaxValue, ErrorMessage = "El botín debe ser un valor positivo.")]
    public float Botin { get; private set; }

    /// <summary>
    /// Obtiene o establece la riqueza de la tierra de la capital.
    /// Debe ser un valor positivo.
    /// </summary>
    [Range(0.01f, float.MaxValue, ErrorMessage = "La riqueza de la tierra debe ser un valor positivo.")]
    public float RiquezaTierra { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Capital"/>.
    /// </summary>
    /// <param name="cantDefensores">La cantidad de defensores de la capital.</param>
    /// <param name="riquezaTierra">La riqueza de la tierra de la capital.</param>
    /// <exception cref="ArgumentException">Se lanza cuando los parámetros tienen valores inválidos.</exception>
    public Capital(int cantDefensores, float riquezaTierra)
    {
        if (cantDefensores <= 0)
        {
            throw new ArgumentException("La cantidad de defensores debe ser un valor positivo.", nameof(cantDefensores));
        }

        if (riquezaTierra <= 0)
        {
            throw new ArgumentException("La riqueza de la tierra debe ser un valor positivo.", nameof(riquezaTierra));
        }

        CantDefensores = cantDefensores;
        RiquezaTierra = riquezaTierra;
        Botin = 0;
    }

    /// <summary>
    /// Calcula el botín total de la capital.
    /// </summary>
    /// <returns>El botín total (cantidad de defensores * riqueza de la tierra).</returns>
    public float BotinTotal()
    {
        return Botin = CantDefensores * RiquezaTierra;
    }

    /// <summary>
    /// Establece una nueva cantidad de defensores.
    /// </summary>
    /// <param name="cantDefensores">La nueva cantidad de defensores.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetCantDefensores(int cantDefensores)
    {
        if (cantDefensores <= 0)
        {
            throw new ArgumentException("La cantidad de defensores debe ser un valor positivo.", nameof(cantDefensores));
        }
        CantDefensores = cantDefensores;
    }

    /// <summary>
    /// Establece un nuevo valor para el botín.
    /// </summary>
    /// <param name="botin">El nuevo valor del botín.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetBotin(float botin)
    {
        if (botin < 0)
        {
            throw new ArgumentException("El botín debe ser un valor positivo.", nameof(botin));
        }
        Botin = botin;
    }

    /// <summary>
    /// Establece un nuevo valor para la riqueza de la tierra.
    /// </summary>
    /// <param name="riquezaTierra">El nuevo valor de la riqueza de la tierra.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el valor es negativo.</exception>
    public void SetRiquezaTierra(float riquezaTierra)
    {
        if (riquezaTierra <= 0)
        {
            throw new ArgumentException("La riqueza de la tierra debe ser un valor positivo.", nameof(riquezaTierra));
        }
        RiquezaTierra = riquezaTierra;
    }
}
