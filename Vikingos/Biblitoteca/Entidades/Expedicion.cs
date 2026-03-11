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
        if(lugar.capital.botin * 3 < vikingos.Count) 
    }
}