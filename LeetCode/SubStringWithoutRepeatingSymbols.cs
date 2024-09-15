namespace LeetCode;

/*
Даны два отсортированных списка с интервалами присутствия
пользователей в онлайне в течение дня. Начало интервала строго меньше конца.
Нужно вычислить интервалы, когда оба пользователя были в онлайне.


    intersection(
    [(8, 12), (17, 22)],
    [(5, 11), (14, 18), (20, 23)]
    ); // [(8, 11), (17, 18), (20, 22)]

    [(8, 10)],
    [(14, 15), (16, 18), (20, 23)]

    [(8, 9)],
    [(7, 7), (16, 18), (20, 23)]

    [(10, 17)],
    [(10, 14), (14, 17)]

    intersection(
    [(9, 15), (18, 21)],
    [(10, 14), (21, 22)]
    ); // [(10, 14)]


    [(8, 15)],
    [(14, 15), (16, 18), (20, 23)]

    [(8, 15), (16, 19)],
    [(14, 15), (16, 18), (20, 23)]
*/

// Not ended

public class SubStringWithoutRepeatingSymbols
{
    List<(int, int)> Intersection(List<(int, int)> user1, List<(int, int)> user2)
    {
        List<(int, int)> result = new();
        int i = 0, j = 0;
        int startmax = 0;
        (int, int) el1, el2;
    
        while (i != user1.Count && j != user2.Count)
        {
            el1 = user1[i];
            el2 = user2[j];

            int startMax = Math.Max(el1.Item1, el2.Item1);
            int endMin = Math.Min(el1.Item2, el2.Item2);

            if (startmax < endMin)
            {
                result.Add((startMax, endMin));
            }

            if (el1.Item2 < el2.Item2)
            {
                i++;
            }
            else if (el1.Item2 > el2.Item2)
            {
                j++;
            }
            else
            {
                i++;
                j++;
            }
        }

        return result;
    }
}


