
public static class Deck
{
    public static void Resolve()
    {
        var cards = Console.ReadLine().Chunk(3).Select(cArray => new String(cArray)).ToArray();

        Dictionary<string, NaipeDeck> naipes = new()
        {
            { "C", new NaipeDeck() },
            { "E", new NaipeDeck() },
            { "U", new NaipeDeck() },
            { "P", new NaipeDeck() }
        };

        foreach (string c in cards)
        {
            var num = int.Parse(new String(c.Take(2).ToArray()));
            var naipe = c.Substring(2);

            naipes[naipe].Repeat = !naipes[naipe].List.TryAdd(num, num);
        }

        foreach (NaipeDeck naipe in naipes.Values)
        {
            if (naipe.Repeat)
            {
                Console.WriteLine("erro");
                continue;
            }
            if (naipe.List.Count == 13)
            {
                Console.WriteLine("0");
                continue;
            }
            Console.WriteLine(13 - naipe.List.Count);
        }
    }

    private class NaipeDeck
    {
        private bool repeat;
        public bool Repeat
        {
            get => repeat;
            set
            {
                if (!repeat)
                    repeat = value;
            }
        }
        public SortedList<int, int> List = new();
    }
}
