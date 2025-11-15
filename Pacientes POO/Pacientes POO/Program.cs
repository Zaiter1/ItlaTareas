//MIGUEL ZAITER 2025-0928
// Desarrolle con los conocimientos adquiridos de POO, un sistema de registros de pacientes.

public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Enfermedad { get; set; }

    public Paciente(int id, string nombre, int edad, string enfermedad)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Enfermedad = enfermedad;
    }

    public override string ToString()
    {
        return $"{Id}   {Nombre}   {Edad} años   Sufre de: {Enfermedad}";
    }
}

public class PacienteManager
{
    public List<int> ids = new List<int>();
    public Dictionary<int, string> nombres = new Dictionary<int, string>();
    public Dictionary<int, int> edades = new Dictionary<int, int>();
    public Dictionary<int, string> enfermedades = new Dictionary<int, string>();

    public void AgregarPaciente()
    {
        Console.WriteLine("\nDigite el nombre del paciente:");
        string nombre = Console.ReadLine();

        // Validación: no permitir números en el nombre
        while (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit))
        {
            Console.WriteLine(" Entrada inválida. El nombre no debe contener números:");
            nombre = Console.ReadLine();
        }

        Console.WriteLine("\nDigite la edad:");
        int edad;
        while (!int.TryParse(Console.ReadLine(), out edad))
            Console.WriteLine(" Entrada inválida. Digite un número:");

        Console.WriteLine("\nDigite la enfermedad que sufre:");
        string enfermedad = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(enfermedad) || enfermedad.Any(char.IsDigit))
        {
            Console.WriteLine(" Entrada inválida. La enfermedad debe contener solo letras:");
            enfermedad = Console.ReadLine();
        }

        int id = ids.Count + 1;

        ids.Add(id);
        nombres.Add(id, nombre);
        edades.Add(id, edad);
        enfermedades.Add(id, enfermedad);

        Console.WriteLine(" Paciente agregado exitosamente!");
    }

    public void MostrarPacientes()
    {
        Console.WriteLine("\n--- Lista de Pacientes ---");
        foreach (var id in ids)
        {
            Console.WriteLine($"{id}   {nombres[id]}   {edades[id]} años   Sufre de: {enfermedades[id]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PacienteManager pm = new PacienteManager();
        bool running = true;

        Console.WriteLine("Bienvenido al Registro de Pacientes");

        while (running)
        {
            Console.WriteLine(@"
----------------------------
1. Agregar Paciente     
2. Ver Pacientes     
3. Salir
----------------------------");

            Console.WriteLine("\nDigite una opción:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int option))
            {
                Console.WriteLine(" Entrada inválida");
                continue;
            }

            switch (option)
            {
                case 1: pm.AgregarPaciente(); break;
                case 2: pm.MostrarPacientes(); break;
                case 3: running = false; break;
                default: Console.WriteLine(" Opción inválida"); break;
            }
        }
    }
}
