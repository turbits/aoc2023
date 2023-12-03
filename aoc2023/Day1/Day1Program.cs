using System.Text.RegularExpressions;

namespace AOC2023.Day1;

public static class Day1Program {
    private static Dictionary<string, int> wordToDigit = new() {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "zero", 0 }
    };
    
    [GeneratedRegex("\\d")]
    private static extern Regex ReggieDiggie();
    
    [GeneratedRegex("\\d|one|two|three|four|five|six|seven|eight|nine|zero")]
    private static extern Regex Reggie();
    
    [GeneratedRegex("\\d|eno|owt|eerht|ruof|evif|xis|neves|thgie|enin|orez")]
    private static extern Regex ReggieReverse();

    public static void RunPart1() {
        int calibrationSum = 0;
        
        try {
            using StreamReader sr = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day1/input.txt"));
            while (sr.ReadLine() is { } line) {
                int calibrationValue = FindCalibrationValue(line, true);
                calibrationSum += calibrationValue;
            }
            
            Console.WriteLine($"Calibration Sum Value: " + calibrationSum);
        }
        catch (IOException e) {
            Console.WriteLine("Error reading file: " + e.Message);
        }
    }
    
    public static void RunPart2() {
        int calibrationSum = 0;
        int counter = 1;
        
        try {
            using StreamReader sr = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day1/input.txt"));
            while (sr.ReadLine() is { } line) {
                int calibrationValue = FindCalibrationValue(line, false);
                calibrationSum += calibrationValue;
                Console.WriteLine($"Line:{counter}|Value:{calibrationValue}");
                counter++;
            }
            
            Console.WriteLine("Calibration Sum: " + calibrationSum);
        }
        catch (IOException e) {
            Console.WriteLine("Error reading file: " + e.Message);
        }
    }

    private static int FindCalibrationValue(string line, bool isDigitOnly) {
        string firstNumberString, lastNumberString;
        int firstNumber, lastNumber;

        if (string.IsNullOrWhiteSpace(line)) throw new ArgumentException("The line provided is invalid, it should be a non-empty string.");

        if (isDigitOnly) {
            MatchCollection matches = ReggieDiggie().Matches(line); // this regex finds only digits
            
            if (matches.Count <= 0) return 0;
            
            if (matches.Count == 1) {
                // only one number on the line, so first and last numbers are the same
                firstNumberString = lastNumberString = matches[0].ToString();
            }
            else {
                // two diff numbers on the line, so first and last are different
                firstNumberString = matches[0].ToString();
                lastNumberString = matches[matches.Count - 1].ToString();
            }

            firstNumber = int.Parse(firstNumberString);
            lastNumber = int.Parse(lastNumberString);

        } else {
            MatchCollection matches = Reggie().Matches(line); // forward regex
            
            char[] lineCharsReversed = line.ToCharArray();
            Array.Reverse(lineCharsReversed);
            MatchCollection matchesReverse = ReggieReverse().Matches(new string(lineCharsReversed)); // reversed regex
            
            if (matches.Count <= 0) return 0; // this will never happen in our use-case, but good to have
            
            if (matches.Count == 1) {
                // only one number on the line, so first and last numbers are the same
                firstNumberString = lastNumberString = matches[0].ToString();
            }
            else {
                // two diff numbers on the line, so first and last are different
                firstNumberString = matches[0].ToString();
                lastNumberString = matchesReverse[0].ToString();
            }

            // checking for string numbers and converting to int
            firstNumber = matches[0].Length > 1
                ? wordToDigit[firstNumberString]
                : int.Parse(firstNumberString);

            char[] lnsChar = lastNumberString.ToCharArray();
            Array.Reverse(lnsChar);
            lastNumber = matchesReverse.Count > 1 && lastNumberString.Length > 1
                ? wordToDigit[new string(lnsChar)]
                : int.Parse(lastNumberString);
        }

        // cant(?) concatenate int unless we convert to string first, then parse
        int calibrationValue = int.Parse($"{firstNumber}{lastNumber}");
        return calibrationValue;
    }
}