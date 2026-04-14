using Biblioteca.Interfaces;

namespace Biblioteca.Entidades;

public class Azar : IAzar
{
    public int ObtenerAleatorio(int tope) 
        => new Random(DateTime.Now.Millisecond).Next(0, tope);
}