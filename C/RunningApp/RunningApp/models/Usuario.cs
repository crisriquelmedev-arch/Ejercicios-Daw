public class Usuario
{
    private string Correo {get; set;}
    private string Password {get; set;}
    private List <Entrenamiento> Entrenamientos {get; set; }= new (); 

    public Usuario(string correo, string password){
        this.Correo = correo;
        this.Password = password;
    }

    public void AgregarEntrenamiento (Entrenamiento entrenamiento)
    {
        Entrenamientos.Add (entrenamiento);
    }

    public List<Entrenamiento> ObternerEntrenamientos()
    {
        return Entrenamientos;
    }
    
    public string ObtenerCorreo()
    {
        return Correo;
    }

    public bool VerificarPassword(string pass)
    {
        return pass == Password;
    }

   public void VaciarEntrenamientos()
    {
        Entrenamientos.Clear();
    }

}
