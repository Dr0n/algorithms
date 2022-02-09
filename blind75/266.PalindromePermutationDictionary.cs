// https://leetcode.com/problems/palindrome-permutation/
/**
* 266. Palindrome Permutation
* Given a string s, return true if a permutation of the string could form a palindrome.
*
*/
// HashMap solution O(n), O(1) - constant extra space Any methods that use map or set should have space complexity O(1) as the char number should be less than 256 as the assumption in the O(128) or O(256
public class Solution {
    public bool CanPermutePalindrome(string s) {
        var arr = new int[128];
        var dic = new Dictionary<char, int>();
        for(int i=0; i<s.Length; i++){
            if(dic.ContainsKey(s[i])){
                dic.Remove(s[i]);
            } else {
                dic[s[i]] = 1;
            }
        }
       
        return dic.Count <= 1;
        
    }
}
