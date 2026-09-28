using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // man gör två listor här, en för varunamn och en för priser
        List<string> varunamn = new List<string>();
        List<int> priser = new List<int>();

        // 2. det är en oändlig loop som körs tills användaren avslutar programmet
        while (true)
        {
            Console.WriteLine("\n--- Din Inköpslista ---");

            int totalt = 0;

            for (int i = 0; i < varunamn.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {varunamn[i]} -{priser[i]} kr");
                totalt += priser[i];
            }
            Console.WriteLine($"Totalt: {totalt} kr");

            Console.WriteLine("\nSkriv en vara för att lägga till, eller ett nummer för att ta bort:");
            string input = Console.ReadLine();

            // 3. här kontrollerar vi att om användaren skriver in ett nummer, tas varan bort från listan
            if (int.TryParse(input, out int nummer))
            {
                //  BORTTAGNING 
                // Användaren ser 1, 2, 3 på skärmen men listans index börjar på 0. Därför subtraherar vi 1.
                int index = nummer - 1;

                // man kan kontrollera att numret faktiskt finns i listan för att undvika krasch
                if (index >= 0 && index < varunamn.Count)
                {
                    varunamn.RemoveAt(index);
                    priser.RemoveAt(index);
                    Console.WriteLine("Varan har tagits bort!");
                }
                else
                {
                    // Om numret inte finns, visa ett felmeddelande i stället för att krascha
                    Console.WriteLine("Det numret finns inte i listan.");
                }
            }
            else if (!string.IsNullOrWhiteSpace(input))
            {
                //  LÄGGA TILL 
                // Om  input inte är ett nummer och inte är tom, är det ett varunamn.
                Console.WriteLine("Vad kostar den?");
                string prisInput = Console.ReadLine();

                // här vi kontrolerar vi att om priset är ett giltigt heltal
                if (int.TryParse(prisInput, out int pris))
                {
                    // Lägg till i båda listorna samtidigt för att hålla dem i synk
                    varunamn.Add(input);
                    priser.Add(pris);
                    Console.WriteLine("Varan har lagts till!");
                }
                else
                {
                    // Om priset inte är ett heltal, läggs varan inte till och ett felmeddelande visas
                    Console.WriteLine("Ogiltigt pris. Varan lades inte till.");
                }


            }
        }
    }
}
