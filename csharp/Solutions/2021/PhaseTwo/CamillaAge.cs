
using Solutions.Utils;

namespace Solutions.Y2021.PhaseTwo;
public static class CamillaAge
{
    public static void Resolve()
    {
        BasicSortedList<int> ages = new();
        for (int a = 0; a < 3; a++)
            ages.Add(int.Parse(Console.ReadLine()));

        Console.WriteLine(ages[1]);
    }
}

