namespace LeetCode;

// 3. User-Friendly Password System
//     
// A website is programming an authentication system that will accept a password either if it's the correct password or
// if it's the correct password with a single character appended to it. In this challenge, your task is to implement such
// a system, specifically using a hashing function. Given a list of events in which either a password is set or authorization
// is attempted, determine if each authorization attempt will be successful or not.
// The hashing function that will be used in this problem is as follows. Let f(x) be a function that takes a character and
// returns its decimal character code in the ASCII table. For instance f('a') = 97, f('B') = 66, and f('9') = 57. (You can
// find all ASCII character codes here: <a href="http://ascii.cl">ASCII table</a>.) Then,let h(s) be the hashing function
// that takes a string and hashes it in the following way, where p = 131 and M =10<sup>9</sup>+7 :
// h(s) := (s[0]*P<sup>(n-1)</sup>+ s[1]*P<sup>(n-2)</sup>+ s[2]*P<sup>(n-3)</sup>+ ... + s[n-2]*P+ s[n-1]) mod M
// For instance, ifs = "cAr1", then the formula would be as follows:
// h(s) =(f('c')*131<sup>3</sup>+ f('A')*131<sup>2</sup>+ f('r')*131 + f('1')) mod 10<sup>9</sup>+7 =223691457
// Your system will be tested on q event types, each of which will be one of the following:
// 	
// 	setPassword(s) := sets the password to s
// 	authorize(x) := tries to sign in with integer x. This event must return 1 if xis either the hash of the current password or
// the hash of the current password with a single character appended to it. Otherwise, this event must return 0.
// 	
// Consider the following example. There are 6events to be handled:
//
// 	setPassword("cAr1")
// 	authorize(223691457)
// 	authorize(303580761)
// 	authorize(100)
// 	setPassword("d")
// 	authorize(100)
//
// As we know from the above example, h("cAr1") =223691457, so the second event will return 1.
// The third event will also return 1 because303580761 is the hash value of the string "cAr1a", which is equal to the current
// password with the character 'a' appended to it. The fourth event will return 0 because 100 is not a hash of the current
// password or of the current password with a single character appended to it.In the fifth event, the current password is
// set to "d", and the sixth event will return 1 because h("d") = 100.
// Therefore, the array you would return is [1, 1 0, 1], corresponding to the success or failure of the authorization events.
// Function Description
//
// Complete the function authEvents in the editor below.
// authEvents has the following parameter(s):
//
// string events[q][2]: a2-dimensional array of strings denoting the event types and event parameters
//
// Returns:
//
// int[number of authorize events]: an array of integers, either 1 or 0, corresponding to the success (1) or failure (0) of each authorization attempt
//
// Constraints
// 	2 ≤ q≤ 10<sup>5</sup>
// 	1 ≤ length of s≤ 9, where s is a parameter of the setPassword event
// 	0 ≤ x &lt; 10<sup>9</sup>+7, where x is the integer value of the parameter of the authorize event
// 	The first event will always be a setPassword event.
// 	There will be at least one authorize event.
// 	s contains only lowercase and uppercase English letters and digits.

// Input
// 2
// setPassword 000A
// authorize 108738450
// authorize 108738449
// authorize 244736787

// Output
// 0
// 1
// 1
//
// Explanation
//
// There are 4 events to process:
//
// 	The first one sets the password to "000A".
// 	The second one tries to authorize with the hash value 108738450. This value (which is the hash of the string "000B") doesn't correspond to the current password, nor to the current password with a single character appended to it. Therefore, this event returns 0.
// 	The third event tries to authorize with the hash value 108738449. This is indeed the hash value of the current password, so this event returns 1.
// 	Finally, the last event tries to authorize with hash value 244736787. This is the hash value of string "000AB", which is valid because it is equal to the current password with a single character appended to it. Therefore, this event returns 1.
// 	
// Sample Case 1
// 5
// 2
// setPassword 1
// setPassword 2
// setPassword 3
// authorize 49
// authorize 50
//
// Sample Output
//
// 0
// 0
//
// Explanation
//
// There are 5 events to process:
//
// 	
// 	The first one sets the password to "1".
// 	The second one sets the password to "2".
// 	The third one sets the password to "3".
// 	The fourth event tries to authorize with the hash value 49, which corresponds to "1". Because this is invalid for the current password of "3", this event returns 0.
// 	The fifth event tries to authorize with the hash value 50, which corresponds to "2". Because this is invalid for the current password of "3", this event returns 0.
// 	

