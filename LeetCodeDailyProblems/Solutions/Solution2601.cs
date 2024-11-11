
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2601 : Solution<CustomEnumerable<int>, bool>
{
    #region Algos
    private bool PrimeSubOperation(int[] nums)
    {
        var IsComposite = new bool[1010];
        IsComposite[0] = IsComposite[1] = true;
        for (int i = 2; i < 32; i++)
        {
            if (IsComposite[i]) continue;
            for (int j = 2*i; j < IsComposite.Length; j+=i)
                IsComposite[j] = true;
        }

        int GetNextPrime(int num)
        {
            while (IsComposite[num]) num++;
            return num;
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1]) continue;
            var diff = GetNextPrime(nums[i] - nums[i + 1] + 1);
            
            if (diff < nums[i]) nums[i] -= diff;
            else return false;
        }

        return true;
    }
    #endregion

    public override bool Execute(CustomEnumerable<int> input)
    {
        return PrimeSubOperation(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new ([4,9,6,10]),
            new ([6,8,11,12]),
            new ([5,8,3]),
            ];
    }
}
