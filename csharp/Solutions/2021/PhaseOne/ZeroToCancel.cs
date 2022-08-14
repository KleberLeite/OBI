
namespace Solutions.Y2021.PhaseOne;
public static class ZeroToCancel
{
    public static void Resolve()
    {
        List<int> numbers = new();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = int.Parse(Console.ReadLine());

            if (input == 0)
                numbers.RemoveAt(numbers.Count - 1);
            else
                numbers.Add(input);
        }

        Console.WriteLine(numbers.Sum());
    }
}