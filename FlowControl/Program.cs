namespace FlowControl;

class Program
{
    static void Main(string[] args)
    {
        string[] menuLines = [
            "0. Quit",
            "1. Cinema (show ticket price based on age using if/switch)",
            "2. Bulk Cinema (buy tickets for multiple people in one go)"
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
            return CinemaAgeBracket.Young;
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
    }

     static public void BulkBuyTickets()
    {
        WelcomeBanner();
    }
}

internal enum CinemaAgeBracket
{
    Young = 80,
    Standard = 120,
    Pensioner = 90
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
}