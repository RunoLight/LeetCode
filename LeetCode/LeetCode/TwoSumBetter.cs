namespace LeetCode.TwoSumBetter;
// 1. Two Sum
// https://leetcode.com/problems/two-sum/

// Given an array of integers nums and an integer target, return indices of the two
// numbers such that they add up to target.
// You may assume that each input would have exactly one solution, and you may not
// use the same element twice.
// You can return the answer in any order.

// Example 1:
// 
// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

// Complexity: O(n) time, O(n) space
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // <Number, Index of this number at nums> 
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (dictionary.TryGetValue(complement, out var value))
            {
                return new[] { value, i };
            }

            dictionary[nums[i]] = i;
        }

        return null!;
    }
}