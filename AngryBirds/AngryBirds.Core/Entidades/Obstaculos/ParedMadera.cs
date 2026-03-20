using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Obstaculos;

/// <summary>
/// Pared de madera. Resistencia = 25 * ancho.
/// </summary>
public class ParedMadera : IObstaculo
{
    public int Ancho { get; private set; }
    public int Resistencia => 25 * Ancho;
    public bool EstaEnPie => ResistenciaActual > 0;
    
    public int ResistenciaActual { get; private set; }

    public ParedMadera(int ancho)
    {
        Ancho = ancho;
        ResistenciaActual = Resistencia;
    }

    public void RecibirAtaque(int fuerza)
    {
        ResistenciaActual -= fuerza;
    }
}
