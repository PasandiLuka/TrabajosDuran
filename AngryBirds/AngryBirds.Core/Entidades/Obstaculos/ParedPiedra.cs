using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Obstaculos;

/// <summary>
/// Pared de piedra. Resistencia = 50 * ancho.
/// </summary>
public class ParedPiedra : IObstaculo
{
    public int Ancho { get; private set; }
    public int Resistencia => 50 * Ancho;
    public bool EstaEnPie => ResistenciaActual > 0;
    
    public int ResistenciaActual { get; private set; }

    public ParedPiedra(int ancho)
    {
        Ancho = ancho;
        ResistenciaActual = Resistencia;
    }

    public void RecibirAtaque(int fuerza)
    {
        ResistenciaActual -= fuerza;
    }
}
