// https://leetcode.com/problems/longest-palindromic-substring/
/*
* Given a string s, return the longest palindromic substring in s.
*/
// Sliding Window from center O(n^2); o(1)
public class Solution {
    public string LongestPalindrome(string s) {
        var len = s.Length;
        if(len <= 1){
            return s;
        }

        var start = 0; 
        var maxLen = 0;
        for(var i=0; i<len; i++ ){
            var left = i;
            var right = i;
            var len1 = ArroundTheCenter(s, i, i);
            var len2 = ArroundTheCenter(s, i, i+1);
            var maxLenFromTwo = Math.Max(len1, len2);
            if(maxLenFromTwo > maxLen){
                start = i - (maxLenFromTwo - 1) / 2;
                maxLen =  maxLenFromTwo;
            }
        }
        
        return s.Substring(start, maxLen);
    }
    
    private int ArroundTheCenter(string s, int l, int r){
        int left = l;
        int right = r;
        while(left>=0 && right<s.Length && s[left]==s[right]){
            left--;
            right++;
        }
        return right - left - 1;
    }
}
