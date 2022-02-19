// https://leetcode.com/problems/design-linked-list/submissions/
/*
* 707. Design Linked List
* Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
* A node in a singly linked list should have two attributes: val and next. val is the value of the 
* current node, and next is a pointer/reference to the next node.
* If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. * Assume all nodes in the linked list are 0-indexed.
*/
// Singly Linked List solution
// Time complexity: O(1) for addAtHead. O(k) for get, addAtIndex, and deleteAtIndex, where kk is an 
// index of the element to get, add or delete. O(N) for addAtTail.
public class SingleListNode{
    public int Val;
    
    public SingleListNode Next;
    
    public SingleListNode(int val){
        Val = val;
    }
}
public class MyLinkedList {
    private int _size;
    private SingleListNode _head;
    
    public MyLinkedList() {
        _head = new SingleListNode(0);
    }
    
    public int Get(int index) {
        if(index < 0 || index >= _size){
            return -1;
        }
        
        return RewindToIndex(index+1).Val;
    }
    
    public void AddAtHead(int val) {
        AddAtIndex(0, val);
    }
    
    public void AddAtTail(int val) {
        AddAtIndex(_size, val);
    }
    
    public void AddAtIndex(int index, int val) {
        if(index > _size){
            return;
        }
        
        var node = RewindToIndex(index);
        var newNode = new SingleListNode(val);
        newNode.Next = node.Next;
        node.Next = newNode;
        _size++;

    }
    
    public void DeleteAtIndex(int index) {
         if (index < 0 || index >= _size) return;
        var prevNode = RewindToIndex(index);
        var nextNode = prevNode.Next;
        prevNode.Next = nextNode.Next;
        _size--;
        
    }
    
    private SingleListNode RewindToIndex(int index){
        if(index < 0){
            index = 0;
        }
        
        if(index > _size){
            index = _size-1;
        }
        
        var curr = _head;
        for(var i=0; i<index; i++){
            curr = curr.Next;
        }
        
        return curr;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
