using System.Runtime.CompilerServices;

public class Entrada {
    public static void Main(string[] args)
        {
            //array un conjunto de datos ubicados en una misma variable. un armario es un conjunto de datos del mismo tipo

            //int[] numeros = new int[5]; //declaracion de un array de enteros con 5 posiciones, son datos primitivos (0, false, 0.0)
            // complejos -> null
            string[] asignaturas = new string[]{"Programacion", "Base de Datos", "Entornos de Desarrollo"};

            //acceder a posiciones ->
            Console.WriteLine(asignaturas[0]); //Programacion
            //obtener aleatorio entre 0 y 2
            //new Random().Next(0, 3);
            Console.WriteLine(asignaturas[new Random().Next(3)]);

            asignaturas[1] = "Sistemas Informaticos"; //modificar valor en una posicion
            Console.WriteLine(asignaturas[1]);
            Console.WriteLine("El array tiene " + asignaturas.Length + " elementos"); //Length -> propiedad que devuelve la longitud del array

            int[] notas = new int[10];
            for (int i = 0; i < notas.Length; i++)
            {
               Console.WriteLine("Por favor introduce una nota :");
               notas[i] = int.Parse(Console.ReadLine() ?? "0");
              
            }

            

            //mostrar notas
            for (int i = 0; i < notas.Length; i++)
            {
               Console.WriteLine("La nota en la posicion " + i + " es " + notas[i]);
            }

            //foreach -> para recorrer arrays y colecciones
            foreach (string asignatura in asignaturas)
            {
               Console.WriteLine("Asignatura: " + asignatura);
            }

            //mover una posicion a la derecha
            
            int ultimo = notas[notas.Length - 1]; //guardamos el ultimo valor
            for (int i = notas.Length - 1; i > 0; i--)
            {
               notas[i] = notas[i - 1]; //movemos el valor de la izquierda a la posicion actual
            }
            notas[0] = ultimo; //el primer valor es el ultimo guardado
            Console.WriteLine("Array movido a la derecha:");
            foreach (int nota in notas)
            {
               Console.WriteLine(nota);
            }

            //mover una posicion a la izquierda

            int primero = notas[0]; //guardamos el primer valor
            for (int i = 0; i < notas.Length - 1; i++)
            {
               notas[i] = notas[i + 1]; //movemos el valor de la derecha a la posicion actual
            }   
            notas[notas.Length - 1] = primero; //el ultimo valor es el primero guardado
            Console.WriteLine("Array movido a la izquierda:");
            foreach (int nota in notas)
            {
               Console.WriteLine(nota);
            }

            //rotar cada par de notas
            for (int i = 0; i < notas.Length - 1; i += 2)//incremento de 2 en 2
            {
               int temp = notas[i];//guardamos el valor de la posicion actual
               notas[i] = notas[i + 1];//asignamos el valor de la siguiente posicion a la actual
               notas[i + 1] = temp;//asignamos el valor guardado a la siguiente posicion
            }
            Console.WriteLine("Array con pares rotados:");
            foreach (int nota in notas)
            {
               Console.WriteLine(nota);
            }

            //list/arraylist -> estructuras dinamicas, muy parecidos a los arrays pero pueden cambiar de tamaño
            //Dictionary -> estructura de datos basada en pares clave-valor la diferencia respecto a los arrays es que no se accede por posicion sino por clave
            
            //crear un array aletrando posiciones por pares
            int[] rotar = new int[10]{1,2,3,4,5,6,7,8,9,10};
            for (int i = 0; i < rotar.Length - 1; i += 2)
            {
               int temp = rotar[i];
               rotar[i] = rotar[i + 1];
               rotar[i + 1] = temp;
            }

            Console.WriteLine("Array con pares rotados:");
            foreach (int num in rotar)
            {
               Console.WriteLine(num);
            }


            //hacer un espejo del array
            int[] espejo = new int[10]{1,2,3,4,5,6,7,8,9,10};
            for (int i = 0; i < espejo.Length / 2; i++)
            {
               int temp = espejo[i];
               espejo[i] = espejo[espejo.Length - 1 - i];
               espejo[espejo.Length - 1 - i] = temp;
            }
            Console.WriteLine("Array espejado:");
            foreach (int num in espejo)
            {
               Console.WriteLine(num);
            }

            int [] numeros = new int[]{5,3,8,1,2,7,4,6,9,0};
            //ordenar el array de numeros de menor a mayor (algoritmo de burbuja)
            for (int i = 0; i < numeros.Length - 1; i++)
            {
               for (int j = 0; j < numeros.Length - 1 - i; j++)
               {
                   if (numeros[j] > numeros[j + 1])
                   {
                       int temp = numeros[j];
                       numeros[j] = numeros[j + 1];
                       numeros[j + 1] = temp;
                   }
               }
            }
            Console.WriteLine("Array ordenado de menor a mayor:");
            foreach (int num in numeros)
            {
               Console.WriteLine(num);
            }

            //uso de listas
            
            List<int> listaNumeros = new List<int>(){5,3,8,1,2,7,4,6,9,0};
            listaNumeros.Sort(); //metodo para ordenar listas
            Console.WriteLine("Lista ordenada de menor a mayor:");
            foreach (int num in listaNumeros)
            {
               Console.WriteLine(num);
            }
            Console.WriteLine("La longitud de la lista es: " + listaNumeros.Count); //propiedad para obtener la longitud de la lista

            listaNumeros.Add(10); //metodo para añadir un elemento al final de la lista, se queda asignado en la ultima posicion
            Console.WriteLine("Lista despues de añadir un elemento:");
            foreach (int num in listaNumeros)
            {
               Console.WriteLine(num);
            }

            listaNumeros.RemoveAt(0); //metodo para eliminar un elemento en una posicion concreta
            Console.WriteLine("Lista despues de eliminar el primer elemento:");
            foreach (int num in listaNumeros)
            {
               Console.WriteLine(num);
            }

            listaNumeros.Remove(5); //metodo para eliminar un elemento por su valor
            Console.WriteLine("Lista despues de eliminar el elemento con valor 5:");

            listaNumeros.Insert(0, 15); //metodo para insertar un elemento en una posicion concreta
            Console.WriteLine("Lista despues de insertar un elemento al principio:");
            foreach (int num in listaNumeros)
            {
               Console.WriteLine(num);
            }

            listaNumeros.Clear(); //metodo para limpiar la lista
            Console.WriteLine("Lista despues de limpiarla, su longitud es: " + listaNumeros.Count);

            listaNumeros.AddRange(new int[]{1,2,3,4,5}); //metodo para añadir varios elementos a la lista
            Console.WriteLine("Lista despues de añadir varios elementos:");

            listaNumeros.ForEach(num => Console.WriteLine(num)); //metodo para recorrer la lista con una expresion lambda

            listaNumeros.ElementAt(2); //metodo para obtener el elemento en una posicion concreta

            int numero = listaNumeros.Find(n => n > 3); //metodo para encontrar el primer elemento que cumple una condicion
            Console.WriteLine("El primer numero mayor que 3 es: " + numero);

            int elemento = listaNumeros.ElementAt(4);
            Console.WriteLine("El elemento en la posicion 4 es: " + elemento);

            listaNumeros.RemoveAll(n => n % 2 == 1); //metodo para eliminar todos los elementos que cumplen una condicion
            Console.WriteLine("Lista despues de eliminar todos los numeros impares:");
            
            listaNumeros.ForEach(num => Console.WriteLine(num));

            listaNumeros.Reverse(); //metodo para invertir el orden de la lista
            Console.WriteLine("Lista despues de invertir el orden:");
            listaNumeros.ForEach(num => Console.WriteLine(num));

            listaNumeros.Clear();
            Console.WriteLine("Lista despues de limpiarla, su longitud es: " + listaNumeros.Count);

        }
    }
