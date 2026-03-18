using System.ComponentModel.DataAnnotations;

namespace Biblitoteca.Entidades.Lugares;

public class Capital
{
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de defensores debe ser un valor positivo.")]
    public int CantDefensores { get; private set; }

    [Range(0, float.MaxValue, ErrorMessage = "El botín debe ser un valor positivo.")]
    public float Botin { get; private set; }

    [Range(0.01f, float.MaxValue, ErrorMessage = "La riqueza de la tierra debe ser un valor positivo.")]
    public float RiquezaTierra { get; private set; }

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

    public float BotinTotal()
    {
        return Botin = CantDefensores * RiquezaTierra;
    }

    public void SetCantDefensores(int cantDefensores)
    {
        if (cantDefensores <= 0)
        {
            throw new ArgumentException("La cantidad de defensores debe ser un valor positivo.", nameof(cantDefensores));
        }
        CantDefensores = cantDefensores;
    }

    public void SetBotin(float botin)
    {
        if (botin < 0)
        {
            throw new ArgumentException("El botín debe ser un valor positivo.", nameof(botin));
        }
        Botin = botin;
    }

    public void SetRiquezaTierra(float riquezaTierra)
    {
        if (riquezaTierra <= 0)
        {
            throw new ArgumentException("La riqueza de la tierra debe ser un valor positivo.", nameof(riquezaTierra));
        }
        RiquezaTierra = riquezaTierra;
    }
}
