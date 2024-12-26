
namespace LeetCodeDailyProblems.Solutions;

internal class Solution494 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int FindTargetSumWays(int[] nums, int target)
    {
        int n = nums.Length, ans = 0;
        
        void BackTrack(int idx, int sum)
        {
            if (idx == n)
            {
                ans += (sum == target) ? 1 : 0;
                return;
            }

            BackTrack(idx + 1, sum + nums[idx]);
            BackTrack(idx + 1, sum - nums[idx]);
        } BackTrack(0, 0);

        return ans;
    }

    private int FindTargetSumWaysStack(int[] nums, int target)
    {
        int n = nums.Length, ans = 0;
        var stack = new Stack<(int idx, int sum)>();
        stack.Push((0, 0));

        while (stack.Count > 0)
        {
            var (idx, sum) = stack.Pop();
            if (idx == n)
            {
                if (sum == target) ans++;
                continue;
            }

            stack.Push((idx + 1, sum + nums[idx]));
            stack.Push((idx + 1, sum - nums[idx]));
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return FindTargetSumWays(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([1,1,1,1,1]), 3),
            (new([1]), 1)
            ];
    }
}
