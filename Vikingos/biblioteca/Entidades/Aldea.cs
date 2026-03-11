namespace Biblitoteca.Entidades;

public class Aldea
{
    public Iglesia? iglesia { get; private set; }
    public Amurallada? amurallada { get; private set; }
    
    /// <summary>
    /// Es solicitado definir si la aldea es amurallada o si posee una iglesia, mas no puede poseer ambas
    /// </summary>
    /// <param name="iglesia"></param>
    /// <param name="amurallada"></param>
    public Aldea(Iglesia? iglesia = null, Amurallada? amurallada = null)
    {
        if ((iglesia is null && amurallada is null) || (iglesia is not null && amurallada is not null)) throw new InvalidOperationException("La aldea debe ser amurallada o poseer una iglesia, más no debe poseer las dos");
        this.iglesia = iglesia;
        this.amurallada = amurallada;
    }
}