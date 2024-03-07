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

### Example 1

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
```

### Example 2

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

### Example 3

```
Input: nums = [3,3], target = 6
Output: [0,1]
```

### Constraints

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

### Example 1

```
Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]
```

### Example 2

```
Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
```

### Constraints

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

### Example 1

```
Input: s = "the sky is blue"
Output: "blue is sky the"
```

### Example 2

```
Input: s = "  hello world  "
Output: "world hello"
Explanation: Your reversed string should not contain leading or trailing spaces.
```

### Example 3

```
Input: s = "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
```

### Constraints

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

## Reverse Words in a String II [213](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/213/)

Given a character array s, reverse the order of the words.
A word is defined as a sequence of non-space characters. The words in s will be separated by a single space.
Your code must solve the problem in-place, i.e. without allocating extra space.

### Example 1:

```
Input: s = ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
Output: ["b","l","u","e"," ","i","s"," ","s","k","y"," ","t","h","e"]
```

### Example 2:

```
Input: s = ["a"]
Output: ["a"]
``` 

### Constraints:

```
1 <= s.length <= 105
s[i] is an English letter (uppercase or lowercase), digit, or space ' '.
There is at least one word in s.
s does not contain leading or trailing spaces.
All the words in s are guaranteed to be separated by a single space.
```

```C#
public class Solution {
    public char[] ReverseString(char[] s, int i, int j)
    {
        char tmp = ' ';
        while(i<j)
        {
            tmp = s[j];
            s[j] = s[i];
            s[i] = tmp;
            i++;
            j--;
        }
        return s;
    }
    
