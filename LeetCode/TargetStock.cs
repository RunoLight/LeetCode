namespace LeetCode;

class TargetStock
{
// A financial analyst is responsible for a portfolio of profitable stocks represented in an array. Each item in the
// array represents the yearly profit of a corresponding stock. The analyst gathers all distinct pairs of stocks that
// reached the target profit. Distinct pairs are pairs that differ in at least one element. Given the array of profits,
// find the number of distinct pairs of stocks where the sum of each pair's profits is exactly equal to the target profit.

// Example:
// stocksProfit = [5, 7, 9, 13, 11, 6, 6, 3, 3]
// target = 12 profit's target

    public static int stockPairs(List<int> stocksProfit, long target)
    {
        HashSet<int> found = new HashSet<int>();
        HashSet<(int, int)> answers = new HashSet<(int, int)>();

        for (int i = 0; i < stocksProfit.Count; i++)
        {
            var needsAddedToTarget = (int)(target - stocksProfit[i]);
            if (found.Contains(needsAddedToTarget))
            {
                // In order for Set to be working
                var answer = (
                    Math.Min(stocksProfit[i], needsAddedToTarget),
                    Math.Max(stocksProfit[i], needsAddedToTarget)
                );
                answers.Add(answer);
            }

            found.Add(stocksProfit[i]);
        }

        return answers.Count;
    }
}