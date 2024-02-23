using System;
using System.Collections.Generic;

namespace src
{
    class Program
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

            var s = new SolutionBacktrack1();
            var result = s.LetterCombinations("237");
        }
    }
}
