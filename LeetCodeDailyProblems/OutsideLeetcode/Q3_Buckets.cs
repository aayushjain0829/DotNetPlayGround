using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyProblems.OutsideLeetcode
{
    internal class Q3_Buckets : Solution<CustomEnumerable<string>, string>
    {
        private string MaxBucket(List<string> commands)
        {
            int maxCount = 0;
            string currentBucket = "", maxbucket = "";
            Dictionary<string, HashSet<string>> buckets = new Dictionary<string, HashSet<string>>();
            foreach (var command in commands)
            {
                if (command.StartsWith('g')) currentBucket = command.Substring(5);
                else
                {
                    if (!buckets.ContainsKey(currentBucket)) buckets.Add(currentBucket, new HashSet<string>());

                    buckets[currentBucket].Add(command.Substring(7));
                    if (buckets[currentBucket].Count > maxCount)
                    {
                        maxCount = buckets[currentBucket].Count;
                        maxbucket = currentBucket;
                    }
                }
            }

            return maxbucket;
        }

        public override string Execute(CustomEnumerable<string> input)
        {
            return MaxBucket(input.ToList());
        }

        public override IEnumerable<CustomEnumerable<string>> TestCases()
        {
            return new List<CustomEnumerable<string>>()
            {
                new CustomEnumerable<string> ([
                    "goto bucketA",
                    "create fileA",
                    "create fileB",
                    "goto bucketB",
                    "goto bucketC",
                    "create fileA",
                    "create fileB",
                    "create fileC"
                    ])
            };
        }
    }
}
