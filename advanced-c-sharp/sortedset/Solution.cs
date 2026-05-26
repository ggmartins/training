namespace sortedset;

public class Solution
{
    public static void Main(string[] args)
    {
        SortedSet<(int price, int timestamp)> set = new SortedSet<(int price, int timestamp)>();
        set.Add((10, 1));
        set.Add((5, 2));
        set.Add((5, 1));
        set.Add((15, 3));
        set.Add((6, 0));

        Console.WriteLine(set.Last());
        Console.WriteLine(set.Max());

        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
    }
}