// </div>
// </details>
// </div>
// <style type="text/css">1 ≤ |source| ≤ 10^6 .ps-content-wrapper-v0 div { margin: 0 auto; overflow: auto; } .ps-content-wrapper-v0 div.preheader { display: none; } .ps-content-wrapper-v0 p { white-space: pre-wrap; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; } .ps-content-wrapper-v0 p.section-title { font-weight: bold; padding-bottom: 0px; } .ps-content-wrapper-v0 ol.plain-list, .ps-content-wrapper-v0 ul.plain-list { list-style-type: none; padding: 4px; } .ps-content-wrapper-v0 li { white-space: normal; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 code { color: black; } .ps-content-wrapper-v0 pre { background-color: #f4faff; border: 0; border-radius: 2px; margin: 8px; padding: 10px; } .ps-content-wrapper-v0 figure { background-color: transparent; display: table; margin-top: 8px; margin-bottom: 8px; text-align: center; margin-left: auto; margin-right: auto; } .ps-content-wrapper-v0 figcaption { text-align: center; display: table-caption; caption-side: bottom; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 img { width: auto; max-width: 100%; height: auto; } .ps-content-wrapper-v0 details { background-color: transparent; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; } .ps-content-wrapper-v0 details summary { background-color: #39424e; color: white; font-weight: bold; margin-top: 4px; margin-bottom: 4px; padding: 8px; } .ps-content-wrapper-v0 details div.collapsable-details { margin: 0 auto; padding-left: 4px; padding-right: 4px; padding-top: 0px; padding-bottom: 2px; overflow: auto; } .ps-content-wrapper-v0 details div.collapsable-details pre { margin-left: 4px; margin-right: 4px; margin-top: 4px; margin-bottom: 4px; } .ps-content-wrapper-v0 table { border: 1px solid black; border-collapse: collapse; border-color: darkgray; margin: 0 auto; margin-top: 8px; margin-bottom: 8px; padding: 8px; width: 96%; table-layout: fixed; } .ps-content-wrapper-v0 table tbody tr th, .ps-content-wrapper-v0 table tbody tr td { font-weight: bold; white-space: nowrap; text-align: center; vertical-align: middle; border: 1px solid black; border-color: darkgray; padding: 8px; } .ps-content-wrapper-v0 table tbody tr th.description { width: 60%; } .ps-content-wrapper-v0 table tbody tr td { font-weight: normal; white-space: normal; } .ps-content-wrapper-v0 table.function-params tbody tr:first-child td.headers { border-bottom-width: 2px; } .ps-content-wrapper-v0 table.function-params tbody tr:last-child td { border-top-width: 2px; border-top-color: darkgray; } .ps-content-wrapper-v0 table.function-params tbody tr td.headers { width: 25%; font-weight: bold; text-align: center; border: 1px solid black; border-right-width: 2px; border-color: darkgray; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell { width: 100%; height: 100%; padding: 0px; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table { width: 100%; height: 100%; padding: 0px; margin: 0px; border: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td.code { white-space: normal; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th { border-top: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th:first-child { border-left: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr th:last-child { border-right: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr:last-child td { border-bottom: 0; border-top-width: 1px; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td:first-child { border-left: 0; } .ps-content-wrapper-v0 table.function-params tbody tr td.params-table-cell table.params-table tbody tr td:last-child { border-right: 0; } .ps-content-wrapper-v0 .left { text-align: left; } .ps-content-wrapper-v0 .right { text-align: right; } .ps-content-wrapper-v0 .code { font-family: monospace; white-space: nowrap; } .ps-content-wrapper-v0 .json-object-array ol, .ps-content-wrapper-v0 .json-object-array ol ul { margin-top: 0px; padding-left: 14px; } .json-object-array li { float: left; margin-right: 30px; margin-left: 10px; } .json-object-array pre { padding: 4px; margin-left: 0px; }
// </style>
// </div>

/*
 * Approach
 * Hashing Function: We need to calculate the hash value h(s) for any string s using the formula:
 *
 * h(s) = (s[0]*P^(n-1) + s[1]*P^(n-2) + ... + s[n-1]) mod M
 * Where:
 * P = 131 (a prime number)
 * M = 10^9 + 7 (a large prime modulus)
 *
 * Handling Authorization:
 * We need to compute the hash of the current password (h(s)).
 * For each authorization attempt, we also need to compute the hash for all possible strings that can be formed by
 * adding one character to the password. For efficiency, we can precompute powers of P to handle these hash computations in constant time.
 *
 * Efficient Processing:
 * We process each event and maintain the current password's hash.
 * For authorization events, we check if the given hash matches the password's hash or the hash of the password with any additional character.
 *
 * Plan
 * For each "setPassword" event, compute and store the hash of the new password.
 * For each "authorize" event, check if the given hash matches either the hash of the current password or any string formed
 * by appending a single character to the current password.
 */

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
    public static List<int> authEvents(List<List<string>> events) // TODO Check with one password less at end
    {
        List<int> operationsResult = new List<int>(events.Count);
        int currentPasswordHash = 0;
        List<int> availablePasswordHashes = new List<int>();

        for (int i = 0; i < events.Count; i++)
        {
            string operation = events[i][0];
            string parameter = events[i][1];

            if (operation.Equals("setPassword"))
            {
                currentPasswordHash = GetPasswordHash(parameter);
                availablePasswordHashes = GetPasswordHashesWhenAddedSymbol(parameter);
            }
            else
            {
                if (currentPasswordHash.ToString().Equals(parameter) ||
                    availablePasswordHashes.Any(hash => hash.ToString().Equals(parameter))
                   )
                {
                    operationsResult.Add(1);
                }
                else
                {
                    operationsResult.Add(0);
                }
            }
        }

        return operationsResult;
    }

    private static List<int> GetPasswordHashesWhenAddedSymbol(string password)
    {
        password += (char) 0;
        
        const int lastAsciiCharacterCode = 127;

        List<int> result = new List<int>(lastAsciiCharacterCode);
        
        var p = 131;
        var M = Math.Pow(10, 9) + 7;
        var n = password.Length;

        int currentHash = 0;
        for (int i = 0; i < password.Length; i++)
        {
            currentHash += password[i] * (int) Math.Pow(p, n - i - 1);
        }

        for (int i = 0; i <= lastAsciiCharacterCode; i++)
        {
            result.Add((int) ((currentHash + i) % M));
        }
        
        return result;
    }

    public static int GetPasswordHash(string password)
    {
        var p = 131;
        var M = Math.Pow(10, 9) + 7;
        var n = password.Length;
        
        var result = 0;
        for (int i = 0; i < password.Length; i++)
        {
            result += password[i] * (int) Math.Pow(p, n - i - 1);
        }
        
        return (int) (result % M);
    }
}

public static class Solution
{
    public static void Main()
    {
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        TextWriter textWriter = Console.Out;

        int eventsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int eventsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> events = new List<List<string>>();

        for (int i = 0; i < eventsRows; i++)
        {
            events.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        List<int> result = Result.authEvents(events);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
