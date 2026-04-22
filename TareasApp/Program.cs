public class Program
{
    public static void Main(string[] args)
    {
        SistemaTareas sistema = new SistemaTareas();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Buscar por tipo");
            Console.WriteLine("3. Eliminar por ID");
            Console.WriteLine("4. Exportar Tareas a TXT");
            Console.WriteLine("5. Importar Tareas desde TXT");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MenuTareas.AgregarTarea(sistema);
                    break;

                case 2:
                    MenuTareas.BuscarPorTipo(sistema);
                    break;

                case 3:
                    MenuTareas.EliminarPorId(sistema);
                    break;

                case 4:
                    MenuTareas.ExportarTareasTXT(sistema);
                    break;

                case 5:
                    MenuTareas.ImportarTareasTXT(sistema);
                    break;

                case 0:
                    Console.WriteLine("Fin del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    

    

  
   
}

