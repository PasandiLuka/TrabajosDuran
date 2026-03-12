namespace Biblitoteca.Entidades;

public class Capital
{
    public int cantDefensores { get; private set; }
    public float botin { get; private set; }
    public float riquezaTierra { get; private set; }

    public Capital(int cantDefensores, float riquezaTierra)
    {
        Validador.EnteroPositivo(cantDefensores, "cantDefensores");
        Validador.FloatPositivo(botin,"botin");
        Validador.FloatPositivo(riquezaTierra,"riquezaTierra");
        this.cantDefensores = cantDefensores;
        this.riquezaTierra = riquezaTierra;
        botin = 0;
    }

    // metodo botin para saber el total del botin de la capital.
    public float BotinTotal()
    {
        return botin = cantDefensores * riquezaTierra;
    }

    //SETTERS
    public void SetCantDefensores(int _cantDefensores)
    {
        Validador.EnteroPositivo(_cantDefensores, "cantDefensores");
        cantDefensores = _cantDefensores;
    }
    public void SetBotin(float _botin)
    {
        Validador.FloatPositivo(_botin, "botín");
        botin = _botin;
    }
    public void SetRiquezaTotal(float _riquezaTotal)
    {
        Validador.FloatPositivo(_riquezaTotal, "riquezaTotal");
        riquezaTierra = _riquezaTotal;
    }
}