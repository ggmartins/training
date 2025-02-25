using System;

namespace Experiments2
{
  public class Circle
  {
    public int Radius { get; set; }
  }
  public class Rectangle
  {
    public int Width { get; set; }
    public int Height { get; set; }
  }
  public class Triangle
  {
    public int Base { get; set; }
    public int Height { get; set; }
  }
  public readonly struct Point
  {
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y) => (X, Y) = (x, y);
    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
  }

  public class SecuritiesTrade
  {
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void Deconstruct(out int quantity, out decimal price) =>
     (quantity, price) = (Quantity, Price);

    public override string ToString() => $"Quantity: {Quantity}, Price: {Price}";
  }
  public class StockTrade : SecuritiesTrade
  {
    public string? Symbol { get; set; }

    public void Deconstruct(
     out string symbol,
     out int quantity,
     out decimal price
    )
    {
      base.Deconstruct(out quantity, out price);
      symbol = Symbol!;
    }
    public override string ToString() => $"Symbol: {Symbol}, {base.ToString()}";
  }
  public class BondTrade : SecuritiesTrade
  {
    public string? Name { get; set; }
    public int Duration { get; set; }
    public void Deconstruct(
     out string name,
     out int duration,
     out int quantity,
     out decimal price
    )
    {
      base.Deconstruct(out quantity, out price);
      name = Name!;
      duration = Duration;
    }
    public override string ToString() => $"Name: {Name!}, Duration: {Duration}, {base.ToString()}";
  }

  public class CommissionCalculator
  {
    public static decimal CalculateTradeCommission(SecuritiesTrade trade) => trade switch
    {
      StockTrade { Quantity: 0 } => throw new ArgumentException("Invalid trade quantity"),
      StockTrade { Quantity: var q, Price: var p} when q >= 1000 && (q * p) > 10000.0m => 5m,
      StockTrade { Quantity: >= 1000 } => 10m,
      StockTrade { Quantity: var q, Price: var p } when (q * p) >= 5000m => q * p * 0.005m,
      StockTrade => trade.Quantity * trade.Price * 0.01m,

      BondTrade { Duration: 5, Quantity: var q, Price: var p } when (q * p)>= 10000.0m => 15m,
      BondTrade { Duration: 5 } => 20m,
      BondTrade { Duration: 10 } => 12m,
      BondTrade { Duration: 20, Quantity: var q, Price: var p } when (q * p) >= 5000.0m => 5m,
      BondTrade { Duration: 20 } => 10m,
      _ => throw new ArgumentException("Invalid Trade Type")
    };

    // A stock trade of 0 shares should be caught as flagged as invalid.
    // A stock trade that is less than $5,000 is a 0.1% commission.
    // A stock trade that is more or equal to $5,000 is a 0.05% commission.
    // Any stock trade of 1000 shares or more is a flat fee of $10.
    // Any stock trade of 1000 shares or more with a value of $10k or more is a flat fee of $5.
    // Any bond of 5 years duration is $20, or $15 if a total trade value is $10k or more.
    // Any bond of 10 years duration is $12 dollars
    // A bond of 20 years duration is $10 dollars or $5 if a total trade value is $5k or more.
    // A bond trade of any other duration is invalid.
    public static void PrintTradeCommission(SecuritiesTrade trade)
    {
      decimal commission = CalculateTradeCommission(trade);
      Console.WriteLine($"Trade: [{trade}] = {commission} ");
    }
  }
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

    static string ShapeToString(Object shape) => shape switch
    {
      Circle { Radius: var r } when r > 10 => "Big Circle",
      Circle { Radius: var r } when r <= 10 => "Little Circle",
      Rectangle { Width: var w, Height: var h } when w == h => "Square",
      Rectangle => "Rectangle",
      Triangle => "Triangle",
      _ => "Unknown shape"
    };

    static void testBasicPatterns()
    {
      Console.WriteLine($"[{nameof(Program)}].[{nameof(testBasicPatterns)}] Running...");
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
      Console.WriteLine(ShapeToString(new Circle { Radius = 5 }));
      Console.WriteLine(ShapeToString(new Circle { Radius = 15 }));
      Console.WriteLine(ShapeToString(new Rectangle { Width = 5, Height = 5 }));
      Console.WriteLine(ShapeToString(new Rectangle { Width = 10, Height = 20 }));
      Console.WriteLine(ShapeToString(new Triangle { Base = 10, Height = 10 }));
      Console.WriteLine(ShapeToString(new { Width = 10, Height = 10 }));
    }

    static string Classify(Point point) => point switch
    {
      (>0, >0) => "upper right",
      (<0, >0) => "upper left",
      (>0, <0) => "lower right",
      (<0, <0) => "lower left",
      _ => "on the origin"
    };

    static decimal GetGroupTicketPriceDiscount(int groupsize, DateTime visitDate)
      => (groupsize, visitDate.DayOfWeek) switch
    {
      (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
      (>=5 and < 10, DayOfWeek.Monday) => 0.20m,
      (>=10, DayOfWeek.Monday) => 0.30m,
      (>=5 and < 10, _) => 0.12m,
      (>=10, _) => 0.15m,
      (<=0, _) => throw new ArgumentException("Group size cannot be negative"),
      _ => 0.0m
    };

    static void testPositionalPatterns()
    {
      Console.WriteLine($"[{nameof(Program)}].[{nameof(testPositionalPatterns)}] Running...");
      //(int , DateTime)[] TestDicountData = new[]
      var TestDicountData = new[]
      {
        (4, new DateTime(2022, 9, 3)),
        (7, new DateTime(2023, 2, 6)),
        (20, new DateTime(2023, 4, 17)),
        (15, new DateTime(2023, 8, 8)),
        (9, new DateTime(2023, 8, 9)),
      };
      foreach (var (size, date) in TestDicountData)
      {
        Console.WriteLine($"Group size: {size}, Visit Date: {date}, " +
          $"Discount: {GetGroupTicketPriceDiscount(size, date)}");
      }
      var testPointData = new []
      {
        new Point(5, 8),
        new Point(-2, 7),
        new Point(1, -1),
        new Point(-2, -2),
      };
      foreach (var point in testPointData)
      {
        Console.WriteLine($"Point: {point}, Classification: {Classify(point)}");
      }
    }

    static string GetQuarterFromDate(DateTime date) => date.Month switch
    {
      >= 1 and <= 3 => "Q1",
      >= 4 and <= 6 => "Q2",
      >= 7 and <= 9 => "Q3",
      _ => "Q4"
    };

    /*static string isFirstOrSecondHalf(DateTime date) => date switch
    {
      { Month: >= 1 and <= 6 } => "First half of the year",
      { Month: >= 7 and <= 12 } => "Second half of the year",
      _ => "Unknown"
    };*/
    static string isFirstOrSecondHalf(object date)
    {
      if (date is DateTime { Month: >= 1 and <= 6 })
      {
        return "First Half";
      }
      else if (date is DateTime { Month: >= 7 and <= 12 })
      {
        return "Second Half";
      }
      return "Unknown";
    }
    static void testRelationalPatterns()
    {
      Console.WriteLine($"[{nameof(Program)}].[{nameof(testRelationalPatterns)}] Running...");
      var d1 = new DateTime(2023, 1, 1);
      var d2 = new DateTime(2023, 4, 20);
      var d3 = new DateTime(2021, 12, 1);
      var d4 = new DateTime(2021, 8, 31);
      Console.WriteLine($"Date {d1} {GetQuarterFromDate(d1)} {isFirstOrSecondHalf(d1)}");
      Console.WriteLine($"Date {d2} {GetQuarterFromDate(d2)} {isFirstOrSecondHalf(d2)}");
      Console.WriteLine($"Date {d3} {GetQuarterFromDate(d3)} {isFirstOrSecondHalf(d3)}");
      Console.WriteLine($"Date {d4} {GetQuarterFromDate(d4)} {isFirstOrSecondHalf(d4)}");
    }

    static void testChallenge()
    {
      Console.WriteLine($"[{nameof(Program)}].[{nameof(testChallenge)}] Running...");
      SecuritiesTrade[] tradeList = new SecuritiesTrade[]
      {
        new StockTrade(){Symbol="AAPL", Quantity=1200, Price=27.81m},
        new StockTrade(){Symbol="WMT", Quantity=1000, Price=7.92m},
        new StockTrade(){Symbol="AAPL", Quantity=200, Price=27.81m},
        new StockTrade(){Symbol="WMT", Quantity=400, Price=7.92m},
        new StockTrade(){Symbol="WMT", Quantity=0, Price=9.55m},
        new BondTrade(){Name="Abcd 5yr", Duration=5, Price=100.0m, Quantity=10},
        new BondTrade(){Name="Qwert 10yr", Duration=10, Price=100.0m, Quantity=10},
        new BondTrade(){Name="Abcd 20yr", Duration=20, Price=100.0m, Quantity=100},
        new BondTrade(){Name="Qwert 20yr", Duration=20, Price=50.0m, Quantity=10},
        new BondTrade(){Name="Qwert 50yr", Duration=50, Price=50.0m, Quantity=10}
      };
      foreach (var trade in tradeList)
      {
        try
        {
          CommissionCalculator.PrintTradeCommission(trade);
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error: {ex.Message}");
        }
      }
    }
    public static void Main(string[] args)
    {
      testBasicPatterns();
      testPositionalPatterns();
      testRelationalPatterns();
      testChallenge();
    }
  }
}
