using Biblioteca.Interfaces;

namespace Biblioteca.Entidades;

public class Azar : IAzar
{
    public static int ObtenerAleatorio(int tope)
    {
        return new Random(DateTime.Now.Millisecond).Next(0, tope);
    }
}