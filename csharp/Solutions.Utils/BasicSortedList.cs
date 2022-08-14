
namespace Solutions.Utils;
public class BasicSortedList<T>
{
    private List<T> data = new();

    private bool alreadySorted;

    public T this[int index]
    {
        get
        {
            if (!alreadySorted)
                data.Sort();

            return data[index];
        }
        set
        {
            if (!alreadySorted)
                data.Sort();

            data[index] = value;
        }
    }

    public T this[int index, IComparer<T> comparer]
    {
        get
        {
            if (!alreadySorted)
                data.Sort(comparer);

            return data[index];
        }
        set
        {
            if (!alreadySorted)
                data.Sort(comparer);

            data[index] = value;
            alreadySorted = false;
        }
    }

    public void Add(T element)
    {
        data.Add(element);
        alreadySorted = false;
    }

    public void Remove(T element)
    {
        data.Remove(element);
        alreadySorted = false;
    }

    public void Contains(T element) => data.Contains(element);
}