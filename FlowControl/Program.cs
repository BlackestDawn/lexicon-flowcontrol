namespace FlowControl;

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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry option '{input}' is not valid or not implemented yet");
                    Console.ResetColor();
                    break;
            }
        }
    }
}

static internal class Cinema
{
    private const int YouthMaxAge = 19;
    private const int PensionerMinAge = 65;

    static private CinemaAgeBracket CalcAgeBracket(int age)
    {
        if (age <= YouthMaxAge)
        {
            return CinemaAgeBracket.Youth;
        }
        else if (age >= PensionerMinAge)
        {
            return CinemaAgeBracket.Pensioner;
        }

        return CinemaAgeBracket.Standard;
    }

    static private void ShowPrice(CinemaAgeBracket bracket)
    {
        Console.WriteLine($"{bracket} price: {(int)bracket}kr");
    }

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not parse '{input}' into a valid age-number");
                Console.ResetColor();
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

        ShowPrice(CalcAgeBracket(age));
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
            totalCost += (int)CalcAgeBracket(age);
        }

        Console.WriteLine($"Total cost for {numTickets} persons is {totalCost}kr");
        Helpers.Pause();
    }
}

internal enum CinemaAgeBracket
{
    Youth = 80,
    Standard = 120,
    Pensioner = 90
}

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

        words = input.Split(" ");
        } while (words.Length < 3);

        Console.WriteLine($"The third words is: {words[2]}");
        Helpers.Pause();
    }
}

static internal class Helpers
{
    static public readonly string DoubleLine = new string('=', 40);

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

    static public void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadLine();
    }
}