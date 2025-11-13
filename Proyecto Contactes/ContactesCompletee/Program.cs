//Miguel Zaiter 2025-0928

Console.WriteLine("Bienvenido a mi lista de Contactos");

bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

//while (runing)
//{
//    Console.WriteLine(@"
//----------------------------
//1. Agregar Contacto     
//2. Ver Contactos    
//3. Buscar Contactos     
//4. Modificar Contacto   
//5. Eliminar Contacto    
//6. Salir
//----------------------------");
//    Console.WriteLine("Digite el número de la opción deseada");

//    int typeOption = Convert.ToInt32(Console.ReadLine());
while (runing)
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
    Console.WriteLine("Digite el número de la opción deseada");

    string input = Console.ReadLine();
    int typeOption;

    if (!int.TryParse(input, out typeOption))
    {
        Console.WriteLine("*Entrada inválida. Por favor, digite un número del menú.*");
        continue;
    }



    switch (typeOption)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 2:
            ShowContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 3:
            SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 4:
            ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 5:
            DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 6:
            runing = false;
            break;

        default:
            Console.WriteLine("*Opción inválida, intenta de nuevo.* ");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    int age;
    int bestFriendOption;


    Console.WriteLine("\nDigite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("\nDigite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("\nDigite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("\nDigite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("\nDigite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("\nDigite la edad de la persona en números");

    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.WriteLine("*Entrada inválida. Por favor, digite la edad en números* :");
    }

    Console.WriteLine("\nEspecifique si es mejor amigo: 1. Si, 2. No");

    while (!int.TryParse(Console.ReadLine(), out bestFriendOption) || (bestFriendOption != 1 && bestFriendOption != 2))
    {
        Console.WriteLine("*Entrada inválida. Por favor digite 1 para Sí o 2 para No* :");
    }
    bool isBestFriend = bestFriendOption == 1;


    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

    Console.WriteLine("Contacto agregado exitosamente!");
}

static void ShowContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
    Console.WriteLine($"ID       Nombre       Apellido       Dirección       Telefono       Email       Edad       Mejor Amigo?");
    Console.WriteLine($"__________________________________________________________________________________________________________");
    foreach (var id in ids)
    {
        string isBestFriendStr = bestFriends[id] ? "Si" : "No";
        Console.WriteLine($"{id}   {names[id]}   {lastnames[id]}   {addresses[id]}   {telephones[id]}   {emails[id]}   {ages[id]}   {isBestFriendStr}");
    }
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre a buscar:");
    string searchName = Console.ReadLine();

    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(searchName.ToLower()))
        {
            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
            Console.WriteLine($"{id}   {names[id]}   {lastnames[id]}   {addresses[id]}   {telephones[id]}   {emails[id]}   {ages[id]}   {isBestFriendStr}");
        }
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el ID del contacto a modificar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (ids.Contains(id))
    {
        Console.WriteLine("Digite el nuevo nombre:");
        names[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo apellido:");
        lastnames[id] = Console.ReadLine();
        Console.WriteLine("Digite la nueva dirección:");
        addresses[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo teléfono:");
        telephones[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo email:");
        emails[id] = Console.ReadLine();
        Console.WriteLine("Digite la nueva edad:");
        ages[id] = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Es mejor amigo? 1. Si, 2. No");
        bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;

        Console.WriteLine("Contacto modificado exitosamente!");
    }
    else
    {
        Console.WriteLine("ID no encontrado.");
    }
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el ID del contacto a eliminar:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (ids.Contains(id))
    {
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado exitosamente!");
    }
    else
    {
        Console.WriteLine("ID no encontrado.");
    }
}

