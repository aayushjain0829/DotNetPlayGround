
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1346 : Solution<CustomEnumerable<int>, bool>
{
    #region Algos
    private bool CheckIfExist(int[] arr)
    {
        var exist = new HashSet<int>();
        foreach (var item in arr)
        {
            if (exist.Contains(item * 2)) return true;
            if (item % 2 == 0 && exist.Contains(item / 2)) return true;
            exist.Add(item);
        }

        return false;
    }
    #endregion

    public override bool Execute(CustomEnumerable<int> input)
    {
        return CheckIfExist(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([10,2,5,3]),
            new([3,1,7,11])
            ];
    }
}
