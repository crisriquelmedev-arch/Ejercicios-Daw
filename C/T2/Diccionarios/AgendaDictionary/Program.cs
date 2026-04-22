//guardar los valores par key-value de un conjunto de personas en un diccionario e imprimirlos en consola
//tipo key, value: string, string

Dictionary<string, string> agenda = new Dictionary<string, string>();
// Agregar elementos al diccionario
agenda.Add("Juan", "123456789");
agenda.Add("María", "987654321");
agenda.Add("Pedro", "555555555");

foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}

agenda["Ana"] = "111222333"; // Agregar un nuevo elemento
agenda["Juan"] = "999888777"; // Modificar un elemento existente
Console.WriteLine("\nDespués de agregar/modificar elementos:\n");
foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}

//consultar un valor por su clave
string nombreBuscado = "María";
if (agenda.TryGetValue(nombreBuscado, out string telefono))
{
    Console.WriteLine($"\nEl teléfono de {nombreBuscado} es {telefono}");
}
else
{
    Console.WriteLine($"\n{nombreBuscado} no se encuentra en la agenda.");
}

string datoRecuperado = agenda.GetValueOrDefault("Pedro", "No encontrado");;
Console.WriteLine($"\nEl teléfono de Pedro es: {datoRecuperado}");

//eliminar un elemento por su clave
agenda.Remove("Pedro");
Console.WriteLine("\nDespués de eliminar a Pedro:\n");
foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}

//verificar si una clave existe
string claveVerificar = "Ana";
if (agenda.ContainsKey(claveVerificar))
{
    Console.WriteLine($"\nLa clave {claveVerificar} existe en la agenda.");
}
else
{
    Console.WriteLine($"\nLa clave {claveVerificar} no existe en la agenda.");
}

//verificar si un valor existe
string valorVerificar = "123456789";    
if (agenda.ContainsValue(valorVerificar))
{
    Console.WriteLine($"\nEl valor {valorVerificar} existe en la agenda.");
}
else
{
    Console.WriteLine($"\nEl valor {valorVerificar} no existe en la agenda.");
}

//obtener la cantidad de elementos en el diccionario
Console.WriteLine($"\nLa cantidad de elementos en la agenda es: {agenda.Count}");   

//limpiar el diccionario
agenda.Clear();

Console.WriteLine($"\nDespués de limpiar, la cantidad de elementos en la agenda es: {agenda.Count}");

//modificar un valor existente
agenda["María"] = "222333444"; // Modificar el número de María
Console.WriteLine("\nDespués de modificar el número de María:\n");
foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}

//intentar obtener un valor de forma segura
if (agenda.TryGetValue("Juan", out string numeroJuan))
{
    Console.WriteLine($"\nEl número de Juan es: {numeroJuan}");
}
else
{
    Console.WriteLine("\nJuan no se encuentra en la agenda.");
}

//obtener todas las claves
Console.WriteLine("\nClaves en la agenda:");
foreach (var clave in agenda.Keys)
{
    Console.WriteLine(clave);
}
//obtener todos los valores
Console.WriteLine("\nValores en la agenda:");
foreach (var valor in agenda.Values)
{
    Console.WriteLine(valor);
}

//verificar si el diccionario está vacío
if (agenda.Count == 0)
{
    Console.WriteLine("\nLa agenda está vacía.");
}
else
{
    Console.WriteLine("\nLa agenda no está vacía.");
}   

//crear un diccionario a partir de una lista de tuplas
var listaPersonas = new List<(string Nombre, string Telefono)>
{
    ("Luis", "444555666"),
    ("Sofía", "777888999")
};
var diccionarioDesdeLista = listaPersonas.ToDictionary(p => p.Nombre, p => p.Telefono);// Crear diccionario desde la lista de tuplas
Console.WriteLine("\nDiccionario creado desde una lista de tuplas:");   // Imprimir el diccionario creado
foreach (var item in diccionarioDesdeLista)  // Imprimir el diccionario creado
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");// Imprimir el diccionario creado
}
//combinar dos diccionarios
var otroDiccionario = new Dictionary<string, string>
{
    {"Carlos", "000111222"},
    {"María", "333444555"} // Esta clave ya existe en el diccionario original
};
foreach (var item in otroDiccionario)// Combinar los dos diccionarios
{
    agenda[item.Key] = item.Value; // Esto agregará o actualizará el valor
}
Console.WriteLine("\nDespués de combinar con otro diccionario:\n");
foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}




//agregamos 5 datos al diccionario mediante un bucle
for (int i = 1; i < 5; i++)
{
    Console.Write("\nIngrese el nombre de la persona ");
    string? nombre = Console.ReadLine();
    Console.Write("Ingrese el teléfono de");
    string? telefonoNuevo = Console.ReadLine();// Agregar el nuevo par key-value al diccionario
    agenda.Add(nombre, telefonoNuevo);
}
Console.WriteLine("\nDespués de agregar 5 nuevos datos:\n");
foreach (var item in agenda)
{
    Console.WriteLine($"Nombre: {item.Key}, Teléfono: {item.Value}");
}

agenda.Clear();