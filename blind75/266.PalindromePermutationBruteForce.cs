// https://leetcode.com/problems/palindrome-permutation/
/**
* 266. Palindrome Permutation
* Given a string s, return true if a permutation of the string could form a palindrome.
*
*/
// Brute-Force solution O(n), O(1) - constant extra space
public class Solution {
    public bool CanPermutePalindrome(string s) {
        var arr = new int[128];
        for(int i=0; i<s.Length; i++){
            arr[s[i]]++;
        }
        
        var countOdd = 0;
        // count how many odd latters there
        for(int i=0; i< arr.Length; i++){
            countOdd += arr[i]%2;
        }
        
        // string cant be converted to palindrome if there more than 1 odd letter 
        // for example "aabbcg" cant be palindrome  because of the "cg" which exists once
        return countOdd < 2;
    }
}
