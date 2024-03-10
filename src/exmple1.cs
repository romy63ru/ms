
using System.Collections.Generic;
using System.Linq;

public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
 }
 
public class SolutionMergeKLists {
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode prehead = new ListNode(-1);
        ListNode result = prehead;
        List<ListNode> values = new List<ListNode>();
        
        bool noEmpty = true;
        while (noEmpty)
        {
            values.Clear();
            noEmpty = false;
            for(int i = 0; i < lists.Length; i++)
            {
                if(lists[i] != null)
                {
                    noEmpty = true;
                    values.Add(lists[i]);
                    lists[i] = lists[i].next;
                }
            }
            foreach(ListNode node in values.OrderBy(s=>s.val))
            {
                result.next = node;
                result = result.next;
            }
        }
        
        return prehead.next;
    }
}