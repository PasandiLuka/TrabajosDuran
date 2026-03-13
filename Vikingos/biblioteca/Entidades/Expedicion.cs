using Biblitoteca.Entidades.Abstract;

namespace Biblitoteca.Entidades;
public class Expedicion
{
    public List<Vikingo> vikingos { get; private set; }

    public Expedicion(List<Vikingo> Vikingos)
    {
        vikingos = new List<Vikingo>();

        foreach (var vikingo in Vikingos)
        {
            try
            {
                vikingo.ChequearProductividad();
                if (vikingo.productivo)
                    vikingos.Add(vikingo);
            }
            catch
            {}
        }
    }

    public int RealizarExpedicion(Lugar lugar)
    {
        if (lugar.capital is not null && lugar.aldea is null)
        {
            if(lugar.capital.cantDefensores > vikingos.Count) throw new ArgumentException("La expedición no es rentable, hay más defensores que vikingos");
            if(lugar.capital.BotinTotal() * 3 < vikingos.Count) throw new ArgumentException("La expedición no es rentable");

            return 1;
        }
        else if (lugar.aldea is not null && lugar.capital is null)
        {
            if (lugar.aldea.iglesia is not null)
            {
                if(lugar.aldea.iglesia.botinCrucifijos() < 15) throw new ArgumentException("La expedición no es rentable, el botín de crucifijos es insuficiente");
                Console.WriteLine();
            }
            if (lugar.aldea.amurallada is not null)
            {
                if(lugar.aldea.amurallada.minimoVikingos > vikingos.Count) throw new ArgumentException("La expedición no es rentable, no hay suficientes vikingos para saquear la aldea amurallada");
            }
            return 2;
        }
        else
        {
            if(lugar.capital.cantDefensores > vikingos.Count) return 3;
            if(lugar.capital.BotinTotal() * 3 < vikingos.Count) return 3;

            if (lugar.aldea.iglesia is not null)
            {
                if(lugar.aldea.iglesia.botinCrucifijos() < 15) return 4;
            }
            if (lugar.aldea.amurallada is not null)
            {
                if(lugar.aldea.amurallada.minimoVikingos > vikingos.Count) return 4;
            }
            return 5;
        }
    }

    //SETTERS
    public void SetNewVikingo(Vikingo _vikingo)
    {
        _vikingo.ChequearProductividad();
        vikingos.Add(_vikingo);
    }
    public void SetNewListVikingos(List<Vikingo> _vikingos)
    {
        foreach (var vikingo in _vikingos)
        {
            vikingo.ChequearProductividad();
        }
        vikingos = _vikingos;
    }
}