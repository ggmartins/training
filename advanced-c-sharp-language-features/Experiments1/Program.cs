using System;

namespace Experiments1
{
  class Program
  {
    static void testIndexing()
    {
      var logname = nameof(testIndexing); 
      var test = new[]{"test0", "test1", "test2", "test3", "test4", "test5"};

      Console.WriteLine($"INFO({logname}): 1. Element at test[^1]: {test[^1]} == test5");
      // Same as:
      Console.WriteLine($"INFO({logname}): 2. Element at test[test.Length - 1]: {test[test.Length - 1]} == test5");
      // Same as test.Length - 2
      Console.WriteLine($"INFO({logname}): 3. Element at test[^2]: {test[^2]} == test4");

      var wordRange = test[..]; 
      Console.WriteLine($"INFO({logname}): 4. All words wordRange[..] == {string.Join(",", wordRange)}");
      wordRange = test[2..]; 
      Console.WriteLine($"INFO({logname}): 5. wordRange[2..] == {string.Join(",", wordRange)}");
      wordRange = test[..4]; 
      Console.WriteLine($"INFO({logname}): 6. wordRange[..4] == {string.Join(",", wordRange)}");
      wordRange = test[2..4]; 
      Console.WriteLine($"INFO({logname}): 7. wordRange[2..4] == {string.Join(",", wordRange)}");

      Index idx = ^4;
      Console.WriteLine($"INFO({logname}): 8. test[idx] (^4) == {test[idx]}");
      Range rng = 1..^1;
      Console.WriteLine($"INFO({logname}): 9. test[rng] (1..^1) == {string.Join(",", test[rng])}");
      idx = ^100;
      try
      {
        Console.WriteLine($"INFO({logname}): 10. test[idx] (^100) == {test[idx]}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"ERROR: {ex}"); 
      }
    }
    static void testLiteralNumberImprovements()
    {
      int d = 123_456;
      float f = 1_234.5f;
      var x = 0xAB_CD_EF;
      var b = 0b1101_1110_1001_1010;
      Console.WriteLine($"INFO: 123_456 == {d}");
      Console.WriteLine($"INFO: 1_234.5f == {f}");
      Console.WriteLine($"INFO: 0xAB_CD_EF == {x:X}");
      Console.WriteLine($"INFO: 0b1101_1110_1001_1010 == {b:X}");
    }
    static void testCoelescing()
    {
      string? desc = null;
      Console.WriteLine(desc ?? "INFO: desc is null");
      try
      {
        Console.WriteLine(desc ?? throw new ArgumentNullException("desc",
            "desc cannot be null")); // NEW!!!
      }
      catch (Exception ex)
      {
        Console.WriteLine($"ERROR: First Attempt ({ex})");
      }
      try
      {
        Console.WriteLine(desc ?? getDesc());
      }
      catch (Exception ex)
      {
        // this is never thrown
        Console.WriteLine($"ERROR: Second Attempt ({ex})");
      }
      Console.WriteLine($"INFO: desc == [{desc}]");
      Console.WriteLine(desc ??= "Default value"); //NEW!!!
      Console.WriteLine($"INFO: desc == [{desc}]");
    }
    static void testDesconstruction()
    {
      var (close, low, high) = getPriceByTicker("AAPL");
      Console.WriteLine($"INFO ('AAPL'): close = {close}, low = {low}, high = {high}");
      (close, _, _) = getPriceByTicker("MSFT");
      Console.WriteLine($"INFO ('MSFT'): close = {close}");
    }

    static string getDesc()
    {
      return "INFO: This is a description";
    }

    static (decimal, decimal, decimal) getPriceByTicker(string ticker)
    {
      switch (ticker)
      {
        case "AAPL":
          return (123.45m, 120.01m, 130.12m);
        case "MSFT":
          return (498.2m, 491.34m, 503.45m);     
      }
      return (-1m, -1m, -1m);
    }

    static void Main(string[] args)
    {
      Program.testIndexing();
      Program.testLiteralNumberImprovements();
      Program.testCoelescing();
      Program.testDesconstruction();
      Console.WriteLine("END.");
    }
  }
}

