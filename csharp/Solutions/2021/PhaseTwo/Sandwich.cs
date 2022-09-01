
namespace Solutions.Y2021.PhaseTwo;
public static class Sandwich
{
    private static int Count;
    private static Dictionary<int, List<int>> mValues = new();

    public static void Resolve()
    {
        int[] nm = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
        int n = nm[0];
        int m = nm[1];

        if (m == 0)
        {
            Console.WriteLine(Math.Pow(2, n) - 1);
            return;
        }

        for (int i = 0; i < m; i++)
        {
            int[] ab = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
            int a = Math.Min(ab[0], ab[1]);
            int b = Math.Max(ab[0], ab[1]);

            if (!mValues.ContainsKey(a))
                mValues.Add(a, new List<int> { b });
            else
                mValues[a].Add(b);
        }

        if (m == Combinatorie(n, 2))
        {
            Console.WriteLine(n);
            return;
        }

        for (int i = 1; i <= n; i++)
            NewNode(new List<int>(), i, n);

        Console.WriteLine($"end: {Count + n}");
    }

    private static int Combinatorie(int a, int b) => Factorial(a) / (Factorial(b) * Factorial(a - b));

    private static int Factorial(int a)
    {
        int result = 1;
        for (int i = 1; i <= a; i++)
            result *= i;

        return result;
    }

    private static void NewNode(List<int> blocked, int value, int n)
    {
        if (value == n)
            return;

        if (mValues.ContainsKey(value))
            blocked.AddRange(mValues[value]);

        for (int i = value + 1; i <= n; i++)
        {
            if (blocked.Contains(i))
                continue;

            NewNode(blocked, i, n);
            Count++;
        }
    }
}