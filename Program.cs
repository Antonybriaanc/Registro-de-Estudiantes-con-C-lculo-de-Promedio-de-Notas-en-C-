using System;

// Definición de la estructura Estudiante
struct Estudiante
{
    public string nombre;
    public int edad;
    public double nota;
}

class Program
{
    static void Main(string[] args)
    {
        // Solicitar al usuario la cantidad de estudiantes
        int cantidadEstudiantes = SolicitarNumero("Ingrese la cantidad de estudiantes: ");

        // Declarar un arreglo de estudiantes
        Estudiante[] estudiantes = new Estudiante[cantidadEstudiantes];

        // Variables para calcular el promedio de notas y contar la cantidad de estudiantes mayores de edad
        double sumaNotas = 0;
        int contadorMayoresEdad = 0;

        // Solicitar los datos de cada estudiante
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"\nIngrese los datos del estudiante {i + 1}:");
            string nombre = "";

            // Validar el nombre del estudiante
            do
            {
                nombre = SolicitarTexto("Nombre: ");
                if (!EsNombreValido(nombre))
                {
                    Console.WriteLine("El nombre no puede contener números ni símbolos.");
                }
            } while (!EsNombreValido(nombre));

            int edad = 0;
            double nota = 0;

            // Validar la edad del estudiante
            do
            {
                edad = SolicitarNumeroEntero("Edad: ");
                if (edad < 15)
                {
                    Console.WriteLine("La edad mínima permitida es 15.");
                }
            } while (edad < 15);

            // Validar la nota del estudiante
            do
            {
                nota = SolicitarNumeroDecimal("Nota: ");
                if (nota < 0 || nota > 20)
                {
                    Console.WriteLine("La nota debe estar en el rango de 0 a 20.");
                }
            } while (nota < 0 || nota > 20);

            // Guardar los datos en el arreglo de estudiantes
            estudiantes[i].nombre = nombre;
            estudiantes[i].edad = edad;
            estudiantes[i].nota = nota;

            // Sumar las notas para calcular el promedio
            sumaNotas += nota;

            // Contar la cantidad de estudiantes mayores de edad
            if (edad >= 18)
            {
                contadorMayoresEdad++;
            }
        }

        // Calcular el promedio de notas
        double promedioNotas = sumaNotas / cantidadEstudiantes;

        // Mostrar la información
        Console.WriteLine($"\nPromedio de notas de la sección: {promedioNotas:F2}");
        Console.WriteLine($"Cantidad de estudiantes mayores de edad: {contadorMayoresEdad}");

        Console.ReadLine();
    }

    // Función para validar si un nombre contiene solo letras y espacios en blanco
    static bool EsNombreValido(string nombre)
    {
        foreach (char c in nombre)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    // Función para solicitar un número entero al usuario con validación
    static int SolicitarNumeroEntero(string mensaje)
    {
        int numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = int.TryParse(Console.ReadLine(), out numero);
            if (!esNumero)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico entero.");
            }
        } while (!esNumero);
        return numero;
    }

    // Función para solicitar un número decimal al usuario con validación
    static double SolicitarNumeroDecimal(string mensaje)
    {
        double numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = double.TryParse(Console.ReadLine(), out numero);
            if (!esNumero)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico decimal.");
            }
        } while (!esNumero);
        return numero;
    }

    // Función para solicitar un texto al usuario
    static string SolicitarTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }

    // Función para solicitar un número al usuario con validación
    static int SolicitarNumero(string mensaje)
    {
        int numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = int.TryParse(Console.ReadLine(), out numero);
            if (!esNumero || numero <= 0)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico entero mayor que cero.");
            }
        } while (!esNumero || numero <= 0);
        return numero;
    }
}
