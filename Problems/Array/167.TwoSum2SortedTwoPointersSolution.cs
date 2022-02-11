//https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/submissions/
/*
* Two Sum II - Input Array Is Sorted
*/
// Two pointers
// O(n) and O(1)
public class Solution {
    public int[] TwoSum(int[] num, int target) {
        var len = num.Length;
        var j = len-1;
        var i = 0;
        while(i<len){
            if(num[i]+num[j]==target){
                return new [] {i+1, j+1};
            } 
            
            if(num[i]+num[j]>target) {
                j--;
            } else {
                i++;
            }
        }
        
        return null;
    }
}
