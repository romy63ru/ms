using System;
using System.Collections.Generic;

namespace src
{
    public class Lists
    {

        //2.1 Remove Dups! Write code to remove duplicates from an unsorted linked list.
        public LinkedList<int> RemoveDuplicates2and1(LinkedList<int>  input)
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
    }
}
