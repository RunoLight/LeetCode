namespace LeetCode;

// <div class="layout-pane__container"><div class=""><div id="main-splitpane-left" class="coding-question__left-pane"><div class="coding-question__left-pane__wrapper"><section class="question-view__title-wrapper"><h2 class="disable-text-selection question-view__title">5. Maximizing Element With Constraints</h2></section><section class="question-view__instruction"><div class="candidate-rich-text disable-text-selection"><div id="36i8p279n6k-instruction"><style type="text/css">.ps-content-wrapper-v0 div { margin: 0 auto; overflow: auto; } .ps-content-wrapper-v0 div.preheader { display: none; } .ps-content-wrapper-v0 p { white-space: pre-wrap; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; } .ps-content-wrapper-v0 p.section-title { font-weight: bold; padding-bottom: 0px; } .ps-content-wrapper-v0 ol.plain-list, .ps-content-wrapper-v0 ul.plain-list { list-style-type: none; padding: 4px; } .ps-content-wrapper-v0 li { white-space: normal; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 code { color: black; } .ps-content-wrapper-v0 pre { background-color: #f4faff; border: 0; border-radius: 2px; margin: 8px; padding: 10px; } .ps-content-wrapper-v0 pre.scrollable-full-json { overflow-x: scroll; white-space: pre; } .ps-content-wrapper-v0 pre.scrollable-json { height: 300px; overflow-y: scroll; display: inline-grid; white-space: pre-wrap; padding-left: 8px; padding-right: 8px; padding-top: 4px; padding-bottom: 4px; } .ps-content-wrapper-v0 div.equation-parent { width: 400px; text-align: center; border: 1px solid #000; padding: 8px; } .ps-content-wrapper-v0 div.equation-parent.equation { width: 100%; display: inline-block; } .ps-content-wrapper-v0 figure { background-color: transparent; display: table; margin-top: 8px; margin-bottom: 8px; text-align: center; margin-left: auto; margin-right: auto; } .ps-content-wrapper-v0 figcaption { text-align: center; display: table-caption; caption-side: bottom; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 img { width: auto; max-width: 100%; height: auto; } .ps-content-wrapper-v0 details { background-color: transparent; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; } .ps-content-wrapper-v0 details details { padding-left: 8px; padding-right: 8px; } .ps-content-wrapper-v0 details summary { background-color: #39424e; color: white; font-weight: bold; margin-top: 4px; margin-bottom: 4px; padding: 8px; } .ps-content-wrapper-v0 details details summary code { color: black; font-weight: bold; padding-left: 2px; padding-right: 2px; padding-top: 4px; padding-right: 4px; margin-left: 4px; } .ps-content-wrapper-v0 details div.collapsable-details { margin: 0 auto; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; overflow: auto; } .ps-content-wrapper-v0 details div.collapsable-details pre { margin-left: 4px; margin-right: 4px; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 table.normal { border: 1px solid black; border-collapse: collapse; border-color: darkgray; margin: 0 auto; margin-top: 8px; margin-bottom: 8px; padding: 8px; width: 96%; table-layout: fixed; } .ps-content-wrapper-v0 table.normal tbody { display: block; overflow-x: auto; overflow-y: hidden; } .ps-content-wrapper-v0 table.normal tbody tr:first-child th { font-weight: bold; white-space: normal; } .ps-content-wrapper-v0 table.normal tbody tr th, .ps-content-wrapper-v0 table.normal tbody tr td { font-weight: normal; white-space: nowrap; text-align: center; vertical-align: middle; border: 1px solid black; border-color: darkgray; padding: 8px; } .ps-content-wrapper-v0 table.database-table { border-collapse: collapse; border-color: darkgray; border: 1px solid black; width: auto; margin-left: 4px; margin-top: 8px; margin-bottom: 8px; padding: 8px; } .ps-content-wrapper-v0 table.database-table tbody { overflow-x: auto; overflow-y: hidden; border: none; } .ps-content-wrapper-v0 table.database-table tbody tr th, .ps-content-wrapper-v0 table.database-table tbody tr td { font-weight: normal; white-space: nowrap; text-align: center; vertical-align: middle; border: 1px solid black; border-color: darkgray; padding: 8px; } .ps-content-wrapper-v0 table.database-table tbody tr th { font-weight: bold; border: 1px solid black; } .ps-content-wrapper-v0 table.database-table tbody tr:nth-child(2) td { border: 1px solid black; } .ps-content-wrapper-v0 table.database-table tbody tr:nth-child(n+2) td:first-child { border-left-color: black; } .ps-content-wrapper-v0 table.database-table tbody tr:nth-child(n+2) td:last-child { border-right-color: black; } .ps-content-wrapper-v0 table.database-table tbody tr:last-child td { border-bottom-color: black; } .ps-content-wrapper-v0 table.database-table tbody tr td.description { text-align: left; white-space: pre-wrap; } .ps-content-wrapper-v0 table.normal tbody tr th.description { width: 60%; } .ps-content-wrapper-v0 table.function-params tbody tr:first-child td.headers { border-bottom-width: 2px; } .ps-content-wrapper-v0 table.function-params tbody tr:last-child td { border-top-width: 2px; border-top-color: darkgray; } .ps-content-wrapper-v0 table.function-params tbody tr td.headers { width: 25%; font-weight: bold; text-align: center; border: 1px solid black; border-right-width: 2px; border-color: darkgray; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell { width: 100%; height: 100%; padding: 0px; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table { width: 100%; height: 100%; padding: 0px; margin: 0px; border: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td.code { white-space: normal; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th { border-top: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th:first-child { border-left: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th:last-child { border-right: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr:last-child td { border-bottom: 0; border-top-width: 1px; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td:first-child { border-left: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td:last-child { border-right: 0; } .ps-content-wrapper-v0 table.sudoku { border-collapse: collapse; border-color: darkgray; margin: 0 auto; margin-top: 8px; margin-bottom: 8px; padding: 8px; } .ps-content-wrapper-v0 table.sudoku colgroup, tbody { border: 3px solid black; } .ps-content-wrapper-v0 table.sudoku td { border: 1px solid black; height: 25px; width: 25px; text-align: center; padding: 0; } .ps-content-wrapper-v0 .left { text-align: left; } .ps-content-wrapper-v0 .right { text-align: right; } .ps-content-wrapper-v0 .code { font-family: monospace; white-space: nowrap; } .ps-content-wrapper-v0 .json-object-array ol, .ps-content-wrapper-v0 .json-object-array ol ul { margin-top: 0px; padding-left: 14px; } .json-object-array li { float: left; margin-right: 30px; margin-left: 10px; } .json-object-array pre { padding: 4px; margin-left: 0px; }
// </style>
// <p>In this problem, the goal is to determine the maximum value of an element at a certain index in an array of integers that can be constructed under some constraints.</p>
//
// <p>&nbsp;</p>
//
// <p>More specifically,&nbsp;<em>n</em> is the desired array size, <em>maxSum</em> is the maximum allowed sum of elements in the array, and <em>k</em> is the index of the element that needs its value to be maximized. The 0-indexed array has the following constraints:</p>
//
// <ol>
// 	<li>The array consists of <em>n</em> positive&nbsp;integers.</li>
// 	<li>The sum of all elements in the array is at most <em>maxSum.</em>
// </li>
// 	<li>The absolute difference between any two consecutive elements in&nbsp;the array is at most 1.</li>
// </ol>
//
// <p>&nbsp;</p>
//
// <p>What is the maximum value of the integer at index <em>k</em> in such an array?</p>
//
// <p>&nbsp;</p>
//
// <p>For example, let's say&nbsp;<em>n = 3</em>,&nbsp;<em>maxSum = 6</em>, and&nbsp;<em>k = 1</em>. So, the goal is to find the maximum value of the element at index 1 in an array of 3 positive integers, where the sum of elements is at most 6, and the absolute difference between every two consecutive elements is at most 1.</p>
//
// <p>&nbsp;</p>
//
// <p>The maximum such value is 2, and it can be achieved, for example, by the array [1, 2, 2]. This array has 3 elements, each of them a positive integer. The sum of the elements does not exceed 6, and the absolute difference between any two consecutive elements is at most 1. There is no other such array that has a larger value at index&nbsp;<em>k = 1</em>. Therefore, the answer is 2&nbsp;because that is the maximum value of the integer at index&nbsp;<em>k</em>.</p>
//
// <div class="ps-content-wrapper-v0">
// <p>&nbsp;</p>
//
// <p class="section-title" data-a11y="p-s-t" role="heading" aria-level="4">Function Description</p>
//
// <p>Complete the function <em>maxElement</em> in the editor below. The function must return an integer denoting the maximum value of the element at index <em>k</em> given the above constraints.</p>
//
// <p>&nbsp;</p>
//
// <p><em>maxElement</em> has the following parameter(s):</p>
//
// <p>&nbsp;&nbsp;&nbsp;&nbsp;int <em>n</em>:<i> the size of the array</i></p>
//
// <p>&nbsp;&nbsp;&nbsp;&nbsp;int <em>maxSum</em>:<i> the maximum allowed sum of the elements in the array</i></p>
//
// <p><i>&nbsp;&nbsp;&nbsp;&nbsp;int </i><em>k</em><i>: the index of the element in the array where the value needs to be maximized</i></p>
//
// <p><i>Returns</i></p>
//
// <p><i>&nbsp;&nbsp;&nbsp;&nbsp;int: </i>the maximum value of the element at index <em>k</em> given the above constraints</p>
//
// <p>&nbsp;</p>
//
// <p class="section-title" data-a11y="p-s-t" role="heading" aria-level="4">Constraints</p>
//
// <ul>
// 	<li>
// 	<p>1≤ <em>n</em>&nbsp;≤ <em>maxSum</em> ≤ 10<sup>9</sup></p>
// 	</li>
// 	<li>
// 	<p>1≤ <em>k</em>&nbsp;≤ <em>n</em></p>
// 	</li>
// </ul>
//
// <p>&nbsp;</p>
// <!-- <StartOfInputFormat> DO NOT REMOVE THIS LINE-->
//
// <details><summary class="section-title" data-a11y="d-s"><span data-a11y="d-s-t" role="heading" aria-level="4">Input Format For Custom Testing</span></summary>
//
// <div class="collapsable-details">
// <p>The first line contains an integer, <em>n</em>, denoting the number of elements in the array.</p>
//
// <p><i>The second line contains an integer, </i><em>maxSum</em><i>, denoting the maximum allowed sum of the elements in the array.</i></p>
//
// <p>The third line contains an integer <em>k</em>, denoting the index of the element in the array where the value needs to be maximized.</p>
// </div>
// </details>
// <!-- </StartOfInputFormat> DO NOT REMOVE THIS LINE-->
//
// <details><summary class="section-title" data-a11y="d-s"><span data-a11y="d-s-t" role="heading" aria-level="4">Sample Case 0</span></summary>
//
// <div class="collapsable-details">
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Sample Input For Custom Testing</p>
//
// <pre>3
// 7
// 1
// </pre>
//
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Sample Output</p>
//
// <pre>3</pre>
//
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Explanation</p>
//
// <p>In this case,&nbsp;<em>n&nbsp;= 3, maxSum = 7, </em>and<em> k = 1.</em> So, the goal is to find the maximum value of an element at index 1 in an array of 3 positive integers, where the sum of elements&nbsp;is at most 7, and the absolute difference between every two consecutive elements is at most 1.</p>
//
// <p>&nbsp;</p>
//
// <p>The maximum such value is 3, and it is achieved, for example, by the array [2, 3, 2]. This array has 3 elements, each a positive integer. The sum of all elements does not exceed 7, and the absolute difference between any two consecutive elements is at most 1.&nbsp;There is no other such array that has a larger value at index <em>k = 1</em>. Therefore, the answer is 3 because that is the maximum value of the integer at index&nbsp;<em>k</em>.</p>
// </div>
// </details>
//
// <details><summary class="section-title" data-a11y="d-s"><span data-a11y="d-s-t" role="heading" aria-level="4">Sample Case 1</span></summary>
//
// <div class="collapsable-details">
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Sample Input For Custom Testing</p>
//
// <pre>4
// 6
// 2
// </pre>
//
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Sample Output</p>
//
// <pre>2
// </pre>
//
// <p class="section-title" data-a11y="d-p-s-t" role="heading" aria-level="5">Explanation</p>
//
// <p>In this case, <em>n&nbsp;= 4, maxSum = 6, </em>and <em>k = 2</em>. So, the goal is to find the maximum value of an element at index 2 in an array of 4 positive integers, where the sum of elements&nbsp;is at most 6, and the absolute difference between every two consecutive elements is at most 1.</p>
//
// <p>&nbsp;</p>
//
// <p>The maximum such value is 2, and it is achieved, for example, by the array [1, 1, 2, 1]. This array has 4 elements, each a positive integer. The sum of all elements does not exceed 6, and the absolute difference between any two consecutive elements is at most 1.&nbsp;There is no other such array that has a larger value at index <em>k = 2</em>. Therefore, the answer is 2 because that is the maximum value of the integer at index&nbsp;<em>k</em>.</p>
// </div>
// </details>
// </div>
// </div></div></section></div></div></div></div>
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static int maxElement(int n, int maxSum, int k)
    {
        // Binary search bounds: minimum value is 1, maximum value is maxSum
        int left = 1, right = maxSum;
        
        while (left < right)
        {
            // In default "/2" floors value if it's X.5f. We doing ceiling via +1. Because we are not finding elements here,
            // but we searching best-possible of all, from left to right, so when there's two elements left - set mid as right one
            // to assign (mid - 1) or let left be new and last mid.
            int mid = (right + left + 1) / 2;
            // Check if it's possible to have mid as the value at index k
            if (CanHaveValueAtK(n, maxSum, k, mid))
                left = mid; // Mid is a valid candidate, try for a larger one
            else
                right = mid - 1; // Mid is too large, try smaller values
        }
        
        return left; // The maximum valid value
    }
    
    // Helper function to check if we can have 'val' at index k
    private static bool CanHaveValueAtK(int n, int maxSum, int k, int val)
    {
        // Calculate the sum of the array if a[k] = val
        long sum = val;
        
        // Calculate the sum of elements to the left of k
        sum += SumLeftOrRight(k, val);
        
        // Calculate the sum of elements to the right of k
        sum += SumLeftOrRight(n - k - 1, val);
        
        return sum <= maxSum;
    }
    
    // Helper function to calculate the sum of elements on one side of k
    private static long SumLeftOrRight(int count, int peak)
    {
        if (count == 0) return 0;
        
        // Calculate the decreasing sequence to the left or right of the peak
        long sum = 0;
        int height = peak - 1;
        
        if (count <= height)
        {
            // If the number of elements can all be in a decreasing sequence
            sum = (long)count * (height + (height - count + 1)) / 2;
        }
        else
        {
            // If not, there will be trailing ones
            sum = (long)height * (height + 1) / 2;
            sum += (count - height); // The rest are ones
        }
        
        return sum;
    }
}

class Solution
{
    public static void Main()
    {
        TestCase(4, 6, 2, 2);
        TestCase(3, 7, 1, 3);
        TestCase(3, 6, 1, 2);
        TestCase(1, 10, 0, 10);
        TestCase(1, 9, 0, 9);
        TestCase(1, 1, 0, 1);
        TestCase(4, 6, 1, 2);

        void TestCase(int n, int maxSum, int k, int exceptedResult)
        {
            var answer = Result.maxElement(n, maxSum, k);
            Console.WriteLine(answer == exceptedResult ? "--- OK ---" : "--- BAD --");
            Console.WriteLine($"Test: n={n}, maxSum={maxSum}, k={k}");
            Console.WriteLine($"Exp: {exceptedResult} / Act: {answer}");
        }
    }
}