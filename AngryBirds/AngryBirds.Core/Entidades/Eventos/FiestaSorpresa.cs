using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Eventos;

/// <summary>
/// Fiesta sorpresa. Hace enojar solamente a los homenajeados.
/// </summary>
public class FiestaSorpresa : IEvento
{
    public List<IPajaro> Homenajeados { get; private set; }

    public FiestaSorpresa(List<IPajaro> homenajeados)
    {
        Homenajeados = homenajeados;
    }

    public void Aplicar(IslaPajaro isla)
    {
        if (Homenajeados == null || Homenajeados.Count == 0)
        {
            return; // No pasa nada si no hay homenajeados
        }

        foreach (var homenajeado in Homenajeados)
        {
            homenajeado.Enfadarse();
        }
    }
}
