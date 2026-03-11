using Biblitoteca.Entidades.Abstract;

namespace Biblitoteca.Entidades;
public class Expedicion
{
    public List<Vikingo> vikingos { get; private set; }

    public Expedicion(List<Vikingo> vikingos)
    {
        foreach (var vikingo in vikingos)
        {
            vikingo.ChequearProductividad();
        }
        this.vikingos = vikingos;   
    }

    public void RealizarExpedicion(Lugar lugar)
    {
        if(lugar.capital.cantDefensores > vikingos.Count) throw new ArgumentException("La expedición no es rentable, hay más defensores que vikingos");
        if(lugar.capital.BotinTotal() * 3 < vikingos.Count) throw new ArgumentException("La expedición no es rentable");

        if (lugar.aldea.iglesia is not null)
        {
            if(lugar.aldea.iglesia.botinCrucifijos() < 15) throw new ArgumentException("La expedición no es rentable, el botín de crucifijos es insuficiente");
            Console.WriteLine();
        }
        if (lugar.aldea.amurallada is not null)
        {
            if(lugar.aldea.amurallada.minimoVikingos > vikingos.Count) throw new ArgumentException("La expedición no es rentable, no hay suficientes vikingos para saquear la aldea amurallada");
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