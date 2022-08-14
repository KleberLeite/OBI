
namespace Solutions.Y2021.PhaseOne;
public static class ResponseTime
{
    public static void Resolve()
    {
        SortedDictionary<int, Friend> friends = new();
        var pending = new List<Friend>();
        var lastEvent = "";

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var @event = input[0];
            var data = int.Parse(input[1]);

            switch (@event)
            {
                case "R":
                    if (i > 0 && lastEvent != "T")
                        pending.ForEach(f => f.Time++);

                    if (friends.ContainsKey(data))
                    {
                        friends[data].Waiting = true;
                        pending.Add(friends[data]);
                    }
                    else
                    {
                        var friend = new Friend() { Id = data, Waiting = true };
                        pending.Add(friend);
                        friends.Add(data, friend);
                    }

                    break;
                case "E":
                    if (i > 0 && lastEvent != "T")
                        pending.ForEach(f => f.Time++);

                    friends[data].Waiting = false;
                    pending.Remove(friends[data]);

                    break;
                case "T":
                    pending.ForEach(f => f.Time += @data);
                    break;
            }
            lastEvent = @event;
        }

        foreach (KeyValuePair<int, Friend> kvp in friends)
            Console.WriteLine($"{kvp.Key} {(kvp.Value.Waiting ? -1 : kvp.Value.Time)}");
    }

    private class Friend
    {
        public int Id;
        public int Time;
        public bool Waiting;
    }
}
