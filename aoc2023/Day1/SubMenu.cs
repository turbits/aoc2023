using AOC2023.Utility;

namespace AOC2023.Day1; 

public static class SubMenu {

    public static void Run() {
        while (true) {
            Console.Clear();
            
            Console.WriteLine("Advent of Code - Day 1 - Trebuchet?!");
            Console.WriteLine("See problem prompts for each part in the Day2 directory");
            Console.WriteLine("1. Run Part 1");
            Console.WriteLine("2. Run Part 2");
            Console.WriteLine("x. Return to main menu");
            
            Console.Write(">");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)) continue;

            switch (choice) {
                case "1":
                    Day1Program.RunPart1();
                    Common.PressToContinue();
                    break;
                case "2":
                    Day1Program.RunPart2();
                    Common.PressToContinue();
                    break;
                case "x":
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    Common.PressToContinue();
                    break;
            }
        }
    }
}