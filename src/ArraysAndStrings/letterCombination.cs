using System.Collections.Generic;
using System.Linq;

public class LetterCombinationsSol {
    public IList<string> LetterCombinations(string digits) {
        string[] matrix = new string[10];
        matrix[2] = "abc";
        matrix[3] = "def";
        matrix[4] = "ghi";
        matrix[5] = "jkl";
        matrix[6] = "mno";
        matrix[7] = "pqrs";
        matrix[8] = "tuv";
        matrix[9] = "wxyz";

        var result = new List<string>();
        var temp = new List<string>();

        foreach(char dig in digits)
        {
            int num = int.Parse(dig.ToString());
            temp.Add(matrix[num]);
        }
        for(int i = 0; i< temp.Count; i++)
        {
            
            for(int j = 0; j< temp[i].Length; j++)
            {
                string comb = "";
                for(int k = 0; k < temp.Count; k++){
                    comb+= temp[k][j];

                }
                result.Add(comb);
            }
            
        }


        return result;
    }
}