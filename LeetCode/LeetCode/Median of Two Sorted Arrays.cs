namespace LeetCode.Median_of_Two_Sorted_Arrays;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] merged = new int[nums1.Length + nums2.Length];

        var first = 0;
        var second = 0;
        var third = 0;

        while (first < nums1.Length || second < nums2.Length)
        {
            if (first == nums1.Length)
            {
                merged[third] = nums2[second];
                second++;
                third++;
            }
            else if (second == nums2.Length)
            {
                merged[third] = nums1[first];
                first++;
                third++;
            }
            else
            {
                var a = nums1[first];
                var b = nums2[second];
            
                if (a < b)
                {
                    merged[third] = a;
                    first++;
                    third++;
                }
                else
                {
                    merged[third] = b;
                    second++;
                    third++;
                }
            }
        }

        if (merged.Length % 2 == 0)
        {
            return (merged[merged.Length / 2] + merged[(merged.Length / 2) - 1]) / 2f;

        }
        else
        {
            return merged[merged.Length / 2];
        }
    }
}