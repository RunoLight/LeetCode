// B. Сумма к оплате (10 баллов)
//
// В магазине акция: 
// «купи три одинаковых товара и заплати только за два». Конечно, каждый купленный товар может
// участвовать лишь в одной акции. Акцию можно использовать многократно.
// Например, если будут куплены 7 товаров одного вида по цене 2 за штуку и 5 товаров другого вида
// по цене 3 за штуку, то вместо 7⋅2+5⋅3надо будет оплатить 5⋅2+4⋅3=22.
//
// Считая, что одинаковые цены имеют только одинаковые товары, найдите сумму к оплате.
// Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.
//
// Входные данные:
// В первой строке записано целое число t(1≤t≤10^4) — количество наборов входных данных.
// Далее записаны наборы входных данных. Каждый начинается строкой, которая содержит n (1≤n≤2⋅10^5) —
// количество купленных товаров. Следующая строка содержит их цены p1,p2,…,pn (1≤pi≤10^4).
// Если цены двух товаров одинаковые, то надо считать, что это один и тот товар.
// Гарантируется, что сумма значений n по всем тестам не превосходит 2⋅10^5.
//
// Выходные данные: 
// Выведите t целых чисел — суммы к оплате для каждого из наборов входных данных.

namespace LeetCode.Ozon_Route_256_SandBox_Contest_2023;

using System;
using System.Collections.Generic;
using System.Linq;

internal class TaskB
{
    public static void B()
    {
        List<int> answers = new List<int>();
        int testsAmount = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < testsAmount; i++)
        {
            int itemsBought = int.Parse(Console.ReadLine()!);

            var pricesStrings = Console.ReadLine()!.Split(' ');
            var prices = Array.ConvertAll(pricesStrings, int.Parse);

            // Price to Amount
            Dictionary<int, int> shoppingCart = new Dictionary<int, int>();
            foreach (var price in prices)
            {
                shoppingCart.TryAdd(price, 0);
                shoppingCart[price] += 1;
            }

            int totalCost = 0;
            var keys = shoppingCart.Keys.ToList();
            foreach (var price in keys)
            {
                var freeItems = shoppingCart[price] / 3;
                shoppingCart[price] -= freeItems;
                totalCost += price * shoppingCart[price];
            }

            answers.Add(totalCost);
        }

        foreach (int answer in answers)
        {
            Console.WriteLine(answer);
        }
    }
}