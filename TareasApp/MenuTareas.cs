public class MenuTareas
{   
    private const string ArchivoIntercambio = "tareas.txt";

    public MenuTareas()
    {
    }

    public static void AgregarTarea(SistemaTareas sistema)
    {
        string nombre;
        string descripcion;
        TipoTarea tipo;
        bool prioridad;
        try
        {   
        Console.Write("Nombre: ");
        nombre = Console.ReadLine() ?? "";

        Console.Write("Descripción: ");
        descripcion = Console.ReadLine() ?? "";

        Console.WriteLine("Tipo: 0-Personal, 1-Trabajo, 2-Estudio");
        if (!int.TryParse(Console.ReadLine(), out int tipoInt) || tipoInt < 0 || tipoInt > 2)
        {
            Console.WriteLine("Tipo no válido. Se asignará Personal por defecto.");
            tipo = TipoTarea.Personal;
        }
        else
        {
            tipo = (TipoTarea)tipoInt;
        }
        

        Console.Write("¿Prioritaria? (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out prioridad))
        {
            Console.WriteLine("Entrada no válida. Se asignará false por defecto.");
            prioridad = false;
        }

        sistema.AgregarTarea(nombre, descripcion, tipo, prioridad);

        Console.WriteLine("Tarea guardada correctamente.");
    }   catch (Exception ex)
        {
            Console.WriteLine("Error al agregar la tarea: " + ex.Message);
        }
    }

    public static void BuscarPorTipo(SistemaTareas sistema)
    {
        Console.WriteLine("Tipo: 0-Personal, 1-Trabajo, 2-Estudio");
        TipoTarea tipo = (TipoTarea)Convert.ToInt32(Console.ReadLine());

        List<Tarea> tareas = sistema.BuscarPorTipo(tipo);

        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas de ese tipo.");
            return;
        }

        foreach (Tarea tarea in tareas)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("ID: " + tarea.Id);
            Console.WriteLine("Nombre: " + tarea.Nombre);
            Console.WriteLine("Descripción: " + tarea.Descripcion);
            Console.WriteLine("Tipo: " + tarea.Tipo);
            Console.WriteLine("Prioridad: " + tarea.Prioridad);
        }
    }

      public static void EliminarPorId(SistemaTareas sistema)
    {
        Console.Write("Introduce el ID a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        sistema.EliminarPorId(id);

        Console.WriteLine("Si existía, la tarea ha sido eliminada.");
    }

    public static void ExportarTareasTXT(SistemaTareas sistema)
        {
            try
            {
                sistema.ExportarTareas(ArchivoIntercambio);
                Console.WriteLine("Tareas exportadas a " + ArchivoIntercambio);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al exportar las tareas: " + ex.Message);
            }   
        }

     public static void ImportarTareasTXT(SistemaTareas sistema)
    {
        try
        {
            bool importacionCorrecta = sistema.ImportarTareas(ArchivoIntercambio);

            if (importacionCorrecta)
            {
                Console.WriteLine("Tareas importadas desde " + ArchivoIntercambio);
            }
            else
            {
                Console.WriteLine("No existe el archivo " + ArchivoIntercambio);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al importar las tareas: " + ex.Message);
        }
    }
          
}