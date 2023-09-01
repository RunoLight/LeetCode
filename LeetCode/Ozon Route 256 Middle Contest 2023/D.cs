// Назовём рельефом гор 2D-изображение из n строк и m столбцов, состоящее только из символов 'X', '.'
// (точка), '/' (прямой слеш) и '\' (обратный слеш). Изображение составлено по следующим формальным
// правилам:
//
// либо непосредственно слева снизу от символа '/' находится такой же символ, либо непосредственно слева
// от символа '/' находится символ '\', либо символ '/' находится на нижней строке; либо непосредственно
// справа сверху от символа '/' находится такой же символ, либо непосредственно справа от символа '/'
// находится символ '\'; либо непосредственно слева сверху от символа '\' находится такой же символ, либо
// непосредственно слева от символа '\' находится символ '/'; либо непосредственно справа снизу от
// символа '\' находится такой же символ, либо непосредственно справа от символа '\' находится символ
// '/', либо символ '\' находится на нижней строке; каждый столбец содержит не более одного из символов
// '/' и '\'; в каждом столбце все символы ниже '/' и '\' равны 'X'; все остальные символы равны '.'.
// Все символы, кроме '.', являются частью горы.
//
// В каждом рельефе гор есть хотя бы один символ, не равный '.'.
// Дано k рельефов по их близости к наблюдателю: от ближних к дальним. Выведите рельеф, видный наблюдателю. Если в некотором рельефе символ в x-й строке и y-м столбце является частью горы, то во всех более дальних от наблюдателя рельефах гор символы на этой позиции не видны наблюдателю.
//
// Входные данные
// Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t
// (1≤t≤20) — количество наборов входных данных. Далее следует описание наборов входных данных.
// Первая строка каждого набора содержит три целых числа k, n и m (1≤k,n≤20, 2≤m≤20) — количество
// рельефов, высоту и ширину ASCII-арта.
//
// Далее следуют описания k рельефов гор.
// Описание рельефа гор состоит из n строк, по m символов в каждой — сам ASCII-арт.
// Описания рельефов разделены пустой строкой.
//
// Выходные данные
// Для каждого набора входных данных выведите в n строках рельеф гор, видный наблюдателю.
// После ответа на каждый набор входных данных выведите пустую строку.

// Input:
// 3
// 2 6 18
// ..................
// ..................
// .../\.............
// ../XX\/\../\......
// ./XXXXXX\/XX\.....
// /XXXXXXXXXXXX\....
//
// ........../\......
// ........./XX\.....
// ......../XXXX\....
// .../\../XXXXXX\...
// ../XX\/XXXXXXXX\..
// ./XXXXXXXXXXXXXX\.
// 1 2 2
// ..
// /\
// 3 4 5
// .....
// .....
// .....
// ./\..
//
// .....
// .....
// ./\..
// /XX\.
//
// .....
// .....
// ../\.
// ./XX\

// Output:     
// ........../\......
// ........./XX\.....
// .../\.../XXXX\....
// ../XX\/\XX/\XX\...
// ./XXXXXX\/XX\XX\..
// /XXXXXXXXXXXX\XX\.
//
// ..
// /\
//
// .....
// .....
// ./\\.
// //\\\

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System;
using System.Text;

public class UnityEngine
{
    public string ThreeDRenderOrthographicCamera(char[][][] mountains, int n, int m, int k)
    {
        StringBuilder answerStringBuilder = new StringBuilder();

        char[][] visibleMountain = new char[n][];
        for (int h = 0; h < n; h++)
        {
            visibleMountain[h] = new char[m];
            for (int w = 0; w < m; w++)
            {
                visibleMountain[h][w] = '.'; // Изначально все видимые символы - точки
            }
        }

        for (int j = k - 1; j >= 0; j--)
        {
            for (int h = 0; h < n; h++)
            {
                for (int w = 0; w < m; w++)
                {
                    if (mountains[j][h][w] != '.')
                    {
                        visibleMountain[h][w] = mountains[j][h][w];
                    }
                }
            }
        }

        for (int h = 0; h < n; h++)
        {
            answerStringBuilder.AppendLine(new string(visibleMountain[h]));
        }

        return answerStringBuilder.ToString();
    }
}

public static class TaskD
{
    public static void D()
    {
        UnityEngine unityEngine = new UnityEngine();
        StringBuilder answerStringBuilder = new StringBuilder();

        int t = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            int m = int.Parse(input[2]);

            char[][][] mountains = new char[k][][];
            for (int j = 0; j < k; j++)
            {
                mountains[j] = new char[n][];
                for (int h = 0; h < n; h++)
                {
                    mountains[j][h] = Console.ReadLine()!.ToCharArray();
                }

                if (j != k - 1)
                {
                    string emptyLine = Console.ReadLine()!; // Пропускаем пустую строку
                }
            }

            string result = unityEngine.ThreeDRenderOrthographicCamera(mountains, n, m, k);
            answerStringBuilder.Append(result);

            if (i < t - 1)
            {
                answerStringBuilder.AppendLine(); // Пустая строка между наборами данных
            }
        }

        Console.Write(answerStringBuilder.ToString());
    }
}