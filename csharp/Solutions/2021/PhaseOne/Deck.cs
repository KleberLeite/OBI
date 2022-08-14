
namespace Solutions.Y2021.PhaseOne;
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

            naipes[naipe].TryAdd(num);
        }

        foreach (NaipeDeck naipe in naipes.Values)
        {
            if (naipe.Repeat)
            {
                Console.WriteLine("erro");
                continue;
            }
            if (naipe.Count == 13)
            {
                Console.WriteLine("0");
                continue;
            }
            Console.WriteLine(13 - naipe.Count);
        }
    }

    private class NaipeDeck
    {
        public bool Repeat { get; private set; }
        public int Count => cards.Count;
        private List<int> cards = new();

        public void TryAdd(int card)
        {
            if (cards.Contains(card))
                Repeat = true;
            else
                cards.Add(card);
        }
    }
}
