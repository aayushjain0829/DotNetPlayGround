
namespace LeetCodeDailyProblems.Solutions;

internal class Solution769 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int MaxChunksToSorted(int[] arr)
    {
        int n = arr.Length, j=0, ans = 0;
        int[] copy = new int[n];
        var dict = new Dictionary<int, bool>();

        for (int i = 0; i < n; i++)
        {
            copy[i] = arr[i];
            dict[arr[i]] = false;
        }

        Array.Sort(copy);

        for (int i = 0; i < n; i++)
        {
            dict[arr[i]] = true;
            while (j < n && dict[copy[j]]) j++;
            if (j == i + 1) ans++;
        }

        return ans;
    }

    private int MaxChunksToSortedSimpleSum(int[] arr)
    {
        int n = arr.Length, ans = 0, sum = 0;
        for (int i = 0; i<n; i++)
        {
            sum += arr[i];
            if (sum == (i*(i+1))/2) ans++;
        }

        return ans;
    }

    private int MaxChunksToSortedSimpleMax(int[] arr)
    {
        int n = arr.Length, ans = 0, mx = 0;
        for (int i = 0; i < n; i++)
        {
            mx = Math.Max(mx, arr[i]);
            if (mx == i) ans++;
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return MaxChunksToSortedSimpleMax(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([4,3,2,1,0]),
            new([1,0,2,3,4])
            ];
    }
}
