namespace AngryBirds.Core.Interfaces;

public interface IPajaro
{
    int Ira { get; }
    int Fuerza { get; }
    bool EsFuerte { get; }
    
    void Enfadarse();
}
