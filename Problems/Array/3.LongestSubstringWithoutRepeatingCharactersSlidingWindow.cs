// https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
/*
* 3. Longest Substring Without Repeating Characters
* Given a string s, find the length of the longest substring without repeating characters.
*/
// Sliding-Window approarch
// Time complexity is O(n); Space complexity O(M)
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var len = s.Length;
        var max = 0;
        var left = 0;
        var pos = 0;
        var dict = new Dictionary<char, int>();
        for(var right = 0;right<len; right++){
            var c = s[right];
            if(dict.TryGetValue(c, out pos)){
                if(pos >= left){
                    left = pos+1;
                }
            } 
            
            dict[c] = right;
            max = Math.Max(max, right-left+1);
        }
        
        return max;
    }
}
