namespace LeetCodeDailyProblems.Solutions;

internal class Solution1277 : Solution<CustomEnumerable<CustomEnumerable<int>>, int>
{
    #region Algos
    int CountSquares(int[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length, mxSize = Math.Min(n, m), ans = 0;
        int[][] sum = new int[n+1][];

        sum[0] = new int[m+1];
        for (int i = 1; i <= n; i++)
        {
            sum[i] = new int [m+1];
            for(int j = 1; j <= m; j++)
            {
                sum[i][j] = matrix[i - 1][j-1] + sum[i-1][j] + sum[i][j-1] - sum[i - 1][j-1];
            }
        }

        int GetMatrixSum(int i, int j, int k) => (sum[i+k][j+k] - sum[i][j+k] - sum[i+k][j] + sum[i][j]);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for(int k = 1; k <= mxSize; k++)
                {
                    if (i + k <= n && j + k <= m && GetMatrixSum(i, j, k) == k * k) ans++;
                    else break;
                }
            }
        }

        return ans;
    }
    #endregion

    public override int Execute(CustomEnumerable<CustomEnumerable<int>> input)
    {
        return CountSquares(input.Select(x => x.ToArray()).ToArray());
    }

    public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
    {
        return [
            new ([
                new ([0,1,1,1]),
                new ([1,1,1,1]),
                new ([0,1,1,1])
            ]),
            new ([
                new ([1,0,1]),
                new ([1,1,0]),
                new ([1,1,0])
            ])
        ];
    }
}
