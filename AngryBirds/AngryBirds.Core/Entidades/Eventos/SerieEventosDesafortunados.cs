using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Eventos;

/// <summary>
/// Serie de eventos desafortunados. Suceden varios eventos secuencialmente.
/// </summary>
public class SerieEventosDesafortunados : IEvento
{
    public List<IEvento> Eventos { get; private set; }

    public SerieEventosDesafortunados(List<IEvento> eventos)
    {
        Eventos = eventos;
    }

    public void Aplicar(IslaPajaro isla)
    {
        foreach (var evento in Eventos)
        {
            evento.Aplicar(isla);
        }
    }
}
