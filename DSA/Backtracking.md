
# Backtracking

## Letter Combinations of a Phone Number

[165](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/165/)

```C#
public class Solution {
     List<string> result = new List<string>();
    Dictionary<char, string> matrix = new Dictionary<char, string>(){
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };
    string phoneDigits;

    public IList<string> LetterCombinations(string digits) {
        if(string.IsNullOrEmpty(digits))
        {
            return result;
        }

        phoneDigits = digits;
        backtrack(0, new StringBuilder());
        return result;
    }

    private void backtrack(int index, StringBuilder path)
    {
        if(path.Length == phoneDigits.Length) 
        {
            result.Add(path.ToString());
            return;
        }

        string possibleLetters = matrix[phoneDigits[index]];
        foreach(char letter in possibleLetters) 
        {
            path.Append(letter);
            backtrack(index+1, path);
            path.Remove(path.Length-1, 1);
        }
    }
}
```

## Word Search II

[256](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/256/)

```C#
public class TrieNode
{
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public string word;
}

public class Solution {
    private List<string> result = new List<string>();
    private char[][] board;
    
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        this.board = board;

        //tree contruction
        TrieNode root = new TrieNode();
        foreach(string word in words)
        {
            TrieNode node = root;
            foreach(char letter in word)
            {
                if(node.children.ContainsKey(letter))
                {
                    node = node.children[letter];
                }
                else 
                {
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                    node = newNode;
                }
            }
            node.word = word;
        }

        //backtraking
        for(int row=0;row<board.Length; ++row)
        {
            for(int col = 0; col < board[row].Length; ++col)
            {
                if(root.children.ContainsKey(board[row][col]))
                {
                    backtracking(row, col, root);
                }
            }
        }

        return result;
    }
    
    private void backtracking(int row, int col, TrieNode parent)
    {
        char letter = board[row][col];
        TrieNode curNode = parent.children[letter];

        if(curNode.word != null)
        {
            result.Add(curNode.word);
            curNode.word = null;
        }

        board[row][col] = '#';

        int[] rowOffset = {-1,0,1,0};
        int[] colOffset = {0,1,0,-1};

        for(int i=0; i<4; ++i)
        {
            int newRow = row+rowOffset[i];
            int newCol = col + colOffset[i];
            if(newRow < 0 || newRow >= board.Length || newCol < 0 || newCol >= board[0].Length)
            {
                continue;
            }
            if(curNode.children.ContainsKey(board[newRow][newCol]))
            {
                backtracking(newRow, newCol, curNode);
            }
        }
        board[row][col] = letter;

        if(curNode.children.Count == 0)
        {
            parent.children.Remove(letter);
        }
    }
}
```

## Wildcard Matching

[155](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/155/)

```C#
public class Solution {
    public bool IsMatch(string s, string p) {
        int sLen = s.Length;
        int pLen = p.Length;
        int sIdx = 0;
        int pIdx = 0;
        int starIdx = -1;
        int sTmpIdx = -1;
        while (sIdx < sLen)
        {
            if(pIdx<pLen && (p[pIdx]=='?' || p[pIdx] == s[sIdx]))
            {
                sIdx++;
                pIdx++;
            }
            else if (pIdx < pLen && p[pIdx] == '*')
            {
                starIdx = pIdx;
                sTmpIdx = sIdx;
                ++pIdx;
            }
            else if (starIdx == -1)
            {
                return false;
            }
            else
            {
                pIdx = starIdx + 1;
                sIdx = sTmpIdx + 1;
                sTmpIdx = sIdx;
            }
        }

        for (int i =pIdx; i<pLen; i++)
        {
            if(p[i] != '*')
            {
                return false;
            }
        }
        return true;
    }
}
```

## Regular Expression Matching [189](https://leetcode.com/explore/interview/card/microsoft/46/backtracking/189/)


```C#
public class Solution {
    public bool IsMatch(string s, string p) {
        if(String.IsNullOrEmpty(p)) 
        {
            return String.IsNullOrEmpty(s);
        }

        bool firstMatch = (!String.IsNullOrEmpty(s) && (p[0] == s[0] 
            || p[0] == '.'));

        if(p.Length >= 2 && p[1] == '*')
        {
            return (IsMatch(s, p.Substring(2)) 
                || (firstMatch && IsMatch(s.Substring(1), p)));
        }
        else
        {
            return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
        }
    }
}
```

> O(T^2 + P^2), O(T^2 + P^2)