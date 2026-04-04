using System;
using System.Collections.Concurrent;

ref struct StackContainer<T> //where T : notnull
{
    private Span<T> _mydata;
    public StackContainer(Span<T> span)
    {
        _mydata = span;
    }

    public override string ToString()
    {
        var s = $"[{SpanToString(_mydata)}";
        return s;
    }

    private static string SpanToString(ReadOnlySpan<T> span)
    {
        //Don't do this
        /*
        if (span.Length == 0)
            return string.Empty;
        var result = new System.Text.StringBuilder();
        for (int i = 0; i < span.Length; i++)
        {
            if (i > 0)
                result.Append(',');

            result.Append(span[i]);
        }
        return result.ToString(); */
        //DO:
        return span.Length == 0 ? string.Empty : string.Join(",", span.ToArray());
    }
}

public class Program {

    private int[] _myint1 = {1,2,3,4,5,6,7,8,9,10};
    private int _stacksize = 0;

    public Program()
    {
        _stacksize = new Random().Next(1, 100);
    }

    //Span<int> _myint2 = stackalloc int[10];

    public static void Main(string[] args)
    {
       Console.WriteLine($"Test {new Program()}");

    }

    public override string ToString()
    {
        Span<int> test1 = stackalloc int[_stacksize];
        //genericDict2 is the array itself.
        //genericDict1 is a Span view over an array.        
        //Span<ConcurrentDictionary<string, object?>> genericDict1 = new ConcurrentDictionary<string, object?>[10];
        //ConcurrentDictionary<string, object?>[] genericDict2 = new ConcurrentDictionary<string, object?>[10];
        //Not allowed:
        //Span<ConcurrentDictionary<string, object?>> genericDict = stackalloc ConcurrentDictionary<string, object?>[10];
        if (test1.Length > 5)
            test1[1] = 1;
        var test = new StackContainer<int>(test1);
        var s = string.Join(",", _myint1);
        return $"{s}|{test.ToString()}";
    } 
}
