
public static class TennisDoubles
{
    public static void Resolve()
    {
        var habilities = new List<int>();
        for (int i = 0; i < 4; i++)
            habilities.Add(int.Parse(Console.ReadLine()));
        habilities.Sort();
        var teamOne = habilities[0] + habilities[3];
        var teamTwo = habilities[1] + habilities[2];

        Console.WriteLine(teamOne - teamTwo);
    }
}
