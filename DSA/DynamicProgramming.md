# Dynamic programming

## Best Time to Buy and Sell Stock

[186](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/186/)

```C#
public class Solution {
    public int MaxProfit(int[] prices) {
        int min = Int32.MaxValue;
        int profit  = 0; 
        for(int i = 0; i< prices.Length; i++)
        {
            if(prices[i] < min)
            {
                min = prices[i];
            }
            else if(prices[i]-min > profit)
            {
                profit = prices[i] - min;
            }
        }
        return profit;
    }
}
```

- [ ] Maximum Subarray [174](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/174/)

## Longest Increasing Subsequence

[156](https://leetcode.com/explore/interview/card/microsoft/49/dynamic-programming/156/)

```C#
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int len = 0;
        int[] tails = new int[nums.Length];

        foreach (int num in nums) {
            int left = 0, right = len;
            
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (tails[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            
            tails[left] = num;
            if (left == len) {
                len++;
            }
        }
        
        return len;
    }
}
```
