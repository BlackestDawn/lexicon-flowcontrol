namespace FlowControl;

/*
*  Main program
*/
class Program
{
    static void Main(string[] args)
    {
        string[] menuLines = [
            "0. Quit",
            "1. Cinema (show ticket price based on age using if/switch)",
            "2. Bulk Cinema (buy tickets for multiple people in one go)",
            "3. Looping (prints your input 10 times on one row)",
            "4. String splitting (will print the third word from a sentence)"
        ];

        Console.WriteLine("Welcome to flowcontrol and string manipulation excercise");
        Console.WriteLine("You will be presented with a number of choices,");
        Console.WriteLine("each one representing one aspect/part of the excercise.");
        Console.WriteLine("Enter menu choices by their number.");

        while (true)
        {
            Helpers.PrintBanner("Main menu", ConsoleColor.Blue);
            foreach (var line in menuLines)
            {
                Console.WriteLine(line);
            }
            Console.Write("\nEnter your choice: ");

            var input = Console.ReadLine();

            Console.WriteLine("");
            switch (input)
            {
                case "0":
                    Console.WriteLine("Hope you had fun. Goodbye");
                    Environment.Exit(0);
                    break;
                case "1":
                    Cinema.BuyTicket();
                    break;
                case "2":
                    Cinema.BulkBuyTickets();
                    break;
                case "3":
                    LoopIt.Run();
                    break;
                case "4":
                    SplitThirdWord.Run();
                    break;
                default:
                    Helpers.ErrorMessage($"Sorry option '{input}' is not valid or not implemented yet");
                    break;
            }
        }
    }
}

/*
*  Class for input parsing exercise (Cinema)
*/
static internal class Cinema
{
    static private void WelcomeBanner()
    {
        Helpers.PrintBanner("Welcome to the Theoretical Cinema", ConsoleColor.Green);
    }

    static private int AskForNumber(string prompt)
    {
        while (true) {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int age) || age < 0)
            {
                Helpers.ErrorMessage($"Could not parse '{input}' into a valid age-number");
            }
            else
            {
                return age;
            }
        }
    }

    static public void BuyTicket()
    {
        WelcomeBanner();

        Console.WriteLine("Thank you for buying one ticket.");
        int age = AskForNumber("Please enter your age to see ticket price");

        Console.WriteLine(CinemaAgeBracket.FromAge(age));
        Helpers.Pause();
    }

     static public void BulkBuyTickets()
    {
        WelcomeBanner();

        int totalCost = 0;

        Console.WriteLine("Thank you for buying multiple tickets.");
        int numTickets = AskForNumber("Please enter number of tickets you want to buy");

        for (int i = 1; i <= numTickets; i++)
        {
            int age = AskForNumber($"Enter age for person {i}");
            totalCost += CinemaAgeBracket.FromAge(age).Price;
        }

        Console.WriteLine($"Total cost for {numTickets} persons is {totalCost}kr");
        Helpers.Pause();
    }
}

/*
*  Record for Cinema exercise
*/
internal record CinemaAgeBracket(string Bracket, int Price, int MaxAge)
{
    public static readonly CinemaAgeBracket Child = new ("Child", 0, 4);
    public static readonly CinemaAgeBracket Youth = new ("Youth", 80, 19);
    public static readonly CinemaAgeBracket Standard = new ("Standard", 120, 64);
    public static readonly CinemaAgeBracket Pensioner = new ("Pensioner", 90, 99);
    public static readonly CinemaAgeBracket Elderly = new ("Elderly", 0, int.MaxValue);

    // Collected in ascending MaxAge order for easy looping
    private static readonly IReadOnlyList<CinemaAgeBracket> All =
    [
        Child, Youth, Standard, Pensioner, Elderly
    ];

    public override string ToString() => $"{Bracket}: {Price}kr";

    public static CinemaAgeBracket FromAge(int Age) =>
        All.FirstOrDefault(g => Age <= g.MaxAge)
            ?? throw new ArgumentOutOfRangeException($"No age bracket found for age: {Age}");
}

/*
*  Class to handle looping exercise
*/
static internal class LoopIt
{
    static private void WelcomeBanner()
    {
        Helpers.PrintBanner("Loop your text", ConsoleColor.Magenta);
    }

    static public void Run()
    {
        WelcomeBanner();

        Console.WriteLine("So you want to loop some text.");
        Console.Write("Please enter a word or two: ");
        string input = Console.ReadLine();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. {input} ");
        }
        Console.WriteLine();
        Helpers.Pause();
    }
}

/*
*  Class to handle string splitting exercise
*/
static internal class SplitThirdWord
{
    static private void WelcomeBanner()
    {
        Helpers.PrintBanner("Split it", ConsoleColor.Yellow);
    }

    static public void Run()
    {
        WelcomeBanner();

        string[] words;
        do {
            Console.WriteLine("Please enter at least 3 words separated by spaces: ");
            string input = Console.ReadLine();

            words = input.Split(" ").Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();
            if (words.Length < 3)
            {
                Helpers.ErrorMessage("Not enough valid words provided, try again");
            }
        } while (words.Length < 3);

        Console.WriteLine($"The third words is: {words[2]}");
        Helpers.Pause();
    }
}

/*
*  Various helper function
*/
static internal class Helpers
{
    static public readonly string DoubleLine = new string('=', 40);

    // Print supplied text between two rows of equalsigns
    // Color equalsigns with supplied color
    static public void PrintBanner(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine("\n" + DoubleLine);
        Console.ResetColor();
        Console.WriteLine(text);
        Console.ForegroundColor = color;
        Console.WriteLine(DoubleLine + "\n");
        Console.ResetColor();
    }

    // Pause execution so user can read result
    static public void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadLine();
    }

    // Print supplied text in red
    static public void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{message}\n");
        Console.ResetColor();
    }
}