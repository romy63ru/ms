   
   public class Sorting1 {
   public int RemoveDuplicates(int[] nums) {
        int i = 0;
        int j = 0;
        int result = 0;
        while(i<nums.Length-1)
        {
            while(nums[j]==nums[j+1])
            {
                j++;
                if(j==nums.Length-1)
                {
                    return result;
                }
            }
            j++;
            if(nums[i]==nums[i+1])
            {
                nums[i+1]=nums[j];
                result++;
                i++;
            }
        }
        return result;
    }
   }