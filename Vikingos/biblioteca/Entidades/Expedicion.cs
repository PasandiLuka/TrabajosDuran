using Biblitoteca.Entidades.Abstract;

namespace Biblitoteca.Entidades;

/// <summary>
/// Representa una expedición vikinga compuesta por un grupo de vikingos.
/// Solo los vikingos productivos pueden formar parte de la expedición.
/// </summary>
public class Expedicion
{
    /// <summary>
    /// Obtiene la lista de vikingos que forman parte de la expedición.
    /// </summary>
    public List<Vikingo> Vikingos { get; private set; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Expedicion"/>.
    /// Solo se agregan los vikingos que son productivos.
    /// </summary>
    /// <param name="vikingos">La lista de vikingos para la expedición.</param>
    public Expedicion(List<Vikingo> vikingos)
    {
        Vikingos = new List<Vikingo>();

        foreach (var vikingo in vikingos)
        {
            try
            {
                vikingo.ChequearProductividad();
                if (vikingo.Productivo)
                {
                    Vikingos.Add(vikingo);
                }
            }
            catch
            {
                // Los vikingos no productivos no se agregan a la expedición
            }
        }
    }

    /// <summary>
    /// Realiza una expedición a un lugar específico.
    /// </summary>
    /// <param name="lugar">El lugar a expedicionar.</param>
    /// <returns>
    /// Código de resultado:
    /// 1 - Expedición a capital exitosa
    /// 2 - Expedición a aldea exitosa
    /// 3 - Expedición a capital fallida (no rentable)
    /// 4 - Expedición a aldea fallida (no rentable)
    /// 5 - Expedición mixta parcialmente exitosa
    /// </returns>
    /// <exception cref="ArgumentException">Se lanza cuando la expedición no es rentable.</exception>
    public int RealizarExpedicion(Lugar lugar)
    {
        // Caso: Solo capital
        if (lugar.Capital is not null && lugar.Aldea is null)
        {
            if (lugar.Capital.CantDefensores > Vikingos.Count)
            {
                throw new ArgumentException(
                    "La expedición no es rentable: hay más defensores que vikingos.");
            }

            if (lugar.Capital.BotinTotal() * 3 < Vikingos.Count)
            {
                throw new ArgumentException("La expedición no es rentable.");
            }

            return 1;
        }

        // Caso: Solo aldea
        if (lugar.Aldea is not null && lugar.Capital is null)
        {
            if (lugar.Aldea.Iglesia is not null)
            {
                if (lugar.Aldea.Iglesia.BotinCrucifijos() < 15)
                {
                    throw new ArgumentException(
                        "La expedición no es rentable: el botín de crucifijos es insuficiente.");
                }
            }

            if (lugar.Aldea.Amurallada is not null)
            {
                if (lugar.Aldea.Amurallada.MinimoVikingos > Vikingos.Count)
                {
                    throw new ArgumentException(
                        "La expedición no es rentable: no hay suficientes vikingos para saquear la aldea amurallada.");
                }
            }

            return 2;
        }

        // Caso: Ambos (mixto) - retorna códigos sin lanzar excepción
        if (lugar.Capital is not null)
        {
            if (lugar.Capital.CantDefensores > Vikingos.Count)
            {
                return 3;
            }

            if (lugar.Capital.BotinTotal() * 3 < Vikingos.Count)
            {
                return 3;
            }
        }

        if (lugar.Aldea is not null)
        {
            if (lugar.Aldea.Iglesia is not null)
            {
                if (lugar.Aldea.Iglesia.BotinCrucifijos() < 15)
                {
                    return 4;
                }
            }

            if (lugar.Aldea.Amurallada is not null)
            {
                if (lugar.Aldea.Amurallada.MinimoVikingos > Vikingos.Count)
                {
                    return 4;
                }
            }
        }

        return 5;
    }

    /// <summary>
    /// Agrega un nuevo vikingo a la expedición.
    /// </summary>
    /// <param name="vikingo">El vikingo a agregar.</param>
    /// <exception cref="ArgumentException">Se lanza cuando el vikingo no es productivo.</exception>
    public void AgregarVikingo(Vikingo vikingo)
    {
        vikingo.ChequearProductividad();
        Vikingos.Add(vikingo);
    }

    /// <summary>
    /// Reemplaza la lista de vikingos de la expedición.
    /// </summary>
    /// <param name="vikingos">La nueva lista de vikingos.</param>
    /// <exception cref="ArgumentException">Se lanza cuando algún vikingo no es productivo.</exception>
    public void SetVikingos(List<Vikingo> vikingos)
    {
        foreach (var vikingo in vikingos)
        {
            vikingo.ChequearProductividad();
        }
        Vikingos = vikingos;
    }
}
