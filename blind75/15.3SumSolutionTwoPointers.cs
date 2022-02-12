// https://leetcode.com/problems/3sum/
/*
* Given an integer array nums, return all the triplets 
* [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
* Notice that the solution set must not contain duplicate triplets.
* 
*/
// Two Pointers O(n^2) and time complexity O(n)
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        // sort array in not descending order
        // iterate throug the array
        // if element is bugger than 0 stop iterating just return result
        // if element the same like previos element skip it because we did such check already
        // call the TwoSum2 for the rights side of the rest array after i. Sum2(i, nums)
        //  Sum2 should:
        // Set left=i+1; Right - nums.Lenght
        // Iterate nums till left != right 
        // check that nums[i] + nums[left]+nums[right] = 0, if yes save it to return array, decrase left and right
        // if nums[i] + nums[left]+nums[right] > 0 decrase right else decrase left
        var len = nums.Length;
        Array.Sort(nums);
        var results = new List<IList<int>>();
        for(int i=0; i<len-1; i++){
            if(nums[i]>0){
                return results;
            }
            if(i == 0 || nums[i] != nums[i-1]){
                var result = TwoSum2(i, nums);
                if(result != null){
                    results.AddRange(result);
                }
            }
        }
        
        return results;
    }
    
    private IList<IList<int>> TwoSum2(int currentIPos, int[] nums){
        var currentIItem = nums[currentIPos];
        int left = currentIPos+1, right = nums.Length-1;
        var result = new List<IList<int>>();
        while(left<right){
            var sum = currentIItem + nums[left] + nums[right];
            if(sum == 0){
                result.Add(new List<int>(){
                    currentIItem,
                    nums[left++],
                    nums[right--]
                });
                while(left<right && nums[left]==nums[left-1]){
                    left++;
                }
            } else if(sum>0){
                right--;
            } else {
                left++;
            }
        }
        
        return result.Count > 0 ? result : null;
    }
}
