
namespace LeetCodeDailyProblems.Solutions;

internal class Solution1792 : Solution<CustomEnumerable<CustomEnumerable<int>>, int, double>
{
    #region Algos
    private double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var pq = new PriorityQueue<(int pass, int total), double>();

        foreach (var c in classes)
            pq.Enqueue((c[0], c[1]), -IncrementalGain(c[0], c[1]));

        for (int i = 0; i < extraStudents; i++)
        {
            var (pass, total) = pq.Dequeue();
            pq.Enqueue((pass + 1, total + 1), -IncrementalGain(pass + 1, total + 1));
        }

        double totalAverage = 0;
        while (pq.Count > 0)
        {
            var (pass, total) = pq.Dequeue();
            totalAverage += (double)pass / total;
        }

        return totalAverage / classes.Length;
    }

    private double IncrementalGain(int pass, int total)
    {
        return ((double)(pass + 1) / (total + 1)) - ((double)pass / total);
    }
    #endregion

    public override double Execute(CustomEnumerable<CustomEnumerable<int>> input1, int input2)
    {
        return MaxAverageRatio(input1.Select(x => x.ToArray()).ToArray(), input2);
    }

    public override IEnumerable<(CustomEnumerable<CustomEnumerable<int>>, int)> TestCases()
    {
        return [
            (new([new([1,2]), new([3,5]), new([2,2])]), 2),
            (new([new([2,4]), new([3,9]), new([4,5]), new([2,10])]), 4),
            (new([new([511,910]), new([289,691]), new([4,279]), new([87,843]), new([415,788])]), 61437)
            ];
    }
}
