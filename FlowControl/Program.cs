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
    private const int YouthPrice = 80;
    private const int PensionerMinAge = 65;
    private const int PensionerPrice = 90;
    private const int StandardPrice = 120;

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

    static private int GetBracketPrice(CinemaAgeBracket bracket) =>
    bracket switch
    {
      CinemaAgeBracket.Young => YouthPrice,
      CinemaAgeBracket.Standard => StandardPrice,
      CinemaAgeBracket.Pensioner => PensionerPrice,
      _ => throw new ArgumentException($"unknown or unsupported age bracket: '{bracket}'"),
    };

    static private void ShowPrice(CinemaAgeBracket bracket)
    {
        Console.WriteLine($"{bracket} price: {GetBracketPrice(bracket)}kr");
    }

    static public void BuyTicket()
    {
        Helpers.PrintBanner("Welcome to the Theoretical Cinema", ConsoleColor.Green);

        int age;
        bool done = false;
        do
        {
            Console.Write("Please enter your age to see ticket price: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out age) || age < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not parse '{input}' into a valid age-number");
                Console.ResetColor();
                continue;
            }
            else
            {
                done = true;
            }
        } while (!done);

        ShowPrice(CalcAgeBracket(age));
    }
}

internal enum CinemaAgeBracket
{
    Young,
    Standard,
    Pensioner
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