// В офисе стоит кондиционер, на котором можно установить температуру от 15 до 30 градусов.
//
// В офис по очереди приходят n сотрудников. i-й из них желает температуру не больше или не меньше ai.
// После прихода каждого сотрудника определите, можно ли выставить температуру, которая удовлетворит
// всех в офисе.
//
// Входные данные
// Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t (1≤t≤10^3) — количество наборов входных данных. Далее следует описание наборов входных данных.
// Первая строка каждого набора содержит целое число n (1≤n≤10^3) — количество сотрудников.
// i-я из следующих n строк каждого набора входных данных содержит требование к температуре от i-го
// сотрудника: либо ≥ai, либо ≤ai (15≤ai≤30, ai — целое число). Требование ≥ai означает, что i-й
// сотрудник желает температуру не ниже ai; требование ≤ai означает, что i-й сотрудник желает температуру
// не выше ai.
//
// Гарантируется, что сумма n по всем наборам входных данных не превосходит 103.
//
// Выходные данные
// Для каждого набора входных данных выведите n строк, i-я из которых содержит температуру,
// удовлетворяющую всех сотрудников с номерами от 1 до i включительно. Если такой температуры не
// существует, выведите −1. После вывода ответа на очередной набор входных данных выводите пустую строку.
//
// Если ответов несколько, выведите любой.

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System;
using System.Text;

public static class TaskC
{
    public static void C()
    {
        StringBuilder answerStringBuilder = new StringBuilder();
        int t = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine()!);
            string[] requirements = new string[n];

            for (int j = 0; j < n; j++)
            {
                requirements[j] = Console.ReadLine()!;
            }

            int minTemp = 15;
            int maxTemp = 30;
            int[] temperatures = new int[n];

            for (int j = 0; j < n; j++)
            {
                int targetTemp = int.Parse(requirements[j].Substring(3));
                if (requirements[j][0] == '<')
                {
                    maxTemp = Math.Min(maxTemp, targetTemp);
                }
                else
                {
                    minTemp = Math.Max(minTemp, targetTemp);
                }

                if (minTemp > maxTemp)
                {
                    temperatures[j] = -1;
                }
                else
                {
                    temperatures[j] = minTemp;
                }
            }

            for (int j = 0; j < n; j++)
            {
                answerStringBuilder.AppendLine(temperatures[j].ToString());
            }

            if (i < t - 1)
                answerStringBuilder.AppendLine(); // Пустая строка между наборами данных
        }

        Console.Write(answerStringBuilder.ToString());
    }
}