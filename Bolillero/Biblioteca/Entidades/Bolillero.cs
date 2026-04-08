using System.Net.Http.Headers;

namespace Biblioteca.Entidades;

public class Bolillero
{
    private List<int> _bollitasOriginales;
    public List<int> BollitasAdentro;
    public List<int>? BollitasAfuera;
    private int _numeroMaximo;
    public int NumeroMaximo
    {
        get => _numeroMaximo;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("El número máximo debe ser positivo.");
            _numeroMaximo = value;
        }
    }

    public Bolillero(int numeroMaximo)
    {
        NumeroMaximo = numeroMaximo;
        _bollitasOriginales = Enumerable.Range(0, numeroMaximo).ToList();
        BollitasAdentro = _bollitasOriginales;
    }

    public void SacarBolilla()
    {
        var numeroEliminado = BollitasAdentro.ElementAt(Azar.ObtenerAleatorio(BollitasAdentro.Count - 1));
        BollitasAdentro.RemoveAt(numeroEliminado);
        BollitasAfuera?.Add(numeroEliminado);
    }

    public void ReIngresar()
    {
        BollitasAdentro = _bollitasOriginales;
        BollitasAfuera?.Clear();
    }

    public bool JugarGana(List<int> jugada)
    {
        do
        {
            SacarBolilla();
        }
        while
            (BollitasAdentro != jugada && BollitasAdentro.Count < jugada.Count);
        // if (BollitasAdentro.Equals(jugada)) return true;
        ReIngresar();
        return false;
    }

    public bool JugarPierde(List<int> jugada)
    {

    }

    public bool GanarNVeces(List<int> jugada)
    {

    }
}