// 1. Two Sum
// https://leetcode.com/problems/two-sum/

// Given an array of integers nums and an integer target, return indices of the two
// numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not
// use the same element twice.
// You can return the answer in any order.

public class Solution
{
    public class Digit
    {
        public int idx;
        public int value;
    }

    public int[] TwoSum(int[] nums, int target)
    {
        List<Digit> l = new List<Digit>();
        {
            for (int i = 0; i < nums.Length; i++)
            {
                l.Add(new Digit { idx = i, value = nums[i] });
            }

            // Quicksort; O(n log n); worst case O(n ^ 2).
            // Let's have an array of sorted given numbers,
            // while remember original array's index of each (for printing the result) 
            l.Sort((a, b) => a.value.CompareTo(b.value));
        }

        int leftBorder = 0;
        int rightBorder = l.Count - 1;

        // O(n)
        // When left border moves right - left sum's number getting bigger, when right border moves left - right sum's
        // number getting smaller, because array is sorted.
        while (true)
        {
            var sum = l[leftBorder].value + l[rightBorder].value;
            if (sum < target)
            {
                leftBorder++;
            }
            else if (sum > target)
            {
                rightBorder--;
            }
            else
            {
                break;
            }
        }

        return new[] { l[leftBorder].idx, l[rightBorder].idx };
    }
}