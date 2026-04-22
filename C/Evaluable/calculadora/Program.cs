Calculadora calc = new Calculadora();
bool continuar = true;

do
{
    int a;
    int b;

    Console.WriteLine("\nCalculadora iniciada.");
    Console.WriteLine("Indique dos numeros enteros positivos:");

    do
    {
        Console.Write("Primer número (debe ser positivo): ");
        a = int.Parse(Console.ReadLine() ?? "0");

        if (a <= 0)
            Console.WriteLine("Error: El número debe ser positivo.");
    } while (a <= 0);

    do
    {
        Console.Write("Segundo número (debe ser positivo): ");
        b = int.Parse(Console.ReadLine() ?? "0");

        if (b <= 0)

            Console.WriteLine("Error: El número debe ser positivo.");
    } while (b <= 0);

    Console.WriteLine("Elija una de las operaciones: + , - , * , / ");
    string operacion = Console.ReadLine() ?? "+";

    switch (operacion)
    {
        case "+":
            int suma = calc.Sumar(a, b);
            Console.WriteLine($"Suma: {suma}");
            break;

        case "-":
            int resta = calc.Restar(a, b);
            Console.WriteLine($"Resta: {resta}");
            break;

        case "*":
            int multiplicacion = calc.Multiplicar(a, b);
            Console.WriteLine($"Multiplicación: {multiplicacion}");
            break;

        case "/":
            if (b != 0)
            {
                double division = calc.Dividir(a, b);
                Console.WriteLine($"División: {division}");
            }
            else
            {
                Console.WriteLine("Error: No se puede dividir por cero");
            }
            break;

        default:
            Console.WriteLine("Operación no válida");
            break;
    }

    Console.Write("\n¿Desea realizar otra operación? (s/n): ");
    string respuesta = Console.ReadLine() ?? "n";
    continuar = respuesta.ToLower() == "s";
    

} while (continuar);
    
    if (!continuar)
    {
        Console.WriteLine("\nCalculadora finalizada. ¡Hasta luego!");
    }

