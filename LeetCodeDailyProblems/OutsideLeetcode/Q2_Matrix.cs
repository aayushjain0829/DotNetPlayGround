using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.OutsideLeetcode
{
    internal class Q2_Matrix : Solution<CustomEnumerable<CustomEnumerable<int>>, CustomEnumerable<CustomEnumerable<int>>>
    {
        private int[][] LocalMaximas(int[][] matrix)
        {
            List<int[]> result = [];
            int n = matrix.Length, m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == 0) continue;

                    int startI = i - matrix[i][j], endI = i + matrix[i][j];
                    int startJ = j - matrix[i][j], endJ = j + matrix[i][j];
                    HashSet<(int,int)> corners = [(startI, startJ), (startI, endJ), (endI, startJ), (endI, endJ), (i, j)];

                    bool isLocalMaxima = !Enumerable.Range(startI, endI - startI + 1)
                                            .Any(k => Enumerable.Range(startJ, endJ - startJ + 1)
                                            .Any(l => k >= 0 && k < n && l >= 0 && l < m && !corners.Contains((k, l)) && matrix[i][j] <= matrix[k][l]));

                    if (isLocalMaxima) 
                        result.Add([i, j]);
                }
            }

            return result.ToArray();
        }

        public override CustomEnumerable<CustomEnumerable<int>> Execute(CustomEnumerable<CustomEnumerable<int>> input)
        {
            return new CustomEnumerable<CustomEnumerable<int>>(LocalMaximas(input.Select(x => x.ToArray()).ToArray()).Select(x => new CustomEnumerable<int>(x)));
        }

        public override IEnumerable<CustomEnumerable<CustomEnumerable<int>>> TestCases()
        {
            return new List<CustomEnumerable<CustomEnumerable<int>>>()
            {
                new CustomEnumerable<CustomEnumerable<int>> ([
                    new CustomEnumerable<int> ([3, 0, 0, 0, 0]),
                    new CustomEnumerable<int> ([0, 0, 1, 0, 0]),
                    new CustomEnumerable<int> ([0, 0, 2, 0, 0]),
                    new CustomEnumerable<int> ([0, 0, 0, 0, 0]),
                    new CustomEnumerable<int> ([0, 0, 0, 0, 0]),
                    new CustomEnumerable<int> ([0, 3, 0, 0, 3]),
                    ]),
            };
        }
    }
}
