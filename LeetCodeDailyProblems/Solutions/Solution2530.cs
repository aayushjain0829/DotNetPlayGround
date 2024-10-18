namespace LeetCodeDailyProblems.Solutions;

internal class Solution2530 : Solution<CustomEnumerable<int>, int, long>
{
    #region Algos
    public long MaxKelements(int[] nums, int k)
    {
        long ans = 0;
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(k, Comparer<int>.Create((x, y) => y - x));
        foreach (int i in nums) priorityQueue.Enqueue(i, i);
        for (int i = 0; i < k; i++)
        {
            int val = priorityQueue.Dequeue();
            ans += val;

            int newVal = (int)Math.Ceiling((double)val / 3);
            priorityQueue.Enqueue(newVal, newVal);
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input1, int input2)
    {
        return MaxKelements(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return new List<(CustomEnumerable<int>, int)>()
        {
            new (new CustomEnumerable<int>([10,10,10,10,10]), 5),
            new (new CustomEnumerable<int>([1,10,3,3,3]), 3)
        };
    }
}
