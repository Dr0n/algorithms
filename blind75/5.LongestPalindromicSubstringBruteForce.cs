// https://leetcode.com/problems/longest-palindromic-substring/
/*
* Given a string s, return the longest palindromic substring in s.
*/
// Brute-Force O(n^3); o(m)
// generates TLE at leetcode
public class Solution {
    public string LongestPalindrome(string s) {
        var len = s.Length;
        if(len == 1){
            return s;
        }

        var maxSize = 0;
        var maxLeftPos = 0;
        var maxRightPos = 0;
        var midle = len/2;
        for(var left=0; left<len; left++ ){
            for(var right = left; right<len; right++){
                var currSize = right-left+1;
                var subStringToCheck = s.Substring(left, currSize);
                if(IsPalindromic(subStringToCheck)){
                    
                    if(currSize>maxSize){
                        maxSize = currSize;
                        maxLeftPos = left;
                        maxRightPos = right;
                    }
                }
            }
        }
        
        return maxSize == 0 ? null : s.Substring(maxLeftPos, maxRightPos-maxLeftPos+1);
        
    }
    
    private bool IsPalindromic(string s){
        var len = s.Length;
        var j = len-1;
        for(var i=0; i<j; i++){
            if(s[i] != s[j]){
                return false;
            }
            j--;
        }
        return true;
    }
}
