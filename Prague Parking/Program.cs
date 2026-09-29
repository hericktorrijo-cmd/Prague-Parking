string[] garageSpaces = new string[100];


//Tilldelar samtliga platser lediga för att börja med
for(int i = 0; i < garageSpaces.Length; i++)
{
    garageSpaces[i] = "LEDIG";
}

//parkingSpots(garageSpaces, 21, 21);
SpecificSpot(garageSpaces);

//parkingSpots(garageSpaces, 1, 10);


//Metod för att skriva ut tillgänglighet, man kan välja om man skulle vilja se specifika platser
static void parkingSpots(string[] garageSpaces, int min = 1, int max = 100)
{
   for(int plats = min; plats <= max; plats++)
    {
        int index = plats - 1;
        Console.WriteLine($"Plats {plats} => {garageSpaces[index]}");
    }
}

//Metod för att se tillgänglighet på en specifik plats
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

    Console.WriteLine($"Plats {number} => {garageSpaces[index]}");
  
}