internal class RandomB
{
    public static void TaskB()
    {
        long[] keys = Array.ConvertAll(Console.ReadLine()!.Split(' '), long.Parse);
        long n = keys[0];
        long x = keys[1];
        long t = keys[2];
        long[] values = Array.ConvertAll(Console.ReadLine()!.Split(' '), long.Parse);

        List<long> statuesIds = CalculateStatuesAmount(n, x, t, values);
        Console.WriteLine(statuesIds.Count);
        Console.WriteLine(string.Join(" ", statuesIds.ConvertAll(val => val.ToString()).ToArray()));
    }

    static List<long> CalculateStatuesAmount(long n, long targetValue, long time, long[] values)
    {
        var dAmountPerDiff = new SortedDictionary<long, long>();
        var dIdsPerDiff = new SortedDictionary<long, List<long>>();
        var statuesIds = new List<long>();
        var timeLeft = time;

        for (var index = 0; index < values.Length; index++)
        {
            var value = values[index];
            var diff = Math.Abs(targetValue - value);
            if (diff == 0)
            {
                statuesIds.Add(index + 1);
            }
            else
            {
                if (dAmountPerDiff.ContainsKey(diff))
                {
                    dIdsPerDiff[diff].Add(index + 1);
                    dAmountPerDiff[diff] += 1;
                }
                else
                {
                    dIdsPerDiff[diff] = new List<long> { index + 1 };
                    dAmountPerDiff[diff] = 1;
                }
            }
        }

        foreach (var keyValuePair in dAmountPerDiff)
        {
            var canMakeAmount = (long)timeLeft / keyValuePair.Key;
            var needMakeAmount = keyValuePair.Value;
            var makingAmount = Math.Min(canMakeAmount, needMakeAmount);
            timeLeft -= makingAmount * keyValuePair.Key;
            statuesIds.AddRange(dIdsPerDiff[keyValuePair.Key].Take((int)makingAmount));
        }

        return statuesIds;
    }
}