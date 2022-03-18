// https://leetcode.com/problems/linked-list-cycle-ii/submissions/
/**
 * 142. Linked List Cycle II
 * Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return  * null.
 * Time complexity: O(n); Space complexity: O(1)
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    private ListNode GetIntersection(ListNode head){
        var fast = head;
        var slow = head;
        if(head==null){
            return null;
        }
        
        while(fast?.next!=null){
            slow = slow.next;
            fast = fast?.next?.next;
            if(slow == fast){
                return slow;
            }
        }
        
        return null;
    }
    
    public ListNode DetectCycle(ListNode head) {
        var int1 = GetIntersection(head);
        if(int1==null){
            return null;
        }
        
        var int2 = head;
        while(int1 != int2){
            int1 = int1.next;
            int2 = int2.next;
        }
        
        return int1;
        
    }
}
