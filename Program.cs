using System;
using System.Collections.Generic;

/// <summary>
/// Class Constants ... A place for constants
/// </summary>
static class Constants
{
    public const string MsgSent = "The String appears to contain no words.";
    public const int ShortestSentence = 3;
}

/// <summary>
/// Class Program ... Take in a string of English words with punctuation and no 
/// field seperators, and return/ print a proper sentence.
///
/// Example:
///     in: peanutbutterandjelly.
///     out: Peanut butter and jelly.
/// 
///     in: twowords
///     out: Two words.
/// </summary>
public class Program
{
    // To-do: 
    // Handle cases like: 
    // - Where is an English Dictionary?
    // - Find Words: to, too, and, sandwich, boo, book, club, bookclub
    // - Punctuation
    // - Ambiguity

    // Main ...
    /// <summary>
    /// Main ... Program driver and test cases
    /// </summary>
    public static void Main()
    {
        // Test Cases
        //string data = "go!";
        string data = "peanutbutterandjelly.";
        //string data = "twowords.";
        //string data = "  twowords   ";
        //string data = "doesn'texits.";
        //string data = "  a   b    c  d .";
        //string data = "";

        Console.WriteLine("Running StringSplit()\n");
        Console.WriteLine("Input: {0}", data);
        Console.WriteLine("Solution: \n{0}", ProperSentence(data));
    }

    /// <summary>
    /// ProperSentence ... Ensure proper sentence
    /// </summary>
    /// <param name="s"></param>
    /// <returns>string</returns>
    public static string ProperSentence(string s)
    {
        // Check for empty string and size
        // Console.WriteLine("Debug: String Length, {0}", s.Length);
        s = string.Join(" ", s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        if (string.IsNullOrEmpty(s)) { return Constants.MsgSent; }
        if (string.IsNullOrWhiteSpace(s)) { return Constants.MsgSent; }
        if (s.Length < Constants.ShortestSentence) { return Constants.MsgSent; }

        string tSent = FirstCharToUpper(StringWordSplit(s));
        return tSent;
    }

    /// <summary>
    /// FirstCharToUpper ... Capitalize the first letter of a string
    /// </summary>
    /// <param name="s"></param>
    /// <returns>string</returns>
    public static string FirstCharToUpper(string s)
    {
        // Return char and concat substring
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    /// <summary>
    /// StringWordSplit ... Split a string into various words
    /// </summary>
    /// <param name="s"></param>
    /// <returns>string</returns>
    private static string StringWordSplit(string s)
    {
        string s1 = s.ToLower();
        string engSentence;
        List<string> newWordList = new List<string>();

        // To-do: So much more to do here.
        // To-do: Dynamically create a better English Dictionary from various sources
        // To-do: Find a feature-rich English NLP Engine
        char[] sentPunctuation = { '\"', '\'', '-', ':', ';', '(', ')', '.' }; // To-do: Not currently used
        char[] endPunctuation = { '.', '!', '?' };
        var wordDictEnglish = new Dictionary<string, int>() {{"go", 00000},
                                                        {"peanut", 00001},
                                                        {"butter", 00002},
                                                        {"and", 00003},
                                                        {"jelly", 00004},
                                                        {"no", 00005},
                                                        {"yuck", 00006},
                                                        {"hard", 00007},
                                                        {"create", 00008},
                                                        {"two", 00009},
                                                        {"words", 00010}};

        // Loop using length from 0 to s1.Length
        for (int i = 0; i <= s1.Length; i++)
        {
            // Console.WriteLine(s1.Substring(0, i));
            // Loop using length from i + 1 to s1.Length
            for (int j = i + 1; j <= s1.Length; j++)
            {
                // Console.WriteLine(s1.Substring(i, j-i));
                if (wordDictEnglish.ContainsKey(s1.Substring(i, j - i)))
                {
                    newWordList.Add(s1.Substring(i, j - i));
                }
            }
        }

        // Convert the new List to an Array seperated by spaces (" ").
        engSentence = string.Join(" ", newWordList.ToArray());
        engSentence.TrimEnd(endPunctuation);

        // Check for an empty string due to our Dictionary's lack of English words
        // To-do: Handle end of a sentence punctuation: a period, an exclamation mark, or a question mark
        if (string.IsNullOrEmpty(engSentence)) { return Constants.MsgSent; }
        engSentence = engSentence + ".";
        return engSentence;
    }
}