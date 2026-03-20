using AngryBirds.Core.Entidades.Islas;
using AngryBirds.Core.Entidades.Pajaros;
using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Eventos;

/// <summary>
/// Sesión de manejo de la ira con Matilda. Tranquiliza a todos los pájaros disminuyendo su ira en 5 unidades.
/// Chuck nada lo tranquiliza.
/// </summary>
public class SesionManejoIra : IEvento
{
    public void Aplicar(IslaPajaro isla)
    {
        foreach (var pajaro in isla.Pajaros)
        {
            if (pajaro is Chuck)
            {
                continue; // Chuck no se tranquiliza
            }

            if (pajaro is PajaroComun p)
            {
                p.Ira = Math.Max(0, p.Ira - 5);
            }
            else if (pajaro is Red r)
            {
                r.Ira = Math.Max(0, r.Ira - 5);
            }
            else if (pajaro is Bomb b)
            {
                b.Ira = Math.Max(0, b.Ira - 5);
            }
            else if (pajaro is Terence t)
            {
                t.Ira = Math.Max(0, t.Ira - 5);
            }
            else if (pajaro is Matilda m)
            {
                m.Ira = Math.Max(0, m.Ira - 5);
            }
        }
    }
}
