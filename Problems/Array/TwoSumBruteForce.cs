// https://leetcode.com/problems/two-sum/
/*
* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
* You may assume that each input would have exactly one solution, and you may not use the same element twice.
* You can return the answer in any order.
*/
// In this example it is just brute-force solution

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var len = nums.Length;
        for(var i = 0; i<len; i++){
            var j = len-1;
            while(j != i){
                if(nums[i]+nums[j--] == target){
                    return new int[]{i,++j};
                }
            }
        }
        
        return null;
    }
}
