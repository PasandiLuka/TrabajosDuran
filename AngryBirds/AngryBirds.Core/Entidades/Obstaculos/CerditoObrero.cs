using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Obstaculos;

/// <summary>
/// Cerdito obrero. Resistencia = 50.
/// </summary>
public class CerditoObrero : IObstaculo
{
    public int Resistencia => 50;
    public bool EstaEnPie => ResistenciaActual > 0;
    
    public int ResistenciaActual { get; private set; }

    public CerditoObrero()
    {
        ResistenciaActual = Resistencia;
    }

    public void RecibirAtaque(int fuerza)
    {
        ResistenciaActual -= fuerza;
    }
}
