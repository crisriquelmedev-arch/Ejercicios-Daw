public class Calculadora
{   
    
    public int Sumar(int a, int b)
    {
        return a + b;
    }

    public int Restar(int a, int b)
    {
        return a - b;
    }

    public int Multiplicar(int a, int b)
    {
        return a * b;
    }

    public double Dividir(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("No se puede dividir por cero.");
        }
        return (double)a / b;
    }
}