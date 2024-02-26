using System.Collections.Generic;

public class SolutionReverseWord {
    public string ReverseWords(string s) {
        List<string> words = new List<string>();
        int i = 0;
        //skip leading  spaces
        while(!char.IsLetterOrDigit(s[i]))
        {
            i++;
        }
        bool isWord = true;
        string word = "";
        while(i<s.Length)
        {
            if(char.IsLetterOrDigit(s[i]))
            {
                isWord = true;
                 word += s[i];
            }
            else
            {
                if(isWord)
                {
                    words.Add(word);
                    word = "";
                    isWord = false;
                }    
            }  
            i++;
        }
        if(word != "")
        {
            words.Add(word);
        }

        string result = "";
        for(int j = words.Count-1; j>=0; j--)
        {
            result += words[j];
            if(j!=0)
            {
                result += " ";
            }
        }
        return result;
    }
}