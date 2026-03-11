using Biblitoteca.Entidades.Abstract;

namespace Biblitoteca.Entidades;
public class Expedicion
{
    public List<Vikingo> vikingos;
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

    }
}