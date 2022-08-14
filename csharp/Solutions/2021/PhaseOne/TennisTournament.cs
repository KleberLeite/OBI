
namespace Solutions.Y2021.PhaseOne;
public static class TennisTournament
{
    public static void Resolve()
    {
        var wins = 0;
        for (int i = 0; i < 6; i++)
            if (Console.ReadLine() == "V")
                wins++;

        Console.WriteLine(wins >= 5 ? 1 : wins >= 3 ? 2 : wins >= 1 ? 3 : -1);
    }
}
