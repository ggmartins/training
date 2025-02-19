using System;

namespace Experiments1
{
  class Program
  {

    static string dashedLine_wopatterns(Object? size)
    {
      var s = 0;
      if (size is null) return "";
      if (size.GetType() == typeof(int))
      {
        s = (int)size;
      }
      else if (size.GetType() == typeof(string))
      {
       int.TryParse((string)size, out s);
      }
      if (s > 0) return new string('-', s);
      return "";
    }
    static string dashedLine_withpatterns(Object? size)
    {
      if (size is not null &&
        size is int s ||
        (size is string sz && int.TryParse(sz, out s)))
      {
        return new string('-', s);
      }
      return "";
    }
    static bool checkDate(DateTime? date)
    {
      if (date is null) return false;
      return (date is { Month: 12, Day: 1 or 25 });
    }

    static void testBasicPatterns()
    {
      Console.WriteLine(dashedLine_wopatterns(10));
      Console.WriteLine(dashedLine_wopatterns("10"));
      Console.WriteLine(dashedLine_wopatterns(null));
      Console.WriteLine(dashedLine_wopatterns("abc"));
      Console.WriteLine(dashedLine_wopatterns(0));
      Console.WriteLine(dashedLine_withpatterns(10));
      Console.WriteLine(dashedLine_withpatterns("10"));
      Console.WriteLine(dashedLine_withpatterns(null));
      Console.WriteLine(dashedLine_withpatterns("abc"));
      Console.WriteLine(dashedLine_withpatterns(0));
      Console.WriteLine($"checkDate(new DateTime(2025, 12, 1) = {checkDate(new DateTime(2025, 12, 1))}");
      Console.WriteLine($"checkDate(new DateTime(2025, 12, 25) = {checkDate(new DateTime(2025, 12, 25))}");
      Console.WriteLine($"checkDate(new DateTime(2025, 12, 26) = {checkDate(new DateTime(2025, 12, 26))}"); 
      Console.WriteLine($"checkDate(null) = {checkDate(null)}");
    }

    public static void Main(string[] args)
    {
      testBasicPatterns();
    }
  }
}
