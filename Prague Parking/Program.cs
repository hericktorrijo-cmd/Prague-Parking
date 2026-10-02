using System.ComponentModel.Design;
using System.Net;

string[] garageSpaces = new string[100];

//Tilldelar samtliga platser lediga för att börja med
for (int i = 0; i < garageSpaces.Length; i++)
{
    garageSpaces[i] = "LEDIG";
}


Menu(garageSpaces);


static void Menu(string[] garageSpaces)
{
    while (true)
    {
        Console.WriteLine("\n=== GARAGE-MENY ===\n");
        Console.WriteLine("1. Parkera fordon");
        Console.WriteLine("2. Ta bort fordon");
        Console.WriteLine("3. Flytta fordon manuellt");
        Console.WriteLine("4. Visa platser");
        Console.WriteLine("5. Visa specifik plats");
        Console.WriteLine("0. Avsluta");
        Console.Write("Välj ett alternativ: ");

        bool inputOk = int.TryParse(Console.ReadLine(), out int menuInput);

        if (!inputOk)
        {
            Console.WriteLine("Ogiltigt val.");
            continue;
        }

        switch (menuInput)
        {
            case 1:
                string vehicleType = GetVehicleType();
                string licenseNumber = GetLicenseNumber();
                string fullLicenceNumber = FullLicenseNumber(vehicleType, licenseNumber);
                ParkVehicle(fullLicenceNumber, garageSpaces);
                
                break;
            case 2:
                string licenceNumberToRemove = GetLicenseNumber();
                RemoveVehicle(garageSpaces, licenceNumberToRemove);
                break;
            case 3:
                MoveVehicleManually(garageSpaces);
                break;
            case 4:
                ParkingSpots(garageSpaces);
                break;
            case 5:
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

//Metod för att få fordonstypen // MENYVAL 1.1
static string GetVehicleType()
{
    string vehicleType;
    while (true)
    {

        Console.Write("Bil eller MC: ");
        string input = Console.ReadLine().Trim().ToLower();
        if (input == "bil")
        {
            vehicleType = "CAR";
        }
        else if (input == "mc")
        {
            vehicleType = "MC";
        }
        else
        {
            Console.WriteLine("Ogiltigt val, skriv Bil eller MC");
            continue;
        }
        break;
    }
    return vehicleType;
}

//Metod för att få regnumret t.ex ABC123 // MENYVAL 1.2
static string GetLicenseNumber()
{
    
    while (true)
    {
        Console.Write("Skriv registreringsnummer: ");
        string licenseNumber = Console.ReadLine().Trim().ToUpper();
        if (licenseNumber.Length > 10)
        {
            Console.WriteLine("registreringsnummer får inte vara mer än 10 tecken");
            continue;
        }

        bool confirmed = false;

        while (!confirmed)
        {
            Console.Write($"Du skrev {licenseNumber.Trim().ToUpper()}. Skriv 1 för att fortsätta eller 2 för att backa: ");
            string userChoice = Console.ReadLine().Trim();
            if (userChoice == "1")
            {
                confirmed = true;
            }
            else if (userChoice == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning.");
            }
        }

        if(confirmed)
        {
            return licenseNumber;
        }
    }
}

//Metod för att kombinera fordonstyp och reg-nummer och göra ett fulltständigt ID //MENY 1.3 
static string FullLicenseNumber(string vehicleType, string licenseNumber)
{
    string fullLicenseNumber = vehicleType + "#" + licenseNumber.ToUpper().Trim();

    return fullLicenseNumber;
}

//Metod för att parkera fordon både MC och bil // MENY 1.4
static void ParkVehicle(string fullLicenceNumber, string[] garageSpaces)
{
    if (fullLicenceNumber.StartsWith("CAR"))
    {
        for (int i = 0; i < garageSpaces.Length; i++)
        {
            if (garageSpaces[i] == "LEDIG")
            {
                garageSpaces[i] = fullLicenceNumber;
                Console.WriteLine($"Parkera {fullLicenceNumber} på parkeringsplats {i + 1}");
                return;
            }
        }
        Console.WriteLine("Inga bil-platser kvar, garage full");
        return;
    }
    else if (fullLicenceNumber.StartsWith("MC"))
    {
        for (int i = 0; i < garageSpaces.Length; i++)
        {
            if (garageSpaces[i].StartsWith("MC") && !garageSpaces[i].Contains("|"))
            {
                garageSpaces[i] = garageSpaces[i] + " | " + fullLicenceNumber;
                Console.WriteLine($"Parkera {fullLicenceNumber} på parkeringsplats {i + 1} (delad MC plats)");
                return;
            }
        }
        for(int i = 0; i < garageSpaces.Length; i++)
        {
            if (garageSpaces[i] == "LEDIG")
            {
                garageSpaces[i] = fullLicenceNumber;
                Console.WriteLine($"Parkera {fullLicenceNumber} på parkeringsplats {i + 1}");
                return;
            }


        }
        Console.WriteLine("Garaget är fullt!");
        return;
    }
}
//Metod för att manuellt flytta fordon från en plats till en annan // MENY 2.0

static void MoveVehicleManually(string[] garageSpaces)
{
    string licenseNumber = GetLicenseNumber();
    string fullCar = "CAR#" + licenseNumber;
    string fullMc = "MC#" + licenseNumber;

    bool isCar = false;
    bool isMc = false;

    foreach(string spot in  garageSpaces)
    {
        if (spot == fullCar)
        {
            isCar = true;
            break;
        }
        else if(spot.Contains(fullMc))
        {
            isMc = true;
            break;
        }
    }

    if(!isCar && !isMc)
    {
        Console.WriteLine("Fordonet hittades inte i garaget.");
        return;
    }

    RemoveVehicle(garageSpaces, licenseNumber);
    PlaceVehicleManually(garageSpaces, licenseNumber, isCar);
}

//Metod för att placera fordon manuellt, ska främst användas i metoden ovanför (MoveVehicleManually) // MENY 2.1
//Det vi har är licenseNumber och vi har tagit bort den från en plats, så vi behöver att den här metoden placerar i valfri plats
static void PlaceVehicleManually(string[] garageSpaces, string licenseNumber, bool isCar)
{

    int garageSpaceInt;

    while (true)
    {
        Console.Write("Vilken plats vill du parkera fordonet på: ");
        bool validInput = int.TryParse(Console.ReadLine(), out garageSpaceInt);
        if (validInput != true)
        {
            Console.WriteLine("Det måste vara en plats från 1 - 100");
            continue;
        }
        if(validInput)
        {
            break;
        }
    }

    string spot = garageSpaces[garageSpaceInt - 1];

    if(spot == "LEDIG")
    {
        Console.WriteLine("Platsen är ledig.");
    }
    else
    {
        Console.WriteLine($"Platsen är tagen: {spot}");
    }

    string fullLicenseNumber;
    if (isCar)
    {
        fullLicenseNumber = "CAR#" + licenseNumber;
    }
    else
    {
        fullLicenseNumber = "MC#" + licenseNumber;
    }

    if(isCar)
    {
        if(spot == "LEDIG")
        {
            garageSpaces[garageSpaceInt - 1] = fullLicenseNumber;
            Console.WriteLine($"Fordonet {fullLicenseNumber} har parkerats på plats {garageSpaceInt}");
            return;
        }
        
        else
        {
            Console.WriteLine("Platsen är upptagen.");
            return;
        }
    }
    if(!isCar)
    {
        if(spot == "LEDIG")
        {
            garageSpaces[garageSpaceInt -1] = fullLicenseNumber;
            Console.WriteLine($"MC {fullLicenseNumber} har parkerats på plats {garageSpaceInt}");
            return;
        }
        if (spot.StartsWith("MC") && !spot.Contains("|"))
        {
            garageSpaces[garageSpaceInt - 1] = spot + " | " + fullLicenseNumber;
            Console.WriteLine($"MC {fullLicenseNumber} har delat plats på {garageSpaceInt}");
            return;
        }

        Console.WriteLine("Platsen är upptagen.");
        return;
    }
}
//Metod för att ta bort fordon // MENY 3.0
static void RemoveVehicle(string[] garageSpaces, string licenseNumber)
{
    
    string fullCar = "CAR#" + licenseNumber;
    string fullMc = "MC#" + licenseNumber;

    for (int i = 0; i < garageSpaces.Length; i++)
    {
        string spot = garageSpaces[i];

        if (spot == fullCar)
        {
            garageSpaces[i] = "LEDIG";
            Console.WriteLine($"{fullCar} borttaget från plats {i + 1}");
            return;
        }
        if (spot.Contains(fullMc))
        {
            string[] mcList = spot.Split(" | ");

            List<string> remaining = new List<string>();

            for(int j = 0; j < mcList.Length; j++)
            {
                if(mcList[j] != fullMc)
                {
                    remaining.Add(mcList[j]);
                }
            }

            if(remaining.Count == 0)
            {
                garageSpaces[i] = "LEDIG";
            }
            else
            {
                garageSpaces[i] = string.Join(" | ", remaining);
            }
            Console.WriteLine($"{fullMc} borttaget från plats {i + 1}");
            return;
        }
    }
    Console.WriteLine($"Hittade inget fordon med det angivna regristeringsnumret");
}

//Metod för att skriva ut tillgänglighet, man kan se samtliga platser eller mellan 2 tal // MENYVAL 3
static void ParkingSpots(string[] garageSpaces, int min = 1, int max = 100)
{
    int start;
    int end;
    while (true)
    {
        Console.WriteLine("Skriv mellan vilka platser du vill se tillgängliga parkeringsplatser 1 - 100");
        Console.Write("Startplats: ");
        bool firstNumber = int.TryParse(Console.ReadLine(), out start);
        Console.Write("Slutplatsplats: ");
        bool secondNumber = int.TryParse(Console.ReadLine(), out end);

        if (!firstNumber || !secondNumber)
        {
            Console.WriteLine("Du måste skriva siffror.");
            continue;
        }
        if (start < 1 || end > garageSpaces.Length || start > end)
        {
            Console.WriteLine("Ogiltig intervall.");
            continue;
        }
        break;
    }
    //Console.Write("Nummer 1: ");
    //bool nummerEtt = int.TryParse(Console.ReadLine(), out min);
    //Console.Write("Nummer 2: ");
    //bool nummerTvå = int.TryParse(Console.ReadLine(), out max);

    for (int plats = start; plats <= end; plats++)
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

        Console.WriteLine($"Plats {plats,-5} => {garageSpaces[index],-20}");
        Console.ResetColor();
    }
}

//Metod för att se tillgänglighet på en specifik plats // MENYVAL 4
static void SpecificSpot(string[] garageSpaces)
{
    Console.WriteLine("Vilken plats vill du se: ");
    bool input = int.TryParse(Console.ReadLine(), out int number);
    if (!input || number < 1 || number > garageSpaces.Length)
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
    else if (status.StartsWith("MC") && !status.Contains("|"))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine($"Plats {number,-5} => {garageSpaces[index],-20}");

    Console.ResetColor();
}

