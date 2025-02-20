using System;

namespace Experiments1
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

    public static void Main(string[] args)
    {
      testBasicPatterns();
    }
  }
}
