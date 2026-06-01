namespace Experiments4;

public class Solution
{
    public string LongestCommonPrefix(string[] strs) {
        if (strs == null || strs.Length == 0) return "";
        var min = strs[0].Length;
        for (var i = 1; i< strs.Length; i++)
        {
            if (strs[i].Length < min)
                min = strs[i].Length;
        }

        for (var i = 0; i < min; i++)
        {
            var c = strs[0][i];
            for (var j = 0; j < strs.Length; j++)
            {
                if (strs[j][i] != c)
                    return strs[0].Substring(0, j);
            }
        }
        return "";
    }

    public override string ToString()
    {
        return "Solution up and running";
    }

    public static void Main(string[] args)
    {
        var strs = new string[] { "flower", "flow", "flight" };
        var solution = new Solution();
        Console.WriteLine(solution);
        Console.WriteLine(solution.LongestCommonPrefix(strs)[^1]);
    }
}
