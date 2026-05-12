namespace Biblioteca.Entidades;

public class Simulacion
{
    public static long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantVecesJugar)
        => bolillero.GanarNVeces(jugada, cantVecesJugar);

    public static long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantVecesJugar, int cantHilos = 1)
    {
        var resto = cantVecesJugar % cantHilos;
        var cantVecPorProceso = (cantVecesJugar - cantVecesJugar % cantHilos) / cantHilos;

        Task<long>[] tareas = new Task<long>[cantHilos];

        for(int i = 0; i < cantHilos; i++)
        {
            int captural = i;
            tareas[i] = Task.Run(() 
                => bolillero.Clone().GanarNVeces(
                    jugada, 
                    cantVecPorProceso + 
                        ((resto != 0 && captural < resto) ? 1 : 0)
                    )
            );
        }
        
        Task.WaitAll(tareas);

        return tareas.Sum(t => t.Result);
    }
    public async static Task<long> SimularConHilosAsync(Bolillero bolillero, List<int> jugada, int cantVecesJugar, int cantHilos = 1)
    {
        var resto = cantVecesJugar % cantHilos;
        var cantVecPorProceso = (cantVecesJugar - cantVecesJugar % cantHilos) / cantHilos;

        Task<long>[] tareas = new Task<long>[cantHilos];

        for(int i = 0; i < cantHilos; i++)
        {
            int captural = i;

            tareas[i] = Task.Run(() 
                => bolillero.Clone().GanarNVeces(
                    jugada, 
                    cantVecPorProceso + 
                        ((resto != 0 && captural < resto) ? 1 : 0)
                    )
            );
        }
        
        var resultado = await Task.WhenAll(tareas);

        return resultado.Sum();
    }
}