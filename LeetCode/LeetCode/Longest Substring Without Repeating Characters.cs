namespace LeetCode.Longest_Substring_Without_Repeating_Characters;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> charToLastMetIndex = new Dictionary<char, int>(50);
        int maxSubstringLength = 0;
        int substringStartIndex = 0;

        // Let's search for this substring by creating two borders (left and right) and move them along the input string.
        // Everytime borders are moved - we get a new substring that starts at left border and ends at right border.
        
        // Everytime we get a new substring - save its length to the answer if it's the longest at the moment.
        // Everytime we get a new char while iterating - save to the dictionary its index, so map will hold indexes of last
        // occurrences of characters.
        
        // There's left border index (substringStartIndex), and right border (i).
        
        // The cycle:
        
        // 1) At first, move right border.
        // Move right border by just iterating the input string.
        
        // 2) Then conditionally move left border.
        // Move left border when, while iterating left border, we meet char that we already met at index that is to
        // the right of left border (that means that in current substring we meet this character twice). Move left border
        // to the next character after previously found repeated character.
        // Example: "abcae"
        // when i = 2, s[i] = "c". substring = "abc".
        // when i = 3, s[i] = "a". We need to set the start of current substring next to the first "a", so it's "b"
        // so substring = "bca"
        
        // 3) Then save current substring length if it's longest at the moment. 
        
        for (int i = 0; i < s.Length; i++)
        {
            if (charToLastMetIndex.ContainsKey(s[i]))
            {
                if (charToLastMetIndex[s[i]] >= substringStartIndex)
                {
                    substringStartIndex = charToLastMetIndex[s[i]] + 1;
                }
            }

            int lengthOfThisSubstring = i - substringStartIndex + 1;
            maxSubstringLength = Math.Max(maxSubstringLength, lengthOfThisSubstring);

            charToLastMetIndex[s[i]] = i;
        }

        return maxSubstringLength;
    }
}