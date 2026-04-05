public class Solution {
    public string AddBinary(string a, string b) {
        var ind_a = a.Length-1;
        var ind_b = b.Length-1;
        var res = new LinkedList<string>();
        var sum1 = false;

        while(ind_a >= 0 || ind_b >= 0 || sum1)
        {
            
            var _a = (ind_a >= 0)? (a[ind_a]=='0'?0:1): 0;
            var _b = (ind_b >= 0)? (b[ind_b]=='0'?0:1): 0;

            var _c = sum1 ? 1 : 0;
            
            var res1 = Convert.ToString((_a + _b + _c ), 2);
            res.AddFirst(res1[res1.Length -1].ToString());
            
            sum1 = res1.Length > 1;

            if (ind_a >=0) ind_a--;
            if (ind_b >=0) ind_b--;
        }
        return string.Join("", res);
    }
}
