using System.Windows;

namespace FlowControl;

class Program
{
    static void Main(string[] args)
    {
        string[] menuLines = [
            "0. Quit",
        ];
        string doubleLine = new string('=', 40);

        Console.WriteLine("Welcome to flowcontrol and string manipulation excercise");
        Console.WriteLine("You will be presented with a number of choices,");
        Console.WriteLine("each one representing one aspect/part of the excercise.");
        Console.WriteLine("Enter menu choices by their number.");

        while (true)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(doubleLine);
            Console.ResetColor();
            Console.WriteLine("Main menu");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(doubleLine);
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
