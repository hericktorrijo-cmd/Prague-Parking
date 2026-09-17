Console.WriteLine("orale");

Console.Write("Ange en ålder: ");
if (int.TryParse(Console.ReadLine(), out int result))
{
    if (result > 17)
    {
        Console.WriteLine($"Du har fyllt {result} år, grattis du är myndig");
    }
    else if (result <= 17)
    {
        Console.WriteLine($"Du har inte fyllt 18 än, men du är {result} gammal, grattis!");
    }
}
else
{
    Console.WriteLine("ERROR: Vänligen skriv in ett heltal");
}
