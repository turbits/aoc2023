using AOC2023.Utility;

namespace AOC2023.Day1; 

public static class SubMenu {

    public static void Run() {
        while (true) {
            Console.Clear();
            
            Console.WriteLine("Advent of Code - Day 1 - Trebuchet?!");
            Console.WriteLine("0. Print the Day1 prompt");
            Console.WriteLine("1. Run Part 1: digits only"); // 53194
            Console.WriteLine("2. Run Part 2: including numbers as strings"); // 54251
            Console.WriteLine("x. Return to main menu");
            
            Console.Write(">");
            string? choice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(choice)) continue;

            switch (choice) {
                case "0":
                    Console.WriteLine(prompt);
                    Common.PressToContinue();
                    break;
                case "1":
                    Day1Program.RunPart1(); // 53194
                    Common.PressToContinue();
                    break;
                case "2":
                    Day1Program.RunPart2(); // 54270
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
    
    

    private static string prompt = """
                                   Something is wrong with global snow production, and you've been selected to take a look. The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.

                                   You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.

                                   Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

                                   You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and why your map looks mostly blank ("you sure ask a lot of questions") and hang on did you just say the sky ("of course, where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet ("please hold still, we need to strap you in").

                                   As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf who was apparently just excited to show off her art skills. Consequently, the Elves are having trouble reading the values on the document.

                                   The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
                                   
                                   For example:
                                   1abc2
                                   pqr3stu8vwx
                                   a1b2c3d4e5f
                                   treb7uchet
                                   
                                   In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.
                                   
                                   Consider your entire calibration document. What is the sum of all of the calibration values?
                                   """;
}