// Deel 1
string[] namen = { "Peter", "Tom", "Piet", "Ahmed", "Benny", "Anna", "Jane", "Ali", "John", "Tom" };

Console.Write("Geef een naam: ");
string naam = Console.ReadLine();


Console.WriteLine($"De naam {naam} staat op index: {Array.IndexOf(namen, naam)}.");


// Deel 2
Console.Write("Geef een letter: ");
string letterVanNaam = Console.ReadLine().ToUpper();
string[] nameStartsWithLetter = Array.FindAll(namen, name => name.StartsWith(letterVanNaam));

Console.Write($"Namen die beginnen met {letterVanNaam}: ");
foreach (string name in nameStartsWithLetter)
{
        Console.Write(name + " ");
}
Console.WriteLine("");

// Deel 3
int getal1;
int getal2;
do
{
    Console.WriteLine($"geef een getal tussen 1 en {namen.Length}");
    string getal1AlsString = Console.ReadLine();
    Console.WriteLine($"geef een tweede getal tussen 1 en {namen.Length}");
    string getal2AlsString = Console.ReadLine();

    getal1 = Convert.ToInt32(getal1AlsString);
    getal2 = Convert.ToInt32((getal2AlsString));

    if (getal1 > namen.Length || getal2 > namen.Length || getal1 < 1 || getal2 < 1)
    {
        Console.WriteLine("Foutive getal ingevuld.");
        getal1 = 20;
        getal2 = 0;
    }

    Array.Sort(namen, getal1, getal2);
    foreach (string name in namen)
    {
        Console.WriteLine(name);
    }
}
while (getal1 > 19);





//
