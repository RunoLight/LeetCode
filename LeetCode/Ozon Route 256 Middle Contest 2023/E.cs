// E. Карточки (20 баллов)
//
// Среди ваших n друзей стало популярно коллекционирование редчайших карточек. Производитель выпустил m
// различных видов карточек, пронумерованных от 1 до m . Эти карточки настолько редкие, что их продает
// только один человек. Известно, что у него осталось всего m карточек, по одной каждого вида.
//
// Вам известно, что у i-го из ваших друзей есть все карточки с номерами от 1 до ai включительно. Вы
// хотите сделать подарок всем своим друзьям, подарив i-му из них карточку bi, которой у него еще нет,
// то есть такую, что bi>ai.
//
// Входные данные
// Первая строка содержит два целых числа n и m (1≤n,m≤10^5) — количество друзей и количество карточек.
//
// Вторая строка содержит n целых чисел ai (1≤ai≤m).
//
// Решения, работающие правильно при n,m≤100, получат 10 баллов.
//
// Выходные данные
// Выведите массив bi или −1 , если ответа не существует. Если ответов несколько, выведите любой.

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System.Text;

public static class TaskE
{
    public static void E()
    {
        var inp = Console.ReadLine()!.Split(' ');
        var answer = new StringBuilder();

        var targetRedirect = new Dictionary<int, int>();
        var dirtyNodes = new Stack<int>();

        if (int.TryParse(inp[0], out var friendsAmount) == false)
            friendsAmount = -1;
        if (int.TryParse(inp[1], out var cardsAmount) == false)
            cardsAmount = -1;

        inp = Console.ReadLine()!.Split(' ');

        for (var i = 0; i < friendsAmount; i++)
        {
            var cardIndex = int.Parse(inp[i]);
            var tempIndex = cardIndex + 1;
            do
            {
                if (targetRedirect.TryGetValue(tempIndex, out var nextIndex))
                {
                    tempIndex = nextIndex;
                    dirtyNodes.Push(tempIndex);
                }
                else
                {
                    dirtyNodes.Push(tempIndex);
                    break;
                }
            } while (targetRedirect.ContainsKey(tempIndex));

            if (tempIndex > cardsAmount)
            {
                Console.WriteLine("-1");
                return;
            }

            foreach (var node in dirtyNodes)
            {
                if (targetRedirect.ContainsKey(node))
                {
                    targetRedirect[node] = tempIndex;
                }
                else
                {
                    targetRedirect.Add(tempIndex, tempIndex + 1);
                }
            }

            answer.Append(tempIndex).Append(' ');
            dirtyNodes.Clear();
        }

        answer.Remove(answer.Length - 1, 1);
        Console.WriteLine(answer);
    }
}