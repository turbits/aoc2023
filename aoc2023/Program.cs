using System.IO;
using AOC2023.Day1;
using AOC2023.Utility;

namespace AOC2023;

public class Program {
    public static void Main(string[] args) {

        while (true) {
            Console.Clear();
            
            Console.WriteLine(Common.Aoc2023AsciiArt);
            Console.WriteLine("==============================");
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Run Day 1 - Trebuchet?!");
            Console.WriteLine("x. Exit Program");
            
            Console.Write(">");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)) continue;

            switch (choice) {
                case "1":
                    Day1.SubMenu.Run();
                    break;
                case "2":
                    // tbd
                    break;
                case "x":
                    Console.WriteLine("Bye!");
                    return;
            }
        }
    }
}
