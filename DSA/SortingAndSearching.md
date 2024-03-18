# Sorting and Searching

## Remove Duplicates from Sorted Array [257](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/257/)

```C#
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int insertIndex = 1;

        for(int i=1; i<nums.Length; i++)
        {
            if(nums[i-1]!= nums[i])
            {
                nums[insertIndex] = nums[i];
                insertIndex++;
            }
        }
        return insertIndex;
    }
}
```

## Merge Sorted Array [258](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/258/)

```C#
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int p1 = m - 1;
        int p2 = n - 1;

        for(int p = m + n - 1; p >= 0; p--)
        {
            if(p2 < 0)
                break;

            if(p1 >= 0 && nums1[p1] > nums2[p2])
            {
                nums1[p] = nums1[p1--];
            }
            else
            {
                nums1[p] = nums2[p2--];
            }
        }
    }
}
```

> O(N+M), O(1)

[Solution](https://leetcode.com/problems/merge-sorted-array/editorial/)

- [ ] Sort Colors [text](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/193/)

## Find Minimum in Rotated Sorted Array [206](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/206/)

```C#
public class Solution {
    public int FindMin(int[] nums) {
        int left=0, right=nums.Length-1, mid=0;
        while(left < right)
        {
            mid = (left + right) /2;
            if(nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return nums[left];
    }
}
```

## Find Minimum in Rotated Sorted Array II [207](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/207/)

```C#
public class Solution {
    public int FindMin(int[] nums) {
        int left=0, right=nums.Length-1;
        while(left < right)
        {
            int mid = left + (right-left) /2;
            if(nums[mid] < nums[right])
            {
                right = mid;
            }
            else if(nums[mid]>nums[right])
            {
                left = mid+1;
            }
            else{
                right--;
            }
        }
        return nums[left];
    }
}
```

- [ ] Search in Rotated Sorted Array [191](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/191/)
- [ ]  Search a 2D Matrix [154](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/154/)
- [ ]  Search a 2D Matrix II [195](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/195/)
- [ ]  Median of Two Sorted Arrays [890](https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/890/)

