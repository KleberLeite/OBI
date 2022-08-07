
public static class Sandwich
{
    public static void Resolve()
    {
        var nm = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        var n = nm[0];
        var m = nm[1];

        if (m == 0)
        {
            Console.WriteLine(AllCombinations(n));
            return;
        }

        var mValues = GetM(n, m);
        var list = mValues.List;
        var listEnd = mValues.keyEnds;

        var combinations = 0;
        var combinationsBelowN = CombinationsBelowN(n);
        var combinatedKey = new Dictionary<int, int>();
        var combinatedKeyPair = new Dictionary<int, int>();
        var usedLast = 0;

        for (int i = 0; i < list.Count - 1; i++)
        {
            var key = list[i].a;
            var value = list[i].b;

            var usedKeyTimes = 0;
            var dicKey = 0;
            if (combinatedKey.ContainsKey(key))
            {
                usedKeyTimes = combinatedKey[key];
                dicKey = key;
            }
            else if (combinatedKey.ContainsKey(value))
            {
                usedKeyTimes = combinatedKey[value];
                dicKey = value;
            }
            else
            {
                combinations += combinationsBelowN;

                combinatedKey.Add(key, 1);
                combinatedKey.Add(value, 1);
                combinatedKeyPair.Add(key, value);
                combinatedKeyPair.Add(value, key);

                continue;
            }

            combinatedKey[dicKey] *= 2;
            combinations += combinationsBelowN / combinatedKey[dicKey];

            if (list[i].b == n - 1)
            {
                usedLast++;
            }
            else
            {
                usedLast += combinationsBelowN - (2 * list[i].b);
            }
        }

        var totalEnd = CombinationsBelowN(n + 1) + 1;
        for (int j = n - 1; j != 1; j--)
        {
            if (combinatedKey.ContainsKey(j))
            {
                if (j == n - 1)
                    totalEnd--;
                else
                {

                }
            }
        }
    }

    private static int CombinationsBelowN(int n)
    {
        var sumBelow = 0;
        for (int i = 1; i <= n - 1; i++)
        {
            var combination = 0;
            for (int j = 0; j <= i; j++)
                combination += Combination(i, j);

            combination -= sumBelow;
            sumBelow += combination;
        }

        return sumBelow;
    }

    private static (List<int> keyEnds, List<(int a, int b)> List) GetM(int n, int m)
    {
        var values = new List<(int a, int b)>();
        var withEnd = new List<int>();
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var a = Math.Min(ab[0], ab[1]);
            var b = Math.Max(ab[0], ab[1]);

            if (a == n || b == n)
                withEnd.Add(a);
            else
                values.Add((a, b));
        }

        values.Sort(new ABComparer());
        return (withEnd, values);
    }

    private class ABComparer : IComparer<(int a, int b)>
    {
        public int Compare((int a, int b) x, (int a, int b) y) => x.a == y.a ? 0 : x.a > y.a ? 1 : -1;
    }

    private static int AllCombinations(int n)
    {
        var combination = 0;
        for (int i = 1; i <= n; i++)
            combination += Combination(n, i);

        return combination;
    }

    public static int Combination(int n, int p) => Factorial(n) / (Factorial(p) * Factorial(n - p));

    private static int Factorial(int x)
    {
        var y = 1;
        for (int i = 1; i <= x; i++)
            y *= i;

        return y;
    }
}
