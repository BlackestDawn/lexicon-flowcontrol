namespace FlowControl;

class Program
{
    static void Main(string[] args)
    {
        string[] menuLines = [
            "0. Quit",
            "1. Cinema (show ticket price based on age using if)"
        ];

        Console.WriteLine("Welcome to flowcontrol and string manipulation excercise");
        Console.WriteLine("You will be presented with a number of choices,");
        Console.WriteLine("each one representing one aspect/part of the excercise.");
        Console.WriteLine("Enter menu choices by their number.");

        while (true)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Constants.DoubleLine);
            Console.ResetColor();
            Console.WriteLine("Main menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Constants.DoubleLine);
            Console.ResetColor();
            Console.Write("Enter your choice: ");

            var input = Console.ReadLine();

            Console.WriteLine("");
            switch (input)
            {
                case "0":
                    Console.WriteLine("Hope you had fun. Goodbye");
                    Environment.Exit(0);
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
    private const int YoutPrice = 80;
    private const int PensionerMinAge = 65;
    private const int PensionerPrice = 90;
    private const int StandardPrice = 120;

    private void ShowPrice(int age)
    {
        if (age <= YouthMaxAge)
        {
            Console.WriteLine($"Youth price: {YoutPrice}kr");
        } else if (age >= PensionerMinAge)
        {
            Console.WriteLine($"Pensioner price: {PensionerPrice}kr");
        }

        Console.WriteLine($"Standard price: {StandardPrice}");
    }
}

static internal class Constants
{
    static public readonly string DoubleLine = new string('=', 40);
}