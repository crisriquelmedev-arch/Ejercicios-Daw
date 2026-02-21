public class RunningApp
{
    public static void Main (string[] args)
    {
        bool isRuning = false;
        List<Usuario> usuarios = new List<Usuario>();
        Usuario? usuarioActual = null;

        do
        {
            //inicio sesión aplicación
            Console.WriteLine("Bienvenidos a la Aplicación de Running");
            Console.WriteLine("Selecciona una opción");
            Console.WriteLine("1 Registrar Usuario");
            Console.WriteLine("2 iniciar Sesión");
            Console.WriteLine("3 Salir");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese su Correo:");
                    string? correo = Console.ReadLine();
                    bool existe = false;
                    
                    foreach (Usuario user in usuarios)
                    {
                       if(user.ObtenerCorreo() == correo){
                            existe = true;
                            break;
                        } 
                    }

                    if (existe)
                    {
                        Console.WriteLine("El usuario ya existe");
                    }else
                    {
                        Console.WriteLine("Ingrese su contraseña");
                        string? password = Console.ReadLine();

                        Usuario nuevoUsuario = new Usuario(correo!, password!);
                        usuarios.Add(nuevoUsuario);

                        Console.WriteLine("Usuario registrado");
                    }
                break;
                
                case "2":
                    Console.WriteLine("Ingrese su correo:");
                    string ?correoLogin = Console.ReadLine();
                    Console.WriteLine("Ingrese su contraseña:");
                    string ?passLogin = Console.ReadLine();

                    Usuario ?buscarUsuario = null;

                    foreach (Usuario user in usuarios)
                    {
                        if(user.ObtenerCorreo() == correoLogin)
                        {
                            buscarUsuario = user;
                            break;
                        }
                    }

                    if (buscarUsuario == null)
                    {
                        Console.WriteLine("No existe el usuario");
                    }else
                    {
                        if (buscarUsuario.VerificarPassword(passLogin!))
                        {
                            Console.WriteLine("Sesion iniciada correctamente" );
                            usuarioActual = buscarUsuario;
                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta");
                        }
                    }

                break;    

                case "3":
                    isRuning = true;
                    Console.WriteLine("Saliendo de la aplicación");
                break;

                default:
                    Console.WriteLine("Opción no valida, intente nuevamente");
                break;
            }
            //inicio sesión usuario 
            while(usuarioActual != null && isRuning == false)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 Registrar entrenamiento");
                Console.WriteLine("2 Ver entrenamientos");
                Console.WriteLine("3 Vaciar entrenamientos");
                Console.WriteLine("4 Cerrar sesión");
                string? opcionUsuario = Console.ReadLine(); 

                switch (opcionUsuario)
                {
                    case "1":
                        Console.WriteLine("Ingrese la distancia recorrida");
                        double distancia;
                        while(!double.TryParse(Console.ReadLine(),out distancia) || distancia < 0)
                        {
                            Console.WriteLine("Ingrese un numero valido para distancia");
                        }
                        Console.WriteLine("Ingrese el tiempo (en minutos):");
                        double tiempo;
                        while(!double.TryParse(Console.ReadLine(), out tiempo) || tiempo < 0)
                        {
                            Console.WriteLine("Ingrese un numero válido para el tiempo");
                        }

                        usuarioActual.AgregarEntrenamiento(new Entrenamiento(distancia, TimeSpan.FromMinutes(tiempo)));
                        Console.WriteLine("Entrenamiento registrado exitosamente");
                    break;

                    case "2":
                        Console.WriteLine("Entrenamientos registrados:");
                        foreach(var ent in usuarioActual.ObternerEntrenamientos())
                        {
                            Console.WriteLine(ent);
                        }

                    break;

                    case "3":
                        usuarioActual.VaciarEntrenamientos();
                        Console.WriteLine("Entrenamientos eliminados");
                    break;

                    case "4":
                        usuarioActual = null;
                        Console.WriteLine("Sesión cerrada, hasta luego!");
                    break;

                    default:
                        Console.WriteLine("Ingrese una opción válida");
                    break;
                }
            }
        }while(!isRuning);
        

    }
}