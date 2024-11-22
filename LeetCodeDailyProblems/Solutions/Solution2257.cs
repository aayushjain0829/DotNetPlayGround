
namespace LeetCodeDailyProblems.Solutions;

internal class Solution2257 : Solution<int, int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    private int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        int count = 0;
        var grid = new int[m, n];

        // Initialize the grid with guards and walls
        foreach (var guard in guards) grid[guard[0], guard[1]] = 1;
        foreach (var wall in walls) grid[wall[0], wall[1]] = 2;

        // Mark cells under guard's control horizontally
        for (int i = 0; i < m; i++)
        {
            int guardPos = -1;
            for (int j = 0; j < n; j++)
            {
                if (grid[i, j] == 1) guardPos = j;
                if (grid[i, j] == 2) guardPos = -1;
                if (guardPos != -1 && grid[i, j] == 0) grid[i, j] = -1;
            }

            guardPos = -1;
            for (int j = n - 1; j >= 0; j--)
            {
                if (grid[i, j] == 1) guardPos = j;
                if (grid[i, j] == 2) guardPos = -1;
                if (guardPos != -1 && grid[i, j] == 0) grid[i, j] = -1;
            }
        }

        // Mark cells under guard's control vertically
        for (int j = 0; j < n; j++)
        {
            int guardPos = -1;
            for (int i = 0; i < m; i++)
            {
                if (grid[i, j] == 1) guardPos = i;
                if (grid[i, j] == 2) guardPos = -1;
                if (guardPos != -1 && grid[i, j] == 0) grid[i, j] = -1;
            }

            guardPos = -1;
            for (int i = m - 1; i >= 0; i--)
            {
                if (grid[i, j] == 1) guardPos = i;
                if (grid[i, j] == 2) guardPos = -1;
                if (guardPos != -1 && grid[i, j] == 0) grid[i, j] = -1;
            }
        }

        // Count unguarded cells
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i, j] == 0) count++;
            }
        }

        return count;
    }

    #endregion

    public override int Execute(int input1, int input2, CustomEnumerable<CustomEnumerable<int>> input3, CustomEnumerable<CustomEnumerable<int>> input4)
    {
        return CountUnguarded(input1, input2, input3.Select(x => x.ToArray()).ToArray(), input4.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<(int, int, CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>)> TestCases()
    {
        return [
            (4, 6,new([new([0,0]),new([1,1]),new([2,3])]), new([new([0,1]), new([2,2]), new([1,4])])),
            (3, 3, new([new([1,1])]), new([new([0,1]),new([1,0]), new([2,1]), new([1,2])]))
            ];
    }
}
