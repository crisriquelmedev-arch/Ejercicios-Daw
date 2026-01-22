public class EntradaEstructuras
{
    public static void Main(string[] args)
    {
        string variable = "Borja";
        Console.WriteLine($"Mi nombre es {variable}");

        //if -> ejecucion de bloques dependiendo de una condicion logica.

        /*Console.WriteLine("Introduce una nota");
        int nota = int.Parse(Console.ReadLine());
        if(nota >= 5)
        {
            Console.WriteLine("Examen APROBADO");
        }
        else
        {
            Console.WriteLine("Examen SUSPENDIDO");
        }    
        */
        //if ternario -> permite asignar un valor dependiendo de una condicion logica.
        Console.WriteLine("Introduce una nota");
        int nota = int.Parse(Console.ReadLine() ?? "0");
        string resultado = (nota >= 5) ? "APROBADO" : "SUSPENDIDO";
        Console.WriteLine($"Examen {resultado}");

        //switch -> evalua un valor numerico / string / char

        Console.WriteLine("Introduce una nota");
        int dia = int.Parse(Console.ReadLine() ?? "0");
        switch(nota)
        {
            case 1 or 2 or 3 or 4:
                Console.WriteLine("suspenso");
                break;
            case 5 or 6:
                Console.WriteLine("Aprobado");
                break;
            case 7:
                Console.WriteLine("Notable");
                break;
            case 8 or 9:
                Console.WriteLine("Muy bien");
                break;
            case 10:
                Console.WriteLine("Sobresaliente");
                break;
            default:
                Console.WriteLine("Nota no valida");
                break;
        }

        resultado = nota switch
        {
            1 or 2 or 3 or 4 => "suspenso",
            5 or 6 => "Aprobado",
            7 => "Notable",
            8 or 9 => "Muy bien",
            10 => "Sobresaliente",
            _ => "Nota no valida"
        };
        Console.WriteLine($"Examen {resultado}");

        //for -> bucle controlado por contador. Utilizado para repetir elementos un numero determinado de veces.
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Valor de i: {i}");
        }

        //while -> bucle controlado por condicion logica. Utilizado para repetir elementos mientras se cumpla una condicion.
        //do while -> bucle controlado por condicion logica. Utilizado para repetir elementos mientras se cumpla una condicion. 
        // La condicion se evalua al final del bucle, por lo que se ejecuta al menos una vez.

        int j = 0;
        while(j < 10)
        {
            Console.WriteLine($"Valor de j: {j}");
            j++;
        }
    }
}