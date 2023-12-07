using System.IO;
using AOC2023.Utility;

namespace AOC2023;

public class Program {
    public static void Main(string[] args) {

        while (true) {
            Console.Clear();
            
            Console.WriteLine(Common.Aoc2023AsciiArt);
            Console.WriteLine("==============================");
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Day 1 - Trebuchet?!");
            Console.WriteLine("2. Day 2 - Cube Conundrum");
            Console.WriteLine("x. Exit");
            
            Console.Write(">");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)) continue;

            switch (choice) {
                case "1":
                    Day1.SubMenu.Run();
                    break;
                case "2":
                    Day2.SubMenu.Run();
                    break;
                case "x":
                    Console.WriteLine("Bye!");
                    return;
            }
        }
    }
}
