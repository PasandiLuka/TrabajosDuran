using Biblioteca.Interfaces;

namespace Biblioteca.Entidades;

public class Bolillero
{
    private readonly IAzar _azar;
    private List<int> _bollitasOriginales;
    public List<int> BollitasAdentro;
    public List<int> BollitasAfuera;
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

    public Bolillero(int numeroMaximo, IAzar azar)
    {
        _azar = azar;

        NumeroMaximo = numeroMaximo;
        _bollitasOriginales = Enumerable.Range(0, numeroMaximo).ToList();
        BollitasAdentro = _bollitasOriginales;
        BollitasAfuera = new List<int>();
    }

    public void SacarBolilla()
    {
        var numeroEliminado = BollitasAdentro.ElementAt(_azar.ObtenerAleatorio(BollitasAdentro.Count - 1));
        BollitasAdentro.Remove(numeroEliminado);
        BollitasAfuera.Add(numeroEliminado);
    }

    public void ReIngresar()
    {
        BollitasAdentro = _bollitasOriginales;
        BollitasAfuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        do
        {
            SacarBolilla();
        }
        while (!BollitasAdentro.SequenceEqual(jugada) && BollitasAdentro.Count < jugada.Count);
        if(BollitasAdentro.SequenceEqual(jugada)) return true;
        ReIngresar();
        return false;
    }

    public bool JugarGana(List<int> jugada) => Jugar(jugada);

    public bool JugarPierde(List<int> jugada) => !Jugar(jugada);

    public bool GanarNVeces(List<int> jugada, int cantVeces)
    {
        for(int i = 0; i < cantVeces; i++)
        {
            if(JugarPierde(jugada))
            {
                return false;   
            }
        }
        return true;
    }
}