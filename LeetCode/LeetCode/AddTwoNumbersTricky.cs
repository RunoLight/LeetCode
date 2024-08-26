namespace LeetCode.AddTwoNumbersTricky;

// # Intuition
// Generate new parallel Linked List for summation of each node
// Iterate over all the nodes of both the list simultaneously. Add carry generated from previous sum of iteration.
// 
//     Edge cases: if either lists have less elements, add up the carry to longer list only
//     Also, iterate the loop till carry is set to 0. There may be a case where sum of last iteration can go over 9. Here, we need to add another node to accomaodate carry
// 
// # Approach
// Now let's say we don't need the original data anymore. Assuming this, we can use nodes from any of current list. That way we create new nodes only for dummy that contains reference to start of our result and one node for case when both linked-list are ended but we need to add one more node to carry bonus 1 from previous sum if it was >= 10.
// 
// # Complexity
// - Time complexity:
//     $$O(n)$$
// 
// - Space complexity:
//     $$O(n)$$

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode();
        var tail = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry == 1)
        {
            var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = sum / 10;

            ListNode newTail = l1 ?? l2 ?? new ListNode();
            newTail.val = sum % 10;
            tail.next = newTail;
            tail = newTail;

            l1 = l1?.next;
            l2 = l2?.next;
        }
        
        return dummy.next;
    }
}