public class SolutionMatchWord {

    
    public bool IsMatch(string s, string p) {
        int sLen = s.Length;
        int pLen = p.Length;
        int sIdx = 0;
        int pIdx = 0;
        int starIdx = -1;
        int sTmpIdx = -1;
        while (sIdx < sLen)
        {
            if(pIdx<pLen && p[pIdx]=='?' || p[pIdx] == s[sIdx])
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