public class Entrenamiento
{
    private double Distancia {get; set;}
    private TimeSpan Tiempo {get; set;}

    public Entrenamiento (double distancia, TimeSpan tiempo)
    {
        this.Distancia = distancia;
        this.Tiempo = tiempo;
    }

    public override string ToString()
    {
        return $"{Distancia} km en {Tiempo}";
    }

}