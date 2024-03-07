# Array and Strings

`ArrayList()` 
Read O(1) Insert O(1)

`StringBuilder()`

`Dictionary(Hash)`
O(1) but lot of collision O(N)

## Two Sum [173](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/173/)

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

### Example 1:

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
```

### Example 2:

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

### Example 3:

```
Input: nums = [3,3], target = 6
Output: [0,1]
```

### Constraints:

```
2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
``` 

> Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

```C#
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int,int>();
        for(int i =0; i < nums.Length; i++)
        {
            int completment = target - nums[i];
            if(map.ContainsKey(completment))
            {
                return new int[] {map[completment], i};
            }
            map[nums[i]] = i;
        }
        return null;
    }
}
```

> Time O(N), Space O(N)

[Solution](https://leetcode.com/problems/two-sum/editorial/)

## Valid Palindrome [162](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/162/)

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

```C#
public class Solution {
    public bool IsPalindrome(string s)
    {
        if (s == " ") return true;
        string normStr = "";
        foreach (var ch in s)
        {
            if (char.IsLetterOrDigit(ch))
            {
                normStr += char.ToLower(ch);
            }
        }
        if (normStr == "") return true;
        int j = normStr.Length - 1;
        for (int i = 0; i < normStr.Length / 2 + 1; i++)
        {
            if (normStr[i] != normStr[j])
            {
                return false;
            }
            j--;
        }
        return true;
    }
}
```

> Time O(N), Space O(N)

[Solution](https://leetcode.com/problems/valid-palindrome/editorial/)

## String to Integer (atoi) [171](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/171/)

Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).

The algorithm for myAtoi(string s) is as follows:

1. Read in and ignore any leading whitespace.
2. Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
3. Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
4. Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
5. If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
6. Return the integer as the final result.

```C#
public class Solution {
    public int MyAtoi(string s) 
    {
        var i = 0;
        while (i < s.Length && s[i] is ' ') i++;
        var negative = false;
        if (i < s.Length && s[i] is '-' or '+')
        {
            negative = s[i++] == '-';
        }
        int value = 0;

        while (i < s.Length && char.IsDigit(s[i])) 
        {
            const int BASE = 10;
            var append = s[i++] - '0';
            try {
                checked {
                    value *= BASE;
                    if (negative) value -= append;
                    else value += append;
                }
            } catch (OverflowException) {
                value = negative ? int.MinValue : int.MaxValue;
                break;
            }
        }
        return value;
    }
}
```
> Time O(N), Space O(1)

[Solution](https://leetcode.com/problems/string-to-integer-atoi/editorial/)

## Reverse String [187](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/187/)

Write a function that reverses a string. The input string is given as an array of characters s.
You must do this by modifying the input array in-place with O(1) extra memory.

### Example 1:

```
Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]
```

### Example 2:

```
Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
```

### Constraints:

```
1 <= s.length <= 105
s[i] is a printable ascii character.
```

```C#
public class Solution {
    public void ReverseString(char[] s) {
        int i = 0;
        int j = s.Length-1;
        char tmp = ' ';
        while(i < j)
        {
            tmp = s[j];
            s[j] = s[i];
            s[i] = tmp;
            i++;
            j--;
        }
    }
}
```

> Time O(N), Space O(1)

[Solution](https://leetcode.com/problems/reverse-string/editorial/)


## Reverse Words in a String [166](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/166/)

Given an input string s, reverse the order of the words.
A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.
Return a string of the words in reverse order concatenated by a single space.
Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

 

### Example 1:

```
Input: s = "the sky is blue"
Output: "blue is sky the"
```

### Example 2:

```
Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
```

### Example 3:

```
Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
```

### Constraints:

```
1 <= s.length <= 104
s contains English letters (upper-case and lower-case), digits, and spaces ' '.
There is at least one word in s.
``` 

> Follow-up: If the string data type is mutable in your language, can you solve it in-place with O(1) extra space?
> **Approach 2: Reverse the Whole String and Then Reverse Each Word (with submethods)**

```C#
public class Solution {
    public string ReverseWords(string s) {
        List<string> map = new List<string>();
        string tmp = "";
        s.Trim();
        foreach(char ch in s)
        {
            if(Char.IsLetterOrDigit(ch))
            {
                tmp += ch;
            }
            else
            {
                if(!String.IsNullOrEmpty(tmp))
                {
                    map.Add(tmp);
                    tmp = "";
                }
            }
        }
      
        string result = tmp;
        for(int i = map.Count-1; i>=0; i--)
        {
            result += " " + map[i];
        }
        return result.Trim();
    }
}
```

[Solution](https://leetcode.com/problems/reverse-words-in-a-string/editorial/)

 - [ ] Reverse Words in a String II [213](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/213/)
 - [ ] Valid Parentheses [179](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/179/)
 - [ ] Longest Palindromic Substring [180](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/180/)
 - [ ] Group Anagrams [200](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/200/)
 - [ ] Trapping Rain Water [211](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/211/)
 - [ ] Set Matrix Zeroes [203](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/203/)
 - [ ] Rotate Image [202](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/202/)
 - [ ] Spiral Matrix [178](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/178/)
