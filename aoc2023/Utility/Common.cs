namespace AOC2023.Utility; 

public class Common {
    public static string Aoc2023AsciiArt = """
                                                           .  %     * .
                                                       *     <!> * Advent .
                                                         .  <<*>> . of*
                                                         * <<*?0>>   Code .
                                                      .   <<.*0*.>> * 2023
                                                         <<0*.*0?*>> .   *
                                                        <<?*0*.**0*>>  .
                                                      .      |\|  * [|*|] .
                                                        *    ||| .[|*|][|-|] *
                                                 *======== TURBITS ========*
                                                 https://github.com/turbits
                                                 https://turbits.sh
                                           """;

    public static void PressToContinue() {
        Console.Write("\nPress any key to continue");
        Console.ReadKey();
    }
}