// F. JSON категории (25 баллов)
// На маркетплейсе у каждого товара есть категория. При этом, у некоторых категорий есть дочерние
// категории. Для удобной навигации по маркетплейсу покупатели могут пользоваться деревом категорий.
//
// Ваша задача — построить дерево категорий. Дана информация об отношениях родительских и дочерних
// категорий в виде JSON-массива. Каждый элемент массива является словарем, с полями name (название
// категории), id (числовой идентификатор категории) и parent (числовой идентификатор родительской
// категории). Известно, что корневая категория имеет нулевой идентификатор и не имеет идентификатора
// родительской категории.
// По данной информации постройте дерево категорий в виде JSON-словаря. Словарь для каждой категории
// должен иметь поля name, id и массив next, состоящий из таких же словарей для дочерних категорий.
//
// Входные данные
// Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t
// (1≤t≤100) — количество наборов входных данных. Далее следует описание наборов входных данных.
//
// Первая строка каждого набора входных данных содержит целое число n (1≤n≤1000) — количество строк
// с описанием JSON-массива категорий.
//
// Следующие n строк содержат описание JSON-массива категорий. Все числовые идентификаторы категорий
// являются целыми числами и удовлетворяют условию 0≤id≤10^9. Все имена категорий непустые, состоят
// из строчных латинских букв и имеют длину не больше 20. В описании могут быть символы пробела и табуляции.
//
// Гарантируется, что каждый набор входных данных содержит корневую категорию и не более 400 категорий.
// Гарантируется, что размер входных данных не превосходит 10Мб.
//
// Выходные данные
// Выведите JSON-массив из t элементов. i-й элемент массива является словарем с описанием дерева
// категорий для i-го набора входных данных. При проверке ответа пробелы, табы и переносы строки не
// учитываются(кроме таковых в json полях). Порядок полей в словаре и порядок дочерних категорий в
// массиве next не учитывается. Если у категории нет дочерних категорий, ключ next может отсутствовать,
// или соответствовать пустому массиву.
//
// Тесты:
//
// Тест №1
// Входные данные:
// 2
// 21
// [
//    {
//      "id":0,
//      "name":"all"
//    },
//    {
//       "id":1,
//       "name":"clothes",
//       "parent":0
//    },
//    {
//       "id":2,
//       "name":"shoes",
//       "parent":0
//    },
//    {
//       "id":55,
//       "name":"sneakers",
//       "parent":2
//    }
// ]
// 6
//  [ {"parent":	0,"id":100,  "name":
//  "x"},{
//
// "name":"x","id":0}
//
// ]
//
// Выходные данные:
// [{
// 	"id": 0,
// 	"name": "all",
// 	"next": [{
// 		"id": 1,
// 		"name": "clothes",
// 		"next": []
// 	}, {
// 		"id": 2,
// 		"name": "shoes",
// 		"next": [{
// 			"id": 55,
// 			"name": "sneakers"
// 		}]
// 	}]
// },
// {"name":"x","id":0,"next":[{"id":100,"name":"x"}]}
// ]
//
// Тест №2
// Входные данные:
// 1
// 9
// [
//  {"name": "everything", "id": 0},
//  {"name": "clothes", "id": 1, "parent": 0},
//  {"name": "electronics", "id": 2, "parent": 0},
//  {"name": "computers", "id": 4, "parent": 2},
//  {"name": "aio", "id": 3, "parent": 4},
//  {"name": "tv", "id": 5, "parent": 2},
//  {"name": "house", "id": 6, "parent": 0}
// ]
// Выходные данные:
// [
// {"id":0,"name":"everything","next":[{"id":1,"name":"clothes","next":[]},{"id":2,"name":"electronics","next":[{"id":4,"name":"computers","next":[{"id":3,"name":"aio","next":[]}]},{"id":5,"name":"tv","next":[]}]},{"id":6,"name":"house","next":[]}]}
// ]

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class TaskF
{
    public static void F()
    {
        List<CategoryTree> answers = new List<CategoryTree>();
        int t = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine()!);
            StringBuilder inputDataBuilder = new StringBuilder();

            for (int j = 0; j < n; j++)
            {
                inputDataBuilder.Append(Console.ReadLine());
            }

            Category[] categories = JsonSerializer.Deserialize<Category[]>(inputDataBuilder.ToString())!;

            Dictionary<int, List<Category>> parentToChild = new Dictionary<int, List<Category>>();
            foreach (var category in categories)
            {
                if (category.Parent == null)
                    continue;

                if (!parentToChild.ContainsKey(category.Parent.Value))
                {
                    parentToChild[category.Parent.Value] = new List<Category>();
                }

                parentToChild[category.Parent.Value].Add(category);
            }

            Category rootCategory = FindRootCategory(categories);
            CategoryTree tree = BuildCategoryTree(rootCategory, parentToChild);

            answers.Add(tree);
        }

        Console.Write(JsonSerializer.Serialize(answers, new JsonSerializerOptions
        {
            WriteIndented = false,
            MaxDepth = 10000
        }));
    }

    private static Category FindRootCategory(Category[] categories)
    {
        foreach (var category in categories)
        {
            if (category.Parent == null)
            {
                return category;
            }
        }

        return null;
    }

    private static CategoryTree BuildCategoryTree(
        Category rootCategory, IReadOnlyDictionary<int, List<Category>> parentToChild
    )
    {
        CategoryTree tree = new CategoryTree
        {
            Id = rootCategory.Id,
            Name = rootCategory.Name,
            Next = new List<CategoryTree>()
        };

        Stack<(CategoryTree, int)> stack = new Stack<(CategoryTree, int)>();
        stack.Push((tree, rootCategory.Id));

        while (stack.Count > 0)
        {
            var (currentTree, currentCategoryId) = stack.Pop();
            if (parentToChild.ContainsKey(currentCategoryId))
            {
                foreach (var childCategory in parentToChild[currentCategoryId])
                {
                    CategoryTree childTree = new CategoryTree
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Next = new List<CategoryTree>()
                    };
                    currentTree.Next.Add(childTree);
                    stack.Push((childTree, childCategory.Id));
                }
            }
        }

        return tree;
    }
}

class Category
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("parent")] public int? Parent { get; set; }
}

class CategoryTree
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("next")] public List<CategoryTree> Next { get; set; }
}