public class Solution {
    public string AddBinary(string a, string b) {
        var ind_a = a.Length-1;
        var ind_b = b.Length-1;
        var res = new LinkedList<string>();
        var sum1 = false;

        try 
        {
            if((ind_a < 32) && (ind_b < 32))
            {
                var _a = Convert.ToUInt32(a, 2);
                var _b = Convert.ToUInt32(b, 2);
                return Convert.ToString((_a + _b), 2);
            }
        }
        catch (Exception e)
        {
            //TODO: dealing with big numbers here, continuing...
        }

        while(ind_a >= 0 || ind_b >= 0 || sum1)
        {
            var _a = (ind_a >= 0)? (string)a[ind_a].ToString(): "0";
            var _b = (ind_b >= 0)? (string)b[ind_b].ToString(): "0";

            if (((_a == "0") && (_b == "0")))
            {
                if (sum1)
                    res.AddFirst("1");
                else
                    res.AddFirst("0");
                sum1 = false;
            }
            else if (((_a == "0") && (_b == "1")) || ((_a == "1") && (_b == "0")))
            { 
                if (sum1)
                {
                    res.AddFirst("0");
                    sum1 = true;
                }
                else
                {
                    res.AddFirst("1");
                    sum1 = false;
                }
            }
            else if ((_a == "1") && (_b == "1"))
            {
                if (sum1)
                    res.AddFirst("1");
                else
                    res.AddFirst("0");
                sum1 = true;
            }
            else if(sum1)
            {
                res.AddFirst("1");
                sum1 = false;
            }
            if (ind_a >=0) ind_a--;
            if (ind_b >=0) ind_b--;
        }
        return string.Join("", res);
    }
}