    public void ReverseWords(char[] s) {
        int i = 0;
        int j = 0;
        s = ReverseString(s, 0, s.Count()-1);
        while(i<s.Count())
        {
            while(j<s.Count() && s[j] != ' ')
            {
                j++;
            }
            s = ReverseString(s, i, j-1);    
            j++;
            i=j;
        }
    }
}
```
> Time O(N), Space O(1)


[Solution](https://leetcode.com/problems/reverse-words-in-a-string-ii/editorial/)

## Valid Parentheses [179](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/179/)

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
An input string is valid if:

1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.
3. Every close bracket has a corresponding open bracket of the same type.
 

### Example 1:

```
Input: s = "()"
Output: true
```

### Example 2:

```
Input: s = "()[]{}"
Output: true
```

# Example 3:

```
Input: s = "(]"
Output: false
 ```

### Constraints:

```
1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
```

```C#
public class Solution {
    public bool IsValid(string s) {
        Stack<char> temp = new Stack<char> ();
        for(int i = 0; i<s.Length; i++)
        {
            if(s[i] == '(' || s[i] == '[' || s[i] == '{') temp.Push(s[i]);
            else if(s[i] == ')' || s[i] == ']' || s[i] == '}') 
            {
                if(temp.Count > 0)
                {
                    char t = temp.Peek();
                    if(t == '(' && s[i] == ')' || t == '[' && s[i] == ']' || t == '{' && s[i] == '}') temp.Pop();
                    else return false;
                }
                else return false;
            }
            else continue;
        }
        if(temp.Count == 0) return true;
        else return false;
    }
}
```



## Longest Palindromic Substring [180](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/180/)

Given a string s, return the longest palindromic substring in s.

### Example 1:

```
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
```

### Example 2:

```
Input: s = "cbbd"
Output: "bb"
```

### Constraints:

```
1 <= s.length <= 1000
s consist of only digits and English letters.
```

```C#
public class Solution {
    public string LongestPalindrome(string s) {
        string T = "^#" + string.Join("#", s.ToCharArray()) + "#$";
        int n = T.Length;
        int[] P = new int[n];
        int C = 0, R = 0;
        
        for (int i = 1; i < n-1; i++) {
            P[i] = (R > i) ? Math.Min(R - i, P[2*C - i]) : 0;
            while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                P[i]++;
            
            if (i + P[i] > R) {
                C = i;
                R = i + P[i];
            }
        }
        
        int max_len = P.Max();
        int center_index = Array.IndexOf(P, max_len);
        return s.Substring((center_index - max_len) / 2, max_len);
    }
}
```

> Time O(N), Space o(N)

[Solution](https://leetcode.com/problems/longest-palindromic-substring/editorial/)



## Group Anagrams [200](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/200/)

Given an array of strings strs, group the anagrams together. You can return the answer in any order.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
 
### Example 1:

```
Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
```

### Example 2:

```
Input: strs = [""]
Output: [[""]]
```

### Example 3:

```
Input: strs = ["a"]
Output: [["a"]]
``` 

### Constraints:

```
1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
```

```C#
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        return strs
            .GroupBy(s => new string(s.OrderBy(c => c).ToArray()))
            .Select(g => g.ToList() as IList<string>)
            .ToList();
    }
}
```


## Trapping Rain Water [211](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/211/)

Two pointers

```C#
public class Solution {
    public int Trap(int[] height) {
        int n = height.Length, left = 0, right = n-1;
        int leftMax = 0, rightMax = 0;
        int ans = 0; 

        while(left<right)
        {
            if(height[left]<height[right])
            {
                if(leftMax<height[left])
                {
                    leftMax = height[left];
                }
                else
                {
                    ans+= leftMax-height[left];
                }
                left++;
            }
            else
            {
                if(rightMax<height[right])
                {
                    rightMax =  height[right];
                }
                else
                {
                    ans+=rightMax-height[right];
                }
                right--;
            }
        }
        return ans;
    }
}
```

> Time O(N), Space O(1)

## Set Matrix Zeroes [203](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/203/)

```C#
public class Solution {
    public void SetZeroes(int[][] matrix) 
    {
        bool firstRow = false, firstCol = false;
        
        for(int r = 0; r < matrix.Length; r++) {
            for(int c = 0; c < matrix[0].Length; c++) 
            {
                if(matrix[r][c] == 0) {
                    if(r == 0) firstRow = true; 
                    if(c == 0) firstCol = true; 
                    matrix[r][0] = 0; 
                    matrix[0][c] = 0;
                }
            }
        }

        for(int r = 1; r < matrix.Length; r++) {
            for(int c = 1; c < matrix[0].Length; c++) {
                if(matrix[r][0] == 0 || matrix[0][c] == 0) {
                        matrix[r][c] = 0;
                }
            }
        }   

        if(firstRow) {
            for(int c = 0; c < matrix[0].Length; c++) {
                matrix[0][c] = 0;
            }
        } 

        if(firstCol) {
            for(int r = 0; r < matrix.Length; r++) {
                matrix[r][0] = 0;
            }
        }      
    }
}
```

> Time O(MxN), Space O(1)

[Solution](https://leetcode.com/problems/set-matrix-zeroes/editorial/)

## Rotate Image [202](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/202/)

```C#
public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        for(int i=0; i<(n+1)/2; i++)
        {
            for(int j = 0; j < n/2; j++)
            {
                int temp = matrix[n-1-j][i];
                matrix[n-1-j][i] = matrix[n-1-i][n-j-1];
                matrix[n-1-i][n-j-1] = matrix[j][n-1-i];
                matrix[j][n-1-i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
    }
}
```

## Spiral Matrix [178](https://leetcode.com/explore/interview/card/microsoft/30/array-and-strings/178/)

```C#
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> res = new List<int>();
        int top = 0;
        int left = 0;
        int right = matrix[0].Length - 1;
        int bot = matrix.Length - 1;
        int elements = matrix.Length * matrix[0].Length;

        while (res.Count < elements) {
            for (int i = left; i <= right && res.Count < elements; i++) {
                res.Add(matrix[top][i]);
            }
            top++;
            for (int j = top; j <= bot && res.Count < elements; j++) {
                res.Add(matrix[j][right]);
            }
            right--;
            for (int i = right; i >= left && res.Count < elements; i--) {
                res.Add(matrix[bot][i]);
            }
            bot--;
            for (int i = bot; i >= top && res.Count < elements; i--) {
                res.Add(matrix[i][left]);
            }
            left++;
        }

        return res;
    }
}
```

> Time O(MxN), Space O(1)
