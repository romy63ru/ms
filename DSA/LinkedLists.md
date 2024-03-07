# LinkedList

`LinkedList<T>()` 
in C# cant manage nodes!

- [ ] Reverse Linked List [169](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/169/)


## Linked List Cycle

[https://leetcode.com/explore/interview/card/microsoft/32/linked-list/184/]

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.

```C#
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head==null) return false;
        List<ListNode> list = new List<ListNode>();
        ListNode node = head;
        while(node.next != null)
        {
            if(list.Contains(node))
            {
                return true;
            }
            list.Add(node);
            node = node.next;
        }
        return false;
    }
}
```

> O(N)?

- [ ] Add Two Numbers [170](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/170/)
- [ ] Add Two Numbers II [205](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/205/)
- [ ] Merge Two Sorted Lists [175](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/175/)
- [ ] Merge k Sorted Lists [209](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/209/)
- [ ] Intersection of Two Linked Lists [212](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/212/)
- [ ] Copy List with Random Pointer [168](https://leetcode.com/explore/interview/card/microsoft/32/linked-list/168/)
