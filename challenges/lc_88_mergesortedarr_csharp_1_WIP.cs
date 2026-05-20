public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        //Array.Resize(ref nums1, m + n);
        var nums1_ind = 0;
        for(int nums2_ind = 0; nums2_ind < n; nums2_ind++)
        {
            while(nums1_ind < (m + n) && nums2_ind < n)
            {
                if (nums1[nums1_ind] >= nums2[nums2_ind])
                {
                    //Console.WriteLine($"+{m - nums1_ind}");
                    Array.Copy(nums1, nums1_ind, nums1, nums1_ind+1, m + n - nums1_ind -1 );
                    nums1[nums1_ind] = nums2[nums2_ind];
                    Console.WriteLine($">{string.Join(",", nums1)}");
                    nums1_ind = nums1_ind + 1;
                    break;
                }
                if (nums1[nums1_ind] == 0 && nums1_ind >= m)
                {
                    nums1[nums1_ind] = nums2[nums2_ind];
                    nums1_ind = nums1_ind + 1;
                    break;
                }
                nums1_ind = nums1_ind + 1;   
            }
        }
    }

    public static void Main(string[] args)
    {
        var s = new Solution();
        //var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
        //var nums2 = new int[] { 2, 5, 6 };
        //var nums1 = new int[] { 4, 5, 6, 0, 0, 0 };
        //var nums2 = new int[] { 1, 2, 3 };
        //s.Merge(nums1, 3, nums2, 3);
        //var nums1 = new int[] { 1, 2, 4, 5, 6, 0 };
        //var nums2 = new int[] { 3 };
        //s.Merge(nums1, 5, nums2, 1);
        //var nums1 = new int[] { -1, 0, 0, 3, 3, 3, 0, 0, 0 };
        //var nums2 = new int[] { 1, 2, 2 };
        //s.Merge(nums1, 6, nums2, 3);
        var nums1 = new int[] { -1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0 };
        var nums2 = new int[] { -1,-1, 0, 0, 1, 2 };
        s.Merge(nums1,5, nums2, 6);
        //expected: [-1,-1,-1,0,0,0,0,0,1,2,3]
        Console.WriteLine(string.Join(",", nums1));
    }
}
