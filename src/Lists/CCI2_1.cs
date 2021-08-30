using System;
using System.Collections.Generic;

namespace Lists
{
    public class CCI2_1
    {

        //2.1 Remove Dups! Write code to remove duplicates from an unsorted linked list.
        public static LinkedList<int> RemoveDuplicates2and1(LinkedList<int> input)
        {
            var result = new LinkedList<int>();
            var n = input.First;
            result.AddLast(n.Value);
            input.RemoveFirst();
            while (input.First.Next != null)
            {
                n = input.First;
                if (!result.Contains(n.Value))
                {
                    result.AddLast(n.Value);
                }
                input.RemoveFirst();
            }
            return result;
        }

        public static LinkedList<int> RemoveDuplicates2and1v2(LinkedList<int> input)
        {
            var current = input.First;
            while (current.Next != null)
            {
                var runner = current.Next;
                while (runner != null)
                {
                    if (runner.Value == current.Value)
                    {
                        input.Remove(runner);
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
            return input;
        }
    }
}
