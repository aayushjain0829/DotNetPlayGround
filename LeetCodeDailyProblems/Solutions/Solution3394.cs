
namespace LeetCodeDailyProblems.Solutions;

internal class Solution3394 : Solution<int, CustomEnumerable<CustomEnumerable<int>>, bool>
{
    #region Algos
    private bool CheckValidCuts(List<(int s, int e)> cords)
    {
        cords.Sort((a, b) => a.s.CompareTo(b.s));
        int curr = cords[0].e, cut = 1;
        for (int i = 1; i < cords.Count; i++)
        {
            if (cords[i].s >= curr) cut++;
            curr = Math.Max(curr, cords[i].e);
            if (cut == 3) return true;
        }

        return false;
    }

    private bool CheckValidCuts(int n, int[][] rectangles)
    {
        int m = rectangles.Length;
        var hCords = new List<(int, int)>();
        var vCords = new List<(int, int)>();

        foreach (var rectangle in rectangles)
        {
            hCords.Add((rectangle[0], rectangle[2]));
            vCords.Add((rectangle[1], rectangle[3]));
        }

        return CheckValidCuts(hCords) || CheckValidCuts(vCords);
    }
    #endregion

    public override bool Execute(int input1, CustomEnumerable<CustomEnumerable<int>> input2)
    {
        return CheckValidCuts(input1, input2.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(int, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (5, new([new([1,0,5,2]), new([0,2,2,4]), new([3,2,5,3]), new([0,4,4,5])])),
            (4, new([new([0,0,1,1]), new([2,0,3,4]), new([0,2,2,3]), new([3,0,4,3])])),
            (4, new([new([0,2,2,4]), new([1,0,3,2]), new([2,2,3,4]), new([3,0,4,2]), new([3,2,4,4])]))
            ];
    }
}
