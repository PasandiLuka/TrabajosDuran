namespace Biblitoteca.Entidades;

public class Capital
{
    public int cantDefensores { get; set; }
    public float botin { get; set; }
    public float riquezaTierra { get; set; }

    // metodo botin para saber el total del botin de la capital.

    public float BotinTotal()
    {
        return botin = cantDefensores * riquezaTierra;
    }
}