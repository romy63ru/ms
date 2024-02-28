public class SolutionSorting2 {
    public int FindMin(int[] nums) {
        int i;
        if(nums[0]<nums[nums.Length-1])
        {   i=0;
            while(nums[i]>nums[i+1] && i < nums.Length-1)
            {
                i++;
            }
         return nums[i];
        }
        else
        {
            i = nums.Length-1;
            while(nums[i]>nums[i-1] && i>1)
            {
                i--;
            }
            return nums[i];
        }
    }
}