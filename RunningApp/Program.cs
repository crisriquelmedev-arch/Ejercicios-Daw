public class RunningApp
{
    public static void Main (string[] args)
    {
        bool isRuning = true;
        List<Usuario> usuarios = new List<Usuario>();

        do
        {
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
                    
                break;    
            }
        }while(!isRuning);
        

    }
}