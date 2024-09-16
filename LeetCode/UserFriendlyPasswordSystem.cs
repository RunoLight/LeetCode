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
using System;
using System.Collections.Generic;

class Solution2
{
    const int MOD = 1000000007;
    const int P = 131;

    static long ComputeHash(string s)
    {
        long hashValue = 0;
        long pPow = 1; // P^0 initially

        for (int i = s.Length - 1; i >= 0; i--)
        {
            hashValue = (hashValue + (s[i] * pPow) % MOD) % MOD;
            pPow = (pPow * P) % MOD;
        }

        return hashValue;
    }

    // ReSharper disable once InconsistentNaming <- It should be named like this to be accepted in automated system
    public static List<int> authEvents(List<List<string>> events)
    {
        string currentPassword = "";
        long currentHash = 0;
        List<int> results = new List<int>();

        // Precompute powers of P up to length 10 (password length is at most 9)
        long[] powersOfP = new long[10];
        powersOfP[0] = 1;
        for (int i = 1; i < 10; i++)
        {
            powersOfP[i] = (powersOfP[i - 1] * P) % MOD;
        }

        foreach (var eventDetails in events)
        {
            if (eventDetails[0] == "setPassword")
            {
                // Update the current password and its hash
                currentPassword = eventDetails[1];
                currentHash = ComputeHash(currentPassword);
            }
            else if (eventDetails[0] == "authorize")
            {
                // Attempt to authorize
                long attemptedHash = long.Parse(eventDetails[1]);

                // Check if it matches the current password's hash
                if (attemptedHash == currentHash)
                {
                    results.Add(1);
                    continue;
                }

                // Check if it matches the hash of the password with one extra character appended
                bool authorized = false;
                for (int c = 48; c <= 122; c++) // ASCII range for '0'-'9', 'A'-'Z', 'a'-'z'
                {
                    // When appending a new character to a string, the hash formula requires shifting the entire previous
                    // hash to account for the new character being added at the end.

                    // To shift the hash, you multiply the existing hash by the base P. This effectively "moves" the entire
                    // current string one position left in the polynomial hash formula. If the password was of length n,
                    // multiplying by P makes it behave as if the string is now of length n + 1, because each character's
                    // contribution shifts to a higher power of P.

                    // https://www.geeksforgeeks.org/string-hashing-using-polynomial-rolling-hash-function/#
                    long extraCharHash = (currentHash * P + c) % MOD;
                    if (extraCharHash == attemptedHash)
                    {
                        authorized = true;
                        break;
                    }
                }

                results.Add(authorized ? 1 : 0);
            }
        }

        return results;
    }

    public static void Main()
    {
        // Example input processing
        int q = int.Parse(Console.ReadLine());
        List<List<string>> events = new List<List<string>>();

        for (int i = 0; i < q; i++)
        {
            var eventDetails = Console.ReadLine().Split().ToList();
            events.Add(eventDetails);
        }

        List<int> result = authEvents(events);
        foreach (var res in result)
        {
            Console.WriteLine(res);
        }
    }
}