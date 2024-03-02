using System;

public class Solution1
{
    public bool IsPalindrome(string s)
    {
        string normStr = "";
        foreach (var ch in s)
        {
            if (char.IsLetter(ch))
            {
                normStr += char.ToLower(ch);
            }
        }
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