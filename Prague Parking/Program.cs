string[] garageSpaces = new string[100];

//Tilldelar samtliga platser lediga för att börja med
for(int i = 0; i < garageSpaces.Length; i++)
{
    garageSpaces[i] = "LEDIG";
}

garageSpaces[0] = "FFG859";
garageSpaces[1] = "MCFFASF";

Menu(garageSpaces);

static void Menu(string[] garageSpaces)
{
    while(true)
    {
        Console.WriteLine("\n=== GARAGE-MENY ===\n");
        Console.WriteLine("1. Parkera fordon");
        Console.WriteLine("2. Ta bort fordon");
        Console.WriteLine("3. Visa platser");
        Console.WriteLine("4. Visa specifik plats");
        Console.WriteLine("0. Avsluta");
        Console.Write("Välj ett alternativ: ");

        bool inputOk = int.TryParse(Console.ReadLine(), out int menuInput);

        if(!inputOk)
        {
            Console.WriteLine("Ogiltigt val.");
            continue;
        }

        switch(menuInput)
        {
            case 1:
                Console.WriteLine("Parkera fordon"); // här ska jag föra in en ny metod
                break;
            case 2:
                Console.WriteLine("Ta bort fordon"); // här ska jag också göra en ny metod
                break;
            case 3:
                parkingSpots(garageSpaces);
                break;
            case 4:
                SpecificSpot(garageSpaces);
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Ogiltigt val");
                break;
        }

    }
}

//Metod för att skriva ut tillgänglighet, man kan välja om man skulle vilja se specifika platser // MENYVAL 3
static void parkingSpots(string[] garageSpaces, int min = 1, int max = 100)
{

   for(int plats = min; plats <= max; plats++)
    {
        int index = plats - 1;
        string status = garageSpaces[index];

        if (status == "LEDIG")
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (status.StartsWith("MC") && !status.Contains("|"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine($"Plats {plats, -5} => {garageSpaces[index], -10}");
        Console.ResetColor();
    }
}

//Metod för att se tillgänglighet på en specifik plats // MENYVAL 4
static void SpecificSpot(string[] garageSpaces)
{
    Console.WriteLine("Vilken plats vill du se: ");
    bool input = int.TryParse(Console.ReadLine(), out int number);
    if(!input || number < 1 || number > garageSpaces.Length)
    {
        Console.WriteLine("Ogiltig platsnummer.");
            return;
    }
    int index = number - 1;
    string status = garageSpaces[index];

    if (status == "LEDIG")
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else if(status.StartsWith("MC") && !status.Contains("|"))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine($"Plats {number,-5} => {garageSpaces[index],-10}");

    Console.ResetColor();
}

