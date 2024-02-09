using System;

class Program
{
    static void Main()
    {
        while (true)
        {

            Console.WriteLine("WITAJ W GRZE `SEKRETNA LICZBA`\n");
            Console.WriteLine("SPRÓBUJ ODGADNĄĆ LICZBĘ WYLOSOWANĄ PRZEZ KOMPUTER\n");
            Console.WriteLine("WYBIERZ POZIOM TRUDNOŚCI:\n");
            Console.WriteLine("1 => ŁATWY (LICZBA JEDNOCYFROWA, ILOŚĆ PRÓB: 2)\n");
            Console.WriteLine("2 => ŚREDNI (LICZBA DWUCYFROWA, ILOŚĆ PRÓB: 5)\n");
            Console.WriteLine("3 => TRUDNY (LICZBA TRZYCYFROWA, ILOŚĆ PRÓB: 8)\n");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");

            string input = Console.ReadLine();
            int level;
            if (!Int32.TryParse(input, out level))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NIEPRAWIDŁOWY ZNAK. WPROWADŹ LICZBĘ.\n");
                Console.ResetColor();
                continue;
            }

            int secretNumber, maxAttempts, rangeStart, rangeEnd;
            string levelName;

            switch (level)
            {
                case 1:
                    maxAttempts = 2;
                    rangeStart = 1;
                    rangeEnd = 9;
                    levelName = "ŁATWY";
                    break;
                case 2:
                    maxAttempts = 5;
                    rangeStart = 10;
                    rangeEnd = 99;
                    levelName = "ŚREDNI";
                    break;
                case 3:
                    maxAttempts = 8;
                    rangeStart = 100;
                    rangeEnd = 999;
                    levelName = "TRUDNY";
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy poziom trudności. Spróbuj ponownie.\n");
                    Console.ResetColor();

                    continue;
            }

            Console.Clear();
            Random rnd = new Random();
            secretNumber = rnd.Next(rangeStart, rangeEnd + 1);


            int previousGuess = 0;
            for (int i = 0; i < maxAttempts; i++)
            {

                Console.WriteLine($"POZIOM GRY: {levelName}\n");
                Console.WriteLine($"ILOŚĆ POZOSTAŁYCH PRÓB: {maxAttempts - i}\n");
                if (i > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"POPRZEDNIO WYBRANA LICZBA: {previousGuess}\n");
                    Console.ResetColor();
                }
                Console.WriteLine($"PODAJ SWOJĄ LICZBĘ Z PRZEDZIAŁU: ({rangeStart}-{rangeEnd})\n");

                input = Console.ReadLine();
                int guess;
                if (!Int32.TryParse(input, out guess))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEPRAWIDŁOWY ZNAK. WPROWADŹ LICZBĘ.\n");
                    Console.ResetColor();
                    i--;
                    continue;
                }

                if (guess < rangeStart || guess > rangeEnd)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NIEPRAWIDŁOWA LICZBA\n");
                    Console.ResetColor();
                    i--;
                }
                else if (guess == secretNumber)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GRATULACJE! ODGADŁEŚ SEKRETNĄ LICZBĘ!\n");
                    Console.ResetColor();
                    break;
                }
                else if (guess > secretNumber)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("TWOJA LICZBA JEST ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("WIĘKSZA ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("OD SEKRETNEJ LICZBY\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("TWOJA LICZBA JEST ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("MNIEJSZA ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("OD SEKRETNEJ LICZBY\n");
                    Console.ResetColor();
                }

                previousGuess = guess;
            }


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NIESTETY !!!, SKOŃCZYŁY SIĘ PRÓBY\n");
            Console.ResetColor();
            Console.WriteLine("SEKRETNA LICZBA TO: " + secretNumber + "\n");
            Console.WriteLine("Naciśnij dowolny klawisz, aby spróbować ponownie...\n");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
