using System;
using System.Collections.Generic;
using leetcode;

namespace src
{
    partial class Program
    {
        static void Main(string[] args)
        {

            // var pal = new Solution();
            // Console.WriteLine(pal.IsPalindrome("race a car"));
            // Console.WriteLine(pal.IsPalindrome("A man, a plan, a canal: Panama"));


            // var d = new ListDuplicate();
            // var head = new ListNode();
            // head.val = 1;
            // head.next = new ListNode();
            // head.next.val = 1;
            // head.next.next = new ListNode();
            // head.next.next.val =2;

            // d.DeleteDuplicates(head);

            // var d = new LetterCombinationsSol();
            // Console.WriteLine(d.LetterCombinations("23"));

            // var s = new SolutionBacktrack1();
            // var result = s.LetterCombinations("237");

            // var s = new SolutionMatchWord();
            // var r = s.IsMatch("aa", "a");

            // var s = new Sorting1();
            // var res = s.RemoveDuplicates(new int[] { 1, 1, 2, 3, 4, 4, 4 });
            // var res2 = s.RemoveDuplicates(new int[] { 1, 1, 2});

            // var s = new SolutionSorting2();
            // // var r = s.FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
            // var r2 = s.FindMin(new int[]{11,13,15,17});

            // var s = new SolutionCoins();
            // var r = s.Change(5, [1,2,5]);
            var s = new SolutionMergeKLists();
            var l1 = new ListNode(1, new ListNode(4, new ListNode(5)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var l3 = new ListNode(2, new ListNode(6));
            s.MergeKLists([l1, l2, l3]);

//[[1,4,5],[1,3,4],[2,6]]

        }
    }
}
