
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2560 : Solution<CustomEnumerable<int>, int, int>
{
    #region Algos
    private int MinCapability(int[] nums, int k)
    {
        int l = 0, r = nums.Length;
        int[] copy = new int[r];
        for (int i=0; i<r; i++) copy[i] = nums[i];
        Array.Sort(copy);

        while (l < r)
        {
            int idx = l + (r - l) / 2, key = copy[idx], count = 0;
            bool prevTaken = false;

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] <= key && !prevTaken)
                {
                    count++;
                    prevTaken = true;
                } else prevTaken = false;
            }

            if (count >= k) r = idx;
            else l = idx + 1;
        }

        return copy[r];
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input1, int input2)
    {
        return MinCapability(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([2,3,5,9]), 2),
            (new([2,7,9,3,1]), 2)
            ];
    }
}
