
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1574 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int FindLengthOfShortestSubarray(int[] arr)
    {
        int n = arr.Length, prefixEnd = 1, suffixStart = n - 1;

        while (prefixEnd < n)
        {   
            if (arr[prefixEnd] >= arr[prefixEnd - 1]) prefixEnd++;
            else break;
        }

        while (suffixStart > 0)
        {
            if (arr[suffixStart - 1] <= arr[suffixStart]) suffixStart--;
            else break;
        }

        if (prefixEnd > suffixStart) return 0;
        int ans = Math.Min(n - prefixEnd, suffixStart);

        for (int i = 0; i < prefixEnd; i++)
        {
            int l = suffixStart, r = n;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] >= arr[i]) r = mid;
                else l = mid + 1;
            }

            ans = Math.Min(ans, l-i-1);
        }

        return ans;
    }

    private int FindLengthOfShortestSubarrayWithoutBinarySearch(int[] arr)
    {
        int n = arr.Length;
        int prefixEnd = 0;
        int suffixStart = n - 1;

        while (prefixEnd < n - 1 && arr[prefixEnd] <= arr[prefixEnd + 1]) prefixEnd++;
        if (prefixEnd == n - 1) return 0;
        while (suffixStart > 0 && arr[suffixStart - 1] <= arr[suffixStart]) suffixStart--;

        int ans = Math.Min(n - prefixEnd - 1, suffixStart);
        for (int i = 0; i <= prefixEnd; i++)
        {
            if (arr[i] <= arr[suffixStart]) ans = Math.Min(ans, suffixStart - i - 1);
            else if (suffixStart < n - 1) suffixStart++;
        }

        return ans;
    }

    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return FindLengthOfShortestSubarray(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new ([1,2,3,10,4,2,3,5]),
            new ([5,4,3,2,1]),
            new ([1,2,3]),
            new ([16,10,0,3,22,1,14,7,1,12,15])
            ];
    }
}
