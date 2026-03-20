using AngryBirds.Core.Entidades.Islas;

namespace AngryBirds.Core.Interfaces;

public interface IEvento
{
    void Aplicar(IslaPajaro isla);
}
