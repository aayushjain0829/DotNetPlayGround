
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2342 : Solution<CustomEnumerable<int>, int>
{
    #region Algos
    private int MaximumSum(int[] nums)
    {
        int ans = -1;
        var dict = new Dictionary<int, PriorityQueue<int, int>>();
        
        int GetSum(int x)
        {
            int sum = 0;
            while (x != 0)
            {
                sum += x % 10;
                x /= 10;
            }

            return sum;
        }

        foreach (var item in nums)
        {
            int sum = GetSum(item);

            if (!dict.ContainsKey(sum)) dict[sum] = new PriorityQueue<int, int>();
            dict[sum].Enqueue(item, item);
            if (dict[sum].Count > 2) dict[sum].Dequeue();
        }

        foreach (var (_, pq) in dict)
        {
            if (pq.Count == 2) ans = Math.Max(ans, pq.Dequeue() + pq.Dequeue());
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<int> input)
    {
        return MaximumSum(input.ToArray());
    }

    public override IEnumerable<CustomEnumerable<int>> TestCases()
    {
        return [
            new([18,43,36,13,7]),
            new([10,12,19,14])
            ];
    }
}
