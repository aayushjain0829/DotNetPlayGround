
namespace LeetCodeDailyProblems.Solutions;

internal class Solution862 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int ShortestSubarray(int[] nums, int k)
    {
        int res = int.MaxValue;
        long curSum = 0;
        var q = new LinkedList<(long sum, int index)>();

        for (int r = 0; r < nums.Length; r++)
        {
            curSum += nums[r];
            if (curSum >= k)
            {
                res = Math.Min(res, r + 1);
            }

            // Find the minimum valid window ending at r
            while (q.Count > 0 && curSum - q.First!.Value.sum >= k)
            {
                var (prefix, endIdx) = q.First.Value;
                q.RemoveFirst();
                res = Math.Min(res, r - endIdx);
            }

            // Validate the monotonic deque
            while (q.Count > 0 && q.Last!.Value.sum > curSum)
            {
                q.RemoveLast();
            }
            q.AddLast((curSum, r));
        }

        return res == int.MaxValue ? -1 : res;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return ShortestSubarray(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1]), 1),
            (new([1,2]), 4),
            (new([2,-1,2]), 3),
            ];
    }
}
