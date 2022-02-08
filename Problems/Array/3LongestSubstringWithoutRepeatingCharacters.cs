// https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
/*
* 3. Longest Substring Without Repeating Characters
* Given a string s, find the length of the longest substring without repeating characters.
*/
// Brute-Force approarch
// Time complexity is O(n^3); Space complexity O(M)
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var len = s.Length;
        var max = 0;
        for(var left=0; left<len; left++){
            for(var right=left; right<len && IsUniqueSubstring(s, left, right); right++){
                max = Math.Max(max, right-left+1);
            }
        }
        
        return max;
    }
    
    private bool IsUniqueSubstring(string s, int start, int stop){
        var chars = new int[128];
        for(var i=start; i<=stop; i++){
            var c = s[i];
            if(chars[c] > 0){
                return false;
            }
            
            chars[s[i]]++;
        }
        
        return true;
    }
}
