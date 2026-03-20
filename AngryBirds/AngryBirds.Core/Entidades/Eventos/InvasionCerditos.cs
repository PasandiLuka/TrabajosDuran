using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Eventos;

/// <summary>
/// Invasión de cerditos. Enoja a todos los pájaros una vez por cada 100 cerditos que invaden.
/// </summary>
public class InvasionCerditos : IEvento
{
    public int CantidadCerditos { get; private set; }

    public InvasionCerditos(int cantidadCerditos)
    {
        CantidadCerditos = cantidadCerditos;
    }

    public void Aplicar(IslaPajaro isla)
    {
        int vecesEnojar = CantidadCerditos / 100;
        
        for (int i = 0; i < vecesEnojar; i++)
        {
            foreach (var pajaro in isla.Pajaros)
            {
                pajaro.Enfadarse();
            }
        }
    }
}
