// See https://aka.ms/new-console-template for more information
namespace Market
{

    public class Program
    {
        public record Stock(string Symbol, decimal Price);

        public static void Main(string[] args)
        {
            StockRecord stock1 = new StockRecord("AAPL");
            Console.WriteLine($"{stock1.Symbol}: {stock1.Average} {stock1.High} {stock1.Low} {stock1.Length}");
            for (int i = 0; i < stock1.Length; i++)
            {
                Console.WriteLine($"{stock1.Symbol} ({i + 1}): {stock1[i]}");
            }
            Console.WriteLine($"{stock1["mon"]}");

            Security s1 = new Security("AAPL", 245.1m);
            Security s2 = new Security("WMT", 102.8m);
            Security s3 = new Security("WMT", 102.8m);

            Console.WriteLine($"s1 AAPL == s2 WMT {Security.Equals(s1, s2)}");
            Console.WriteLine($"s2 WMT == s3 WMT {Security.Equals(s2, s3)}");
            Console.WriteLine($"s3 WMT == null {Security.Equals(s2, null)}");
            Console.WriteLine($"null == null {Security.Equals(null, null)}");

            Stock nvda = new Stock("NVDA", 1104.0m);

            Stock amd = nvda with { Symbol = "AMD", Price = 150.0m };

        }
    }
}