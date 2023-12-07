using System.Text.RegularExpressions;

namespace AOC2023.Day2;

public static partial class Day2Program {
    [GeneratedRegex(@"(?<=\D)\d*(1|2|3|4|5|6|7|8|9|0)\b")]
    private static partial Regex ReggieFindGameNumber();

    [GeneratedRegex(@"\b(\d+)\s+(green|blue|red)\b")]
    private static partial Regex ReggieFindColours();

    public static void RunPart1() {
        const int maxRedCubes = 12;
        const int maxGreenCubes = 13;
        const int maxBlueCubes = 14;
        List<int> possibleGames = new();
        List<int> impossibleGames = new();
        
        try {
            using StreamReader sr = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day2/input.txt"));
            while (sr.ReadLine() is { } line) {
                bool isGamePossible = true;

                MatchCollection numberMatches = ReggieFindGameNumber().Matches(line);
                var gameId = int.Parse(numberMatches[0].ToString());

                MatchCollection colourMatches = ReggieFindColours().Matches(line);
                foreach (Match match in colourMatches) {
                    string colour = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[1].Value);

                    switch (colour) {
                        case "red":
                            if (count > maxRedCubes) {
                                isGamePossible = false;
                            }
                            break;
                        case "green":
                            if (count > maxGreenCubes) {
                                isGamePossible = false;
                            }
                            break;
                        case "blue":
                            if (count > maxBlueCubes) {
                                isGamePossible = false;
                            }
                            break;
                    }
                }

                if (isGamePossible) {
                    possibleGames.Add(gameId);
                }
                else {
                    impossibleGames.Add(gameId);
                }
            }
            
            Console.WriteLine(
                $"Given the cube limitations of: {maxRedCubes} red cubes, {maxGreenCubes} green cubes, and {maxBlueCubes} blue cubes");
            Console.WriteLine("============================================================");
            Console.WriteLine("The games that are possible are:");
            possibleGames.ForEach(p => Console.Write($"Game {p.ToString()}, "));
            Console.WriteLine("\n============================================================");
            Console.WriteLine("The games that are impossible are:");
            impossibleGames.ForEach(p => Console.Write($"Game: {p.ToString()}, "));
            Console.WriteLine("\n============================================================");
            Console.WriteLine($"The sum total of possible game identifiers is: {possibleGames.Sum()}");
        }
        catch (IOException e) {
            Console.WriteLine("Error reading file: " + e.Message);
        }
    }

    public static void RunPart2() {
        List<int> gamePowers = new();

        using StreamReader sr = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day2/input.txt"));
        while (sr.ReadLine() is { } line) {
            int gameRedCubes = 0, gameGreenCubes = 0, gameBlueCubes = 0;

            MatchCollection colourMatches = ReggieFindColours().Matches(line);
            foreach (Match match in colourMatches) {
                string colour = match.Groups[2].Value;
                int count = int.Parse(match.Groups[1].Value);

                switch (colour) {
                    case "red":
                        if (count > gameRedCubes) {
                            gameRedCubes = count;
                        }
                        break;
                    case "green":
                        if (count > gameGreenCubes) {
                            gameGreenCubes = count;
                        }
                        break;
                    case "blue":
                        if (count > gameBlueCubes) {
                            gameBlueCubes = count;
                        }
                        break;
                }
            }
            
            // get power of cube set for this game
            int gamePower = gameRedCubes * gameGreenCubes * gameBlueCubes;
            gamePowers.Add(gamePower);
        }
        
        int totalPower = gamePowers.Sum();
        Console.WriteLine("============================================================");
        Console.WriteLine($"The total sum of all cube powers for each game is: {totalPower}");
    }
}
