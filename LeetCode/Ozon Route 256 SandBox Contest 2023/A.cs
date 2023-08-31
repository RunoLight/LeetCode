// A. Сумматор (5 баллов)
// Входные данные
// В первой строке входных данных содержится целое число t(1≤t≤10^4) — количество наборов входных
// данных в тесте.
//     
// Далее следуют описания t наборов входных данных, один набор в строке.
// В первой (и единственной) строке набора записаны два целых числа a и b (−1000≤a,b≤1000).
//  
// Выходные данные
// Для каждого набора входных данных выведите сумму двух заданных чисел, то есть a+b.

namespace LeetCode.Ozon_Route_256_SandBox_Contest_2023;

internal class TaskA
{
    public static void A()
    {
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < n; i++)
        {
            var split = Console.ReadLine()!.Split(' ');
            Console.WriteLine(int.Parse(split[0]) + int.Parse(split[1]));
        }
    }
}