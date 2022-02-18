// https://leetcode.com/problems/3sum/
/*
* Given an integer array nums, return all the triplets 
* [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
* Notice that the solution set must not contain duplicate triplets.
* 
*/
// Not Sort solution O(n^2) and time complexity O(n)
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var len = nums.Length;
        var resultWithHash = new Dictionary<string, IList<int>>();
        var dup = new Dictionary<int, int>();
        var seen = new Dictionary<int, int>();
        for(int i=0; i<len; i++){
            if(!dup.ContainsKey(nums[i])) {
                for(int j = i+1; j<len; j++){
                    var complement = -nums[i]-nums[j];
                    var indexInSeenArray = 0;
                    if(seen.TryGetValue(complement, out indexInSeenArray) && i == indexInSeenArray){
                        var resArr = new int[]{nums[i], nums[j], complement};
                        Array.Sort(resArr);
                        // using hashing of three digits
                        resultWithHash[string.Join(",", resArr)] = resArr;                        
                    }
                    
                    seen[nums[j]] = i;
                }
            }
            
            dup[nums[i]] = nums[i];
        }

        return resultWithHash.Values.ToList();
    }
}
