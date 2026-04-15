using Biblioteca.Interfaces;

namespace Biblioteca.Entidades;

public class Bolillero
{
    private readonly IAzar _azar;
    private List<int> _bollitasOriginales;
    public List<int> BollitasAdentro = new();
    public List<int> BollitasAfuera = new();
    private int _numeroMaximo;
    public int NumeroMaximo
    {
        get => _numeroMaximo;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("El número máximo debe ser positivo.");
            _numeroMaximo = value;
            _bollitasOriginales = Enumerable.Range(0, _numeroMaximo).ToList();
            BollitasAdentro.Clear();
            BollitasAdentro.AddRange(_bollitasOriginales);
            BollitasAfuera.Clear();
        }
    }

    public Bolillero(int numeroMaximo, IAzar azar)
    {
        _azar = azar;

        NumeroMaximo = numeroMaximo;
        _bollitasOriginales = Enumerable.Range(0, numeroMaximo).ToList();
        BollitasAdentro.AddRange(_bollitasOriginales);
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
        BollitasAdentro.Clear();
        BollitasAdentro.AddRange(_bollitasOriginales);
        BollitasAfuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        do
        {
            SacarBolilla();
        }
        while (!BollitasAfuera.SequenceEqual(jugada) && BollitasAfuera.Count < jugada.Count);
        if(BollitasAfuera.SequenceEqual(jugada))
        {
            ReIngresar();
            return true;
        }
        ReIngresar();
        return false;
    }

    public bool JugarGana(List<int> jugada) => Jugar(jugada);

    public bool JugarPierde(List<int> jugada) => !Jugar(jugada);

    public long GanarNVeces(List<int> jugada, int cantVeces)
    {
        var contadorVictorias = 0;
        for(int i = 0; i < cantVeces; i++)
        {
            if(JugarGana(jugada))
            {
                contadorVictorias++;
            }
        }
        return contadorVictorias;
    }

    public Bolillero Clone()
    {
        return new Bolillero(_numeroMaximo, _azar)
        {
            BollitasAdentro = BollitasAdentro,
            BollitasAfuera = BollitasAfuera,
            _bollitasOriginales = _bollitasOriginales,

        };
    }
}