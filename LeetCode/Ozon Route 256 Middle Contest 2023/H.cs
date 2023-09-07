﻿// Дан черный список IP адресов. Все IP адреса принадлежат подсети 100.200.0.0/16, то есть имеют вид 100.200.X.Y для некоторых 0≤X,Y<256.
//
// Вам нужно запретить доступ ко всем адресам из черного списка. Для этого можно создать фильтрующий файл. Каждая запись в файле имеет вид:
//
// * 100.200.0.0/16 — эта запись запрещает доступ к подсети из 65536 адресов, то есть ко всем адресам, которые имеют вид 100.200.X.Y для некоторых 0≤X,Y<256;
// * 100.200.X.0/24 (0≤X<256) — эта запись запрещает доступ к подсети из 256 адресов, то есть ко всем адресам, которые имеют вид 100.200.X.Y для некоторого 0≤Y<256;
// * 100.200.X.Y (0≤X,Y<256) — эта запись запрещает доступ к указанному IP адресу.
//
// Из-за технических ограничений в файле не может быть больше, чем k записей. Вам нужно составить фильтрующий файл так, чтобы доступ ко всем IP адресам из черного списка был запрещен. При этом, количество запрещенных IP адресов не из черного списка должно быть минимально.
//
// Входные данные:
// Первая строка содержит два целых числа n и k (1≤n,k≤65536) — размер черного списка IP адресов и максимальное количество записей в фильтрующем файле.
// Следующие n cтрок содержат по одному IP адресу из черного списка в формате 100.200.X.Y, 0≤X,Y<256.
//
// Выходные данные:
// В первой строке выведите минимально возможное количество запрещенных IP адресов не из черного списка.
// Во второй строке выведите количество использованных записей в файле m (1≤m≤k).
// В следующих m строках выведите сами записи.
// Если ответов несколько, выведите любой.
//
// Тесты:
// Тест №1
// Входные данные:
// 4 2
// 100.200.1.1
// 100.200.1.2
// 100.200.1.100
// 100.200.100.5
//
// Выходные данные:
// 253
// 2
// 100.200.1.0/24
// 100.200.100.5
//
//
// Тест №2
// Входные данные:
// 2 1
// 100.200.3.4
// 100.200.5.6
//
// Выходные данные:
// 65534
// 1
// 100.200.0.0/16
//
//
// Тест №3
// Входные данные:
// 4 100
// 100.200.3.4
// 100.200.5.6
// 100.200.6.7
// 100.200.8.9
//
// Выходные данные:
// 0
// 4
// 100.200.3.4
// 100.200.5.6
// 100.200.6.7
// 100.200.8.9

namespace LeetCode.Ozon_Route_256_Middle_Contest_2023;

public static class H
{
    
}