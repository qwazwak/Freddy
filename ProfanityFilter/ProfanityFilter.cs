/*
MIT License
Copyright (c) 2019
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ProfanityFilterTools.Interfaces;

namespace ProfanityFilterTools;

/// <summary>
///
/// This class will detect profanity and racial slurs contained within some text and return an indication flag.
/// All words are treated as case insensitive.
///
/// </summary>
public class ProfanityFilter : ProfanityBase, IProfanityFilter
{

    /// <summary>
    /// Default constructor that loads up the default profanity list.
    /// </summary>
    public ProfanityFilter() { }

    /// <summary>
    /// Constructor overload that allows you to construct the filter with a customer
    /// profanity list.
    /// </summary>
    /// <param name="profanityList">List of words to add into the filter.</param>
    public ProfanityFilter(IEnumerable<string> profanityList) : base(profanityList) { }

    /// <summary>
    /// Return the allow list;
    /// </summary>
    public IAllowList AllowList { get; } = new AllowList();

    /// <summary>
    /// Check whether a specific word is in the profanity list. IsProfanity will first
    /// check if the word exists on the allow list. If it is on the allow list, then false
    /// will be returned.
    /// </summary>
    /// <param name="word">The word to check in the profanity list.</param>
    /// <returns>True if the word is considered a profanity, False otherwise.</returns>
    public bool IsProfanity(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return false;
        }

        // Check if the word is in the allow list.
        if (AllowList.Contains(word.ToLower(CultureInfo.InvariantCulture)))
        {
            return false;
        }

        return _profanities.Contains(word);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    public ReadOnlyCollection<string> DetectAllProfanities(string sentence) => DetectAllProfanities(sentence, false);

    /// <summary>
    /// For a given sentence, return a list of all the detected profanities.
    /// </summary>
    /// <param name="sentence">The sentence to check for profanities.</param>
    /// <param name="removePartialMatches">Remove duplicate partial matches.</param>
    /// <returns>A read only list of detected profanities.</returns>
    public ReadOnlyCollection<string> DetectAllProfanities(string sentence, bool removePartialMatches)
    {
        if (string.IsNullOrEmpty(sentence))
        {
            return new ReadOnlyCollection<string>(new List<string>());
        }

        sentence = sentence.ToLower();
        sentence = sentence.Replace(".", "");
        sentence = sentence.Replace(",", "");

        var words = sentence.Split(' ');
        var postAllowList = FilterWordListByAllowList(words);

        // Catch whether multi-word profanities are in the allow list filtered sentence.
        List<string> swearList = GetMultiWordProfanities(postAllowList.ToHashSet()).ToList();

        // Deduplicate any partial matches, ie, if the word "twatting" is in a sentence, don't include "twat" if part of the same word.
        if (removePartialMatches)
        {
            swearList.RemoveAll(x => swearList.Any(y => x != y && y.Contains(x)));
        }

        return new ReadOnlyCollection<string>(FilterSwearListForCompleteWordsOnly(sentence, swearList).Distinct().ToList());
    }

    /// <summary>
    /// For any given string, censor any profanities from the list using the default
    /// censoring character of an asterix.
    /// </summary>
    /// <param name="sentence">The string to censor.</param>
    /// <returns></returns>
    public string CensorString(string sentence) => CensorString(sentence, '*');

    /// <summary>
    /// For any given string, censor any profanities from the list using the specified
    /// censoring character.
    /// </summary>
    /// <param name="sentence">The string to censor.</param>
    /// <param name="censorCharacter">The character to use for censoring.</param>
    /// <returns></returns>
    public string CensorString(string sentence, char censorCharacter) => CensorString(sentence, censorCharacter, false);

    /// <summary>
    /// For any given string, censor any profanities from the list using the specified
    /// censoring character.
    /// </summary>
    /// <param name="sentence">The string to censor.</param>
    /// <param name="censorCharacter">The character to use for censoring.</param>
    /// <param name="ignoreNumbers">Ignore any numbers that appear in a word.</param>
    /// <returns></returns>
    public string CensorString(string sentence, char censorCharacter, bool ignoreNumbers)
    {
        if (string.IsNullOrEmpty(sentence))
        {
            return string.Empty;
        }

        string noPunctuation = sentence.Trim();
        noPunctuation = noPunctuation.ToLower();

        noPunctuation = Regex.Replace(noPunctuation, @"[^\w\s]", "");

        var words = noPunctuation.Split(' ');

        var postAllowList = FilterWordListByAllowList(words);

        // Catch whether multi-word profanities are in the allow list filtered sentence.
        List<string> swearList = GetMultiWordProfanities(postAllowList.ToHashSet()).ToList();

        StringBuilder censored = new(sentence);
        StringBuilder tracker = new(sentence);

        return CensorStringByProfanityList(censorCharacter, swearList, censored, tracker, ignoreNumbers).ToString();
    }

    /// <summary>
    /// For a given sentence, look for the specified profanity. If it is found, look to see
    /// if it is part of a containing word. If it is, then return the containing work and the start
    /// and end positions of that word in the string.
    ///
    /// For example, if the string contains "scunthorpe" and the passed in profanity is "cunt",
    /// then this method will find "cunt" and work out that it is part of an enclosed word.
    /// </summary>
    /// <param name="toCheck">Sentence to check.</param>
    /// <param name="profanity">Profanity to look for.</param>
    /// <returns>Tuple of the following format (start character, end character, found enclosed word).
    /// If no enclosed word is found then return null.</returns>
    public (int, int, string)? GetCompleteWord(string toCheck, string profanity)
    {
        if(TryGetCompleteWord(toCheck, profanity, out int startIndex, out int endIndex, out string result))
            return (startIndex, endIndex, result);
        return null;
    }
    public bool TryGetCompleteWord(string toCheck, string profanity, out int startIndex, out int endIndex, out string result)
    {
        if (!TryGetCompleteWord(toCheck, profanity, out startIndex, out endIndex))
        {
            result = default!;
            return false;
        }
        result = toCheck[startIndex..endIndex].ToLower(CultureInfo.InvariantCulture);
        return true;
    }
    public bool TryGetCompleteWord(string toCheck, string profanity, out int startIndex, out int endIndex)
    {
        if (string.IsNullOrEmpty(toCheck))
        {
            startIndex = default;
            endIndex = default;
            return false;
        }

        string profanityLowerCase = profanity.ToLower(CultureInfo.InvariantCulture);
        string toCheckLowerCase = toCheck.ToLower(CultureInfo.InvariantCulture);
        
        startIndex = endIndex = toCheckLowerCase.IndexOf(profanityLowerCase, SharedStatics.StringComparison);

        if (startIndex == -1)
        {
            return false;
        }

        // Work backwards in string to get to the start of the word.
        while (startIndex > 0)
        {
            if (toCheck[startIndex - 1] == ' ' || char.IsPunctuation(toCheck[startIndex - 1]))
            {
                break;
            }

            startIndex -= 1;
        }

        // Work forwards to get to the end of the word.
        while (endIndex < toCheck.Length)
        {
            if (toCheck[endIndex] == ' ' || char.IsPunctuation(toCheck[endIndex]))
            {
                break;
            }

            endIndex += 1;
        }

        return true;
    }

    /// <summary>
    /// Check whether a given term matches an entry in the profanity list. ContainsProfanity will first
    /// check if the word exists on the allow list. If it is on the allow list, then false
    /// will be returned.
    /// </summary>
    /// <param name="term">Term to check.</param>
    /// <returns>True if the term contains a profanity, False otherwise.</returns>
    public bool ContainsProfanity(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return false;
        }

        IEnumerable<string> potentialProfanities = _profanities.Where(word => word.Length <= term.Length);
        
        // We might have a very short phrase coming in, resulting in no potential matches even before the regex
        if (!potentialProfanities.Any())
        {
            return false;
        }

        Regex regex = new($@"(?:{string.Join("|", potentialProfanities).Replace("$", "\\$")})");

        foreach (Match profanity in regex.Matches(term).Cast<Match>())
        {
            // if any matches are found and aren't in the allowed list, we can return true here without checking further
            if (!AllowList.Contains(profanity.Value.ToLower(CultureInfo.InvariantCulture)))
            {
                return true;
            }
        }

        return false;
    }

    private StringBuilder CensorStringByProfanityList(char censorCharacter, IEnumerable<string> swearList, StringBuilder censored, StringBuilder tracker, bool ignoreNumeric)
    {
        foreach (string word in swearList.OrderByDescending(x => x.Length))
        {
            var multiWord = word.Split(' ');

            if (multiWord.Length == 1)
            {
                while (TryGetCompleteWord(tracker.ToString(), word, out int startIndex, out int endIndex, out string filtered))
                {
                    if (ignoreNumeric)
                    {
                        filtered = Regex.Replace(filtered, @"[\d-]", string.Empty);
                    }

                    if (filtered == word)
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            censored[i] = censorCharacter;
                            tracker[i] = censorCharacter;
                        }
                    }
                    else
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            tracker[i] = censorCharacter;
                        }
                    }
                }
            }
            else
            {
                censored = censored.Replace(word, CreateCensoredString(word, censorCharacter));
            }
        }

        return censored;
    }

    private IEnumerable<string> FilterSwearListForCompleteWordsOnly(string sentence, IEnumerable<string> swearList)
    {
        StringBuilder tracker = new(sentence);

        foreach (string word in swearList.OrderByDescending(x => x.Length))
        {
            var multiWord = word.Split(' ');

            if (multiWord.Length == 1)
            {
                while (TryGetCompleteWord(tracker.ToString(), word, out int startIndex, out int endIndex, out string result))
                {
                    if (result == word)
                        yield return word;

                    for (int i = startIndex; i < endIndex; i++)
                        tracker[i] = '*';

                    if (result == word)
                        break;
                }
            }
            else
            {
                yield return word;
                tracker.Replace(word, " ");
            }
        }
    }

    private IEnumerable<string> FilterWordListByAllowList(IEnumerable<string> words) => words.Where(w => !string.IsNullOrEmpty(w) && !AllowList.Contains(w));

    private IEnumerable<string> GetMultiWordProfanities(HashSet<string> postAllowListSentence) => _profanities.Where(postAllowListSentence.Contains);

    private static string CreateCensoredString(string word, char censorCharacter)
    {
        string censoredWord = string.Empty;

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] != ' ')
            {
                censoredWord += censorCharacter;
            }
            else
            {
                censoredWord += ' ';
            }
        }

        return censoredWord;
    }
}