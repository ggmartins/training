using System;

namespace Experiments1
{
  class Exchange
  {
    private string _name { set; get; }
    private string _symbol { set; get; }
    private int _seccount { set; get; }

    public Exchange(string name, string symbol, int seccount)
    {
      _name = name;
      _symbol = symbol;
      _seccount = seccount;
    }

    public void Deconstruct(out string name, out string symbol, out int seccount)
    {
      name = _name;
      symbol = _symbol;
      seccount = _seccount;
    }

    public void Deconstruct(out string name, out string symbol)
    {
      name = _name;
      symbol = _symbol;
    }

    public void Deconstruct(out string name, out int seccount)
    {
      name = _name;
      seccount = _seccount;
    }
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
    static void testDeconstruction()
    {
      var (close, low, high) = getPriceByTicker("AAPL");
      Console.WriteLine($"INFO ('AAPL'): close = {close}, low = {low}, high = {high}");
      (close, _, _) = getPriceByTicker("MSFT");
      Console.WriteLine($"INFO ('MSFT'): close = {close}");

      Exchange exchange1 = new Exchange("NASDAQ", "NDAQ", 8234);
      Exchange exchange2 = new Exchange("NYSE", "NYSE", 9234);

      var exchanges = new Exchange[] { exchange1, exchange2 };

      /*Array.ForEach( exchanges, (e) =>
      { 
        (_, var symbol, var seccount) = e;
        Console.WriteLine($"INFO: symbol = {symbol}, seccount = {seccount}");
      });*/
      exchanges.Select( (exchance, index) => (exchance, index)).
        ToList().ForEach( (record) =>
      { 
        (_, var symbol, var seccount) = record.exchance;
        Console.WriteLine($"INFO({record.index + 1}): symbol = {symbol}, seccount = {seccount}");
      });
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
      Exchange.testIndexing();
      Exchange.testLiteralNumberImprovements();
      Exchange.testCoelescing();
      Exchange.testDeconstruction();
      Console.WriteLine("END.");
    }
  }
}

