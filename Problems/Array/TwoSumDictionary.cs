// https://leetcode.com/problems/two-sum/
/*
* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
* You may assume that each input would have exactly one solution, and you may not use the same element twice.
* You can return the answer in any order.
*/
// solution with hash table(in c# word Dictionary), O(n) algorythm complexity and O(n) time complexity, O(n) space comlexity (+ additional Dictionary the sam esize as input array)
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var len = nums.Length;
        var dict = new Dictionary<int, int>(len);
        int indexOfSecondD;
        for(int i=0; i< len; i++){
            var findD = target - nums[i];
            if(dict.TryGetValue(findD, out indexOfSecondD)){
                return new int[] {i, indexOfSecondD};
            }
            
            dict.TryAdd(nums[i], i);
        }
        
        return null;
        
    }
}
