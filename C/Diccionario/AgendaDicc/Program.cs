using System.Xml.Serialization;
public class Program
{
    public static void main (string[] args)
    {
        Dictionary<string,string> listaPersonas = new Dictionary<string, string>();

            int? opcion = -1;

            do 
            {
                Console.WriteLine("Agregar Usuario.");
                Console.WriteLine("Buscar Usuario.");
                Console.WriteLine("Eliminar Usuario.");
                Console.WriteLine("Mostrar Usuario.");
                Console.WriteLine("Salir.");
                opcion = Int16.Parse(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        Console.WriteLine("introduce el dni:");
                        string? dni = Console.ReadLine();
                        

                        if (listaPersonas.ContainsKey(dni))
                        {
                            Console.WriteLine("El dni se encuntra en uso");
                        }
                        else
                        {
                            Console.WriteLine("Introduce el Usuario:");
                            string? nombre = Console.ReadLine();
                            listaPersonas.TryAdd(dni!,nombre!);
                            listaPersonas[]
                        }


                        break;
                        
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Adios!...");
                        break;
                    default:
                        Console.WriteLine("Caso no contemplado");
                        break;
                }

            }while(opcion != 5);
    }
            
}



