namespace AngryBirds.Core.Interfaces;

public interface IObstaculo
{
    int Resistencia { get; }
    bool EstaEnPie { get; }
    
    void RecibirAtaque(int fuerza);
}
