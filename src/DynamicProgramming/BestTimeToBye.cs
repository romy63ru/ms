public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length == 1)
        {
            return 0;
        }
        int max = 0;
        int i = 0; 
        int j = 1;
        while(i<prices.Length-1)
        {
            j=i+1;
            while(j<prices.Length)
            {
                if(prices[j]-prices[i]>max)
                {
                    max =prices[j]-prices[i];
                }
                j++;
            }
            i++;
        }
        return max;
    }
}