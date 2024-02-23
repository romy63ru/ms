using System.Collections.Generic;
using System.Text;

public class SolutionBacktrack1 {
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