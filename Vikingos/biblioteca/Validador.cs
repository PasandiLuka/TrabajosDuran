namespace Biblitoteca;

public static class Validador
{
    public static void EnteroPositivo(int valor, string texto)
    {
        if(valor < 0) throw new ArgumentException($"El parametro '{texto}' debe ser positivo."); 
    }
    public static void FloatPositivo(float valor, string texto)
    {
        if(valor < 0) throw new ArgumentException($"El parametro '{texto}' debe ser positivo."); 
    }
}