//Miguel Zaiter 2025-0928

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool BestFriend { get; set; }

    public Contact(int id, string name, string lastname, string address,
                   string telephone, string email, int age, bool bestFriend)
    {
        Id = id;
        Name = name;
        Lastname = lastname;
        Address = address;
        Telephone = telephone;
        Email = email;
        Age = age;
        BestFriend = bestFriend;
    }

    public override string ToString()
    {
        return $"{Id}   {Name}   {Lastname}   {Address}   {Telephone}   {Email}   {Age}   {(BestFriend ? "Si" : "No")}";
    }
}

public class ContactManager
{
    public List<int> ids = new List<int>();
    public Dictionary<int, string> names = new Dictionary<int, string>();
    public Dictionary<int, string> lastnames = new Dictionary<int, string>();
    public Dictionary<int, string> addresses = new Dictionary<int, string>();
    public Dictionary<int, string> telephones = new Dictionary<int, string>();
    public Dictionary<int, string> emails = new Dictionary<int, string>();
    public Dictionary<int, int> ages = new Dictionary<int, int>();
    public Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

    public void AddContact()
    {
        Console.WriteLine("\nDigite el nombre:");
        string name = Console.ReadLine();

        Console.WriteLine("\nDigite el apellido:");
        string lastname = Console.ReadLine();

        Console.WriteLine("\nDigite la dirección:");
        string address = Console.ReadLine();

        Console.WriteLine("\nDigite el teléfono (solo números):");
        string telephone = Console.ReadLine();

        while (!telephone.All(char.IsDigit))
        {
            Console.WriteLine("*Entrada inválida. El teléfono debe contener solo números:*");
            telephone = Console.ReadLine();
        }

        Console.WriteLine("\nDigite el email:");
        string email = Console.ReadLine();

        Console.WriteLine("\nDigite la edad:");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
            Console.WriteLine("\n*Entrada inválida. Digite un número:*");

        Console.WriteLine("\nEs mejor amigo? 1. Sí o 2. No");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            Console.WriteLine("\n*Entrada inválida. Digite 1 o 2:*");

        bool isBestFriend = option == 1;

        int id = ids.Count + 1;

        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, telephone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);

        Console.WriteLine("Contacto agregado exitosamente!");
    }

    public void ShowContacts()
    {
        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine($"ID   Nombre   Apellido   Dirección   Teléfono   Email   Edad   Mejor Amigo?");
        Console.WriteLine("----------------------------------------------------------------------------------------------------");

        foreach (var id in ids)
        {
            string best = bestFriends[id] ? "Si" : "No";

            Console.WriteLine($"{id}   {names[id]}   {lastnames[id]}   {addresses[id]}   {telephones[id]}   {emails[id]}   {ages[id]}   {best}");
        }
    }

    public void SearchContact()
    {
        Console.WriteLine("\nDigite el nombre a buscar:");
        string search = Console.ReadLine().ToLower();

        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(search))
            {
                string best = bestFriends[id] ? "Si" : "No";

                Console.WriteLine($"{id}   {names[id]}   {lastnames[id]}   {addresses[id]}   {telephones[id]}   {emails[id]}   {ages[id]}   {best}");
            }
        }
    }

    public void ModifyContact()
    {
        Console.WriteLine("\nDigite el ID a modificar:");
        int id = int.Parse(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("\nID no encontrado.");
            return;
        }

        Console.WriteLine("\nNuevo nombre:");
        names[id] = Console.ReadLine();

        Console.WriteLine("\nNuevo apellido:");
        lastnames[id] = Console.ReadLine();

        Console.WriteLine("\nNueva dirección:");
        addresses[id] = Console.ReadLine();

        Console.WriteLine("\nNuevo teléfono:");
        telephones[id] = Console.ReadLine();

        Console.WriteLine("\nNuevo email:");
        emails[id] = Console.ReadLine();

        Console.WriteLine("\nNueva edad:");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
            Console.WriteLine("\n*Entrada inválida:*");
        ages[id] = age;

        Console.WriteLine("\nEs mejor amigo? 1. Sí | 2. No");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            Console.WriteLine("*Entrada inválida:*");

        bestFriends[id] = option == 1;

        Console.WriteLine("\nContacto modificado!");
    }

    public void DeleteContact()
    {
        Console.WriteLine("Digite el ID del contacto a eliminar:");
        int id = int.Parse(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("ID no encontrado.");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        ContactManager cm = new ContactManager();
        bool running = true;

        Console.WriteLine("Bienvenido a mi lista de Contactos");

        while (running)
        {
            Console.WriteLine(@"
----------------------------
1. Agregar Contacto     
2. Ver Contactos     
3. Buscar Contactos     
4. Modificar Contacto    
5. Eliminar Contacto     
6. Salir
----------------------------");

            Console.WriteLine("\nDigite una opción:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int option))
            {
                Console.WriteLine("Entrada inválida");
                continue;
            }

            switch (option)
            {
                case 1: cm.AddContact(); break;
                case 2: cm.ShowContacts(); break;
                case 3: cm.SearchContact(); break;
                case 4: cm.ModifyContact(); break;
                case 5: cm.DeleteContact(); break;
                case 6: running = false; break;
                default: Console.WriteLine("Opción inválida"); break;
            }
        }
    }
}
