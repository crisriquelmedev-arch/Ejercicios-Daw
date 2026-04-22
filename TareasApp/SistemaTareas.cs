public class SistemaTareas
{
    private string rutaArchivo = "tareas.txt";

    public int ObtenerSiguienteId()
    {
        int mayorId = 0;

        if (File.Exists(rutaArchivo))
        {
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (linea != "")
                {
                    string[] partes = linea.Split(';');
                    int id = Convert.ToInt32(partes[0]);

                    if (id > mayorId)
                    {
                        mayorId = id;
                    }
                }
            }
        }

        return mayorId + 1;
    }

    public void AgregarTarea(string nombre, string descripcion, TipoTarea tipo, bool prioridad)
    {
        int id = ObtenerSiguienteId();
        string linea = id + ";" + nombre + ";" + descripcion + ";" + tipo + ";" + prioridad;

        File.AppendAllText(rutaArchivo, linea + Environment.NewLine);
    }

    public List<Tarea> ObtenerTodasLasTareas()
    {
        List<Tarea> tareas = new List<Tarea>();

        if (File.Exists(rutaArchivo))
        {
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (linea != "")
                {
                    string[] partes = linea.Split(';');

                    int id = Convert.ToInt32(partes[0]);
                    string nombre = partes[1];
                    string descripcion = partes[2];
                    TipoTarea tipo = (TipoTarea)Enum.Parse(typeof(TipoTarea), partes[3]);
                    bool prioridad = Convert.ToBoolean(partes[4]);

                    Tarea tarea = new Tarea(id, nombre, descripcion, tipo, prioridad);
                    tareas.Add(tarea);
                }
            }
        }

        return tareas;
    }

   
    public List<Tarea> BuscarPorTipo(TipoTarea tipoBuscado)
    {
        List<Tarea> resultado = new List<Tarea>();
        List<Tarea> tareas = ObtenerTodasLasTareas();

        foreach (Tarea tarea in tareas)
        {
            if (tarea.Tipo == tipoBuscado)
            {
                resultado.Add(tarea);
            }
        }

        return resultado;
    }

    public void EliminarPorId(int idEliminar)
    {
        if (!File.Exists(rutaArchivo))
        {
            return;
        }

        string[] lineas = File.ReadAllLines(rutaArchivo);
        List<string> nuevasLineas = new List<string>();

        foreach (string linea in lineas)
        {
            if (linea != "")
            {
                string[] partes = linea.Split(';');
                int id = Convert.ToInt32(partes[0]);

                if (id != idEliminar)
                {
                    nuevasLineas.Add(linea);
                }
            }
        }

        File.WriteAllLines(rutaArchivo, nuevasLineas);
    }

    public void ExportarTareas(string rutaArchivoExportacion)
    {
        if (File.Exists(rutaArchivo))
        {
            string? directorio = Path.GetDirectoryName(rutaArchivoExportacion);

            if (!string.IsNullOrWhiteSpace(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            File.AppendAllLines(rutaArchivoExportacion, File.ReadAllLines(rutaArchivo));
        }
    }
    

    public bool ImportarTareas(string rutaImportacion)
    {
        if (File.Exists(rutaImportacion))
        {
            File.WriteAllLines(rutaArchivo, File.ReadAllLines(rutaImportacion));
            return true;
        }

        return false;
    }
}
