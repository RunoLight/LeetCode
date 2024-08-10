static void GenerateStrings(string current, int length, char[] alphabet, ref int countFlowing, ref int countReceding, ref int countTurbulent)
{
    if (length == 0)
    {
        bool isFlowing = true;
        bool isReceding = true;

        for (int i = 1; i < current.Length; i++)
        {
            if (current[i] < current[i - 1])
            {
                isFlowing = false;
            }

            if (current[i] > current[i - 1])
            {
                isReceding = false;
            }
        }

        if (isFlowing)
        {
            countFlowing++;
            Console.WriteLine($"{current} is flowing");
        }
        else if (isReceding)
        {
            countReceding++;
            Console.WriteLine($"{current} is receding");
        }
        else
        {
            countTurbulent++;
            Console.WriteLine($"{current} is turbulent");
        }
    }
    else
    {
        foreach (char c in alphabet)
        {
            GenerateStrings(current + c, length - 1, alphabet, ref countFlowing, ref countReceding, ref countTurbulent);
        }
    }
}