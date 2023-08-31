// B. Наклейки (10 баллов)
//
// Для отслеживания посылок компания NOZO использует наклейки с надписями. Иногда надпись (или её часть)
// на наклейке нужно исправить, и тогда поверх старой наклейки лепят новую.
// На очередной посылке появилось слишком много наклеек и теперь невозможно прочитать наклеенную надпись
// целиком.
// Помогите это сделать по истории этих наклеек.
//
// Входные данные
// Первая строка s представляет собой содержимое изначальной наклейки. Гарантируется, что её длина не
// превышает 1000 символов.
//
// Во второй строке записано целое число n (1≤n≤1000 ), обозначающее количество наклеенных поверх наклеек.
//
// Далее идёт n строк, каждая из которых описывает очередную наклейку в порядке её применения: от самой
// старой к самой новой. Каждое описание содержит два числа starti и endi (1≤start≤end≤|s| , где |s|
// обозначает длину строки s) и через пробел строку ri, которая была записана поверх символов между starti
// и endi. Гарантируется, что длина строки ri точно равна end−start+1. Эта запись обозначает, что поверх
// всех символов, начиная с символа под номером start и заканчивая символом под номером end , была
// наклеена строка ri.
// Гарантируется, что все строки состоят только из строчных латинских букв.
//
// Выходные данные
// Выведите итоговую строку, которая видна после применения всех наклеек.

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System.Text;
using static Int32;

public static class TaskB
{
    public static void B()
    {
        var s = new StringBuilder(Console.ReadLine()!);
        var n = Convert.ToInt32(Console.ReadLine());
        var d = new Dictionary<int, char>();
        for (var i = 0; i < n; i++)
        {
            var inputString = Console.ReadLine()?.Split(' ');
            int startId = -1;
            int endId = -1;
            var chars = Array.Empty<char>();
            if (inputString != null)
            {
                TryParse(inputString[0], out startId);
                TryParse(inputString[1], out endId);
                chars = inputString[2].ToCharArray();
            }

            if (startId == endId)
            {
                d[startId] = chars[0];
            }
            else
            {
                for (var z = startId; z <= endId; z++)
                    d[z] = chars[z - startId];
            }
        }

        foreach (var chr in d)
        {
            s[chr.Key - 1] = chr.Value;
        }

        Console.WriteLine(s);
    }
}