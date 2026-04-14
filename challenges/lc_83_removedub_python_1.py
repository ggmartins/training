class ListNode(object):
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
     def __repr__(self):
         return f"[{self.val}, {self.next}]"

class Solution(object):
    def deleteDuplicates(self, head):
        """
        :type head: Optional[ListNode]
        :rtype: Optional[ListNode]
        """
        if not head:
            return None
        if not head.next:
            return head
        ind = head
        ls = ind
        while ind is not None:
            mov = ind.next
            while mov is not None and ind.val == mov.val:
                mov = mov.next
            ind.next = mov
            ind = ind.next
        return ls


if __name__ == "__main__":
  s = Solution()
  testdata = {
	"test1" : ListNode(1, ListNode(1, ListNode(3, ListNode(2,ListNode(2, None))))),
        "test2" : ListNode(4, ListNode(3, ListNode(3, ListNode(2,ListNode(2, ListNode(1, None))))))
      }

  for n, d in testdata.items():
      print(f"{n}, {s.deleteDuplicates(d)}")
