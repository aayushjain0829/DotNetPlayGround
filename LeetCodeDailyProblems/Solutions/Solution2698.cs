
namespace LeetCodeDailyProblems.Solutions
{
    internal class Solution2698 : Solution<int, int>
    {
        #region Algos
        private int PunishmentNumber(int n)
        {
            int ans = 0;

            bool IsPartionSumPossible(int num, int sum)
            {
                if (num < 10) return num == sum;

                int currVal = 0, multiplier = 1;
                while (currVal <= sum && num > 0)
                {
                    if (currVal + num == sum) return true;

                    currVal += (num % 10) * multiplier;
                    num /= 10;
                    multiplier *= 10;

                    if (IsPartionSumPossible(num, sum - currVal)) return true;
                }

                return false;
            }

            for (int i = 1; i <= n; i++)
            {
                if (IsPartionSumPossible(i*i, i))
                    ans += i * i;
            }

            return ans;
        }
        #endregion

        public override int Execute(int input)
        {
            return PunishmentNumber(input);
        }

        public override IEnumerable<int> TestCases()
        {
            return [10, 37, 1000];
        }
    }
}
