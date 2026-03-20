using AngryBirds.Core.Interfaces;

namespace AngryBirds.Core.Entidades.Obstaculos;

/// <summary>
/// Cerdito armado con casco. Resistencia = 10 * resistencia del casco.
/// </summary>
public class CerditoArmado : IObstaculo
{
    public int ResistenciaCasco { get; private set; }
    public int Resistencia => 10 * ResistenciaCasco;
    public bool EstaEnPie => ResistenciaActual > 0;
    
    public int ResistenciaActual { get; private set; }

    public CerditoArmado(int resistenciaCasco)
    {
        ResistenciaCasco = resistenciaCasco;
        ResistenciaActual = Resistencia;
    }

    public void RecibirAtaque(int fuerza)
    {
        ResistenciaActual -= fuerza;
    }
}
