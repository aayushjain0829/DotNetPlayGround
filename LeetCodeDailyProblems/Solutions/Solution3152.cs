
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3152 : Solution<CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<bool>>
{
    #region Algos
    private bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        List<int> parities = new List<int>();
        for (int i = 0; i < nums.Length - 1; i++)
            if (nums[i] % 2 == nums[i + 1] % 2)
                parities.Add(i);

        int n = queries.Length;
        bool[] result = new bool[n];

        for (int i = 0; i < n; i++)
        {
            int l = 0, r = parities.Count;
            bool valid = true;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (parities[mid] >= queries[i][0] && parities[mid] < queries[i][1])
                {
                    valid = false;
                    break;
                }
                else if (parities[mid] < queries[i][0]) l = mid + 1;
                else r = mid;
            }

            result[i] = valid;
        }

        return result;
    }

    private bool[] IsArraySpecialSplifiedBinarySearch(int[] nums, int[][] queries)
    {
        var result = new bool[queries.Length];
        var parities = new List<int>();

        for (int i = 0; i < nums.Length - 1; i++)
            if (nums[i] % 2 == nums[i + 1] % 2)
                parities.Add(i);


        for (int i = 0; i < queries.Length; i++)
        {
            int idx = parities.BinarySearch(queries[i][0]);
            if (idx < 0) idx = ~idx;

            result[i] = !(idx < parities.Count && parities[idx] <= queries[i][1]-1);
        }

        return result;
    }

    private bool[] IsArraySpecialHash(int[] nums, int[][] queries)
    {
        var paritySum = new int[nums.Length];
        for (int i = 1; i < nums.Length; i++)
            paritySum[i] = paritySum[i - 1] + ((nums[i - 1] & 1) ^ (nums[i] & 1));

        var result = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
            result[i] = paritySum[queries[i][1]] - paritySum[queries[i][0]] == queries[i][1] - queries[i][0];

        return result;
    }
    #endregion

    public override CustomEnumerable<bool> Execute(CustomEnumerable<int> input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return new(IsArraySpecialHash(input1.ToArray(), input2.Select(x => x.ToArray()).ToArray()));
    }

    public override IEnumerable<(CustomEnumerable<int>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (new([3,4,1,2,6]), new([new([0,4])])),
            (new([4,3,1,6]), new([new([0,2]), new([2,3])])),
            (new([1,1]), new([new([0,1])])),
            (new([3,6,2,1]), new([new([0,1])]))
            ];
    }
}
