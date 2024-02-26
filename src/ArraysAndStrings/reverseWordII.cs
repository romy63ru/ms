using System;

public class ReverseWordIISolution
{
    public void ReverseWords(char[] s)
    {
        Array.Reverse(s);
        int i = 0;
        int j = 0;

        while (j < s.Length)
        {
            if (char.IsLetterOrDigit(s[j]))
            {
                j++;
            }
            else
            {
                int k = j - 1;
                while (i <= k)
                {
                    char tmp = s[i];
                    s[i] = s[k];
                    s[k] = tmp;
                    i++;
                    k--;
                }
                j++;
                i = j;
            }
            

        }
        int d = j - 1;
            while (i <= d)
            {
                char tmp = s[i];
                s[i] = s[d];
                s[d] = tmp;
                i++;
                d--;
            }

    }
}