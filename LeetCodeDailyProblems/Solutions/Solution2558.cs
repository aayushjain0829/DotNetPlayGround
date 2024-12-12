
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2558 : Solution<CustomEnumerable<int>, int, long>
{
    #region Algos
    private long PickGifts(int[] gifts, int k)
    {
        long ans = 0;
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach (int gift in gifts)
        {
            pq.Enqueue(gift, -gift);
            ans += gift;
        }

        for (int i = 0; i < k; i++)
        {
            int gift = pq.Dequeue();
            int rem = (int)Math.Floor(Math.Sqrt(gift));

            pq.Enqueue(rem, -rem);
            ans -= (gift - rem);
        }

        return ans;
    }
    #endregion

    public override long Execute(CustomEnumerable<int> input1, int input2)
    {
        return PickGifts(input1.ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<int>, int)> TestCases()
    {
        return [
            (new([25,64,9,4,100]), 4),
            (new([1,1,1,1]), 4)
            ];
    }
}
