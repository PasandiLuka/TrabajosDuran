using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Obstaculos;

/// <summary>
/// Pared de vidrio. Resistencia = 10 * ancho.
/// </summary>
public class ParedVidrio : IObstaculo
{
    public int Ancho { get; private set; }
    public int Resistencia => 10 * Ancho;
    public bool EstaEnPie => ResistenciaActual > 0;
    
    public int ResistenciaActual { get; private set; }

    public ParedVidrio(int ancho)
    {
        Ancho = ancho;
        ResistenciaActual = Resistencia;
    }

    public void RecibirAtaque(int fuerza)
    {
        ResistenciaActual -= fuerza;
    }
}
