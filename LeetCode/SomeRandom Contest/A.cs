internal class RandomA
{
    public static void TaskA()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] keys = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
        int[] rows = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
        int k = int.Parse(Console.ReadLine()!);
        int[] text = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);

        int disorderCount = CalculateDisorder(n, keys, rows, k, text);
        Console.WriteLine(disorderCount);
    }

    static int CalculateDisorder(int n, int[] keys, int[] rows, int k, int[] text)
    {
        Dictionary<int, int> keyToRow = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int key = keys[i];
            int row = rows[i];
            keyToRow[key] = row;
        }

        int disorderCount = 0;
        int currentRow = keyToRow[text[0]];

        for (int i = 1; i < k; i++)
        {
            int prevKey = text[i - 1];
            int currentKey = text[i];

            if (keyToRow[currentKey] != currentRow)
            {
                if (keyToRow[currentKey] != keyToRow[prevKey])
                {
                    disorderCount++;
                }

                currentRow = keyToRow[currentKey];
            }
        }

        return disorderCount;
    }
}