 public enum TipoTarea
{
    Personal,
    Trabajo,
    Estudio
}

public class Tarea
{
    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public TipoTarea Tipo { get; private set; }
    public bool Prioridad { get; set; }

    public Tarea(int id, string nombre, string descripcion, TipoTarea tipo, bool prioridad)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Tipo = tipo;
        Prioridad = prioridad;
    }
    
}