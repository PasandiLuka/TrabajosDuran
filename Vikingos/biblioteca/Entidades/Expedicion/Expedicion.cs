using Biblitoteca.Entidades.Abstract.VikingosAbstract;
using Biblitoteca.Entidades.Lugares;

namespace Biblitoteca.Entidades.Expedicion;

public class Expedicion
{
    public List<Vikingo> Vikingos { get; private set; }

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

    public void AgregarVikingo(Vikingo vikingo)
    {
        vikingo.ChequearProductividad();
        Vikingos.Add(vikingo);
    }

    public void SetVikingos(List<Vikingo> vikingos)
    {
        foreach (var vikingo in vikingos)
        {
            vikingo.ChequearProductividad();
        }
        Vikingos = vikingos;
    }
}
