/*
.JAVA cada fichero tiene una extension .JAVA

Tiene que haber una clase publica con el mismo nombre del fichero.

C# 
Cada fichero tiene una extension .cs
no tiene porque haber una clase publica con el mismo nombre del fichero.


*/
using System.Security.Cryptography.X509Certificates;

//Console.WriteLine("Esto es un ejemplo de linea de codigo");

public class Ejemplo
{
    public static void Main (string[] args)
    {
        // Los metodos se escriben con MAYUSCULAS.
        //Systen.out.println()
        //System.out.prinf()
        Console.WriteLine("Primer ejemplo en C#");

        /*Variables
        string, int, double, float, bool, char = VAN EN MINUSCULAS
        */
        string nombre = "Cristian";
        int edad = 35;
        double altura = 1.80;
        bool experiencia = true;

        //Console.WriteLine("Mi nombre es" + nombre + "tengo " + edad + "años y mido " + altura + " cm");
        Console.WriteLine("Por favor intrduce tu nombre");
        nombre = Console.ReadLine();
        Console.WriteLine("Por favor introduce tu edad");
        edad = int.Parse(Console.ReadLine());
        Console.WriteLine("Por favor introduce tu altura");
        altura = double.Parse(Console.ReadLine());
        Console.WriteLine($"Mi nombre es {nombre} tengo {edad} años y mido {altura}");

    }
}