// https://leetcode.com/problems/container-with-most-water/solution/
/**
* 11. Container With Most Water
* You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
* Find two lines that together with the x-axis form a container, such that the container contains the most water.
* Return the maximum amount of water a container can store.
* Notice that you may not slant the container.
*/
// Brute-Force solution
// Time cmplexity is O(n^2) and space complexity is O(1)
public class Solution {
    public int MaxArea(int[] height) {
        var len = height.Length;
        var maxSize = 0;
        for(int i=0; i<len; i++){
            for(int j=i+1; j<len; j++){
                // minimum size of height miltiplied with between left and right elements
                var currSize = Math.Min(height[i], height[j]) * (j-i);
                maxSize = Math.Max(maxSize, currSize);
            }
        }
        
        return maxSize;
    }
}
