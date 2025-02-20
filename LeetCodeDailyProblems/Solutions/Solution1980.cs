
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1980 : Solution<CustomEnumerable<string>, string>
{
    #region Algos
    private string FindDifferentBinaryString(string[] nums)
    {
        int n = nums.Length;
        string ans = "";

        for (int i = 0; i < n; i++) ans += nums[i][i] == '0' ? '1' : '0';

        return ans;
    }
    #endregion

    public override string Execute(CustomEnumerable<string> input)
    {
        return FindDifferentBinaryString(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<string>> TestCases()
    {
        return [
            new(["01","10"]),
            new(["00","01"]),
            new(["111","011","001"])
            ];
    }
}
