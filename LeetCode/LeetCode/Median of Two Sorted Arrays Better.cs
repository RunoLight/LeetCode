// namespace LeetCode.Median_of_Two_Sorted_Arrays_Better;

public static class ABC
{
    public static void SEDX()
    {
        var s = new Solution();
        /* 2   */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { 2,2,4,4 }, new[] { 2,2,2,4,4 }));
        /* 2.5 */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { 1, 3 }, new[] { 2, 4 }));
        /* 2   */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { 1, 3 }, new[] { 2 }));
        /* 2   */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { }, new[] { 2 }));
        /* 2.5 */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { }, new[] { 2, 3 }));
        /* 2.5 */   Console.WriteLine(s.FindMedianSortedArrays(new int[] { 2, 3 }, new int[] { }));
    }
}

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        Console.WriteLine("start");

        int mergedLength = nums1.Length + nums2.Length;
        int indexToGoTo = mergedLength % 2 == 1 ? mergedLength / 2 - 1 : mergedLength / 2 - 1;
        
        var first = 0;
        var second = 0;
        var third = 0;

        var lastValue = 0;
        
        while (third < indexToGoTo)
        {
            if (first == nums1.Length)
            {
                second++;
                third++;
            }
            else if (second == nums2.Length)
            {
                first++;
                third++;
            }
            else
            {
                var a = nums1[first];
                var b = nums2[second];
            
                if (a < b)
                {
                    first++;
                    third++;
                }
                else
                {
                    second++;
                    third++;
                }
            }
        }

        if (mergedLength % 2 == 1)
        {
            if (nums1.Length == 0)
                return nums2[second];
            if (nums2.Length == 0)
                return nums1[first];
            
            var c = nums1[first];
            var d = nums2[second];

            return Math.Min(c, d); 
        }
        else
        {
            var f = 0;

            if (nums1.Length == 0)
            {
                f = nums2[second];
                return (f + nums2[++second]) / 2f;
            }

            if (nums2.Length == 0)
            {
                f= nums1[first];
                return (f + nums1[++first]) / 2f;
            }

            var c = nums1[first];
            var d = nums2[second];

            return (c + d) / 2f;
        }


        // if (merged.Length % 2 == 0)
        // {
        //     return (merged[merged.Length / 2] + merged[(merged.Length / 2) - 1]) / 2f;
        //
        // }
        // else
        // {
        //     return merged[merged.Length / 2];
        // }
    }
}