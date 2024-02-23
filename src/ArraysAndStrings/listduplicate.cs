
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 
public class ListDuplicate {
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode current = head;
        while(current.next != null)
        {
            if(current.next.val == current.val)
            {
                current=current.next;
            }
            current = current.next;
        }
        return head;
    }
}