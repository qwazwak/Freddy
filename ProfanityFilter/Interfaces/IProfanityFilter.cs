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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ProfanityFilterTools.Interfaces;

public interface IProfanityFilter
{
    bool IsProfanity(string word);
    ReadOnlyCollection<string> DetectAllProfanities(string sentence);
    ReadOnlyCollection<string> DetectAllProfanities(string sentence, bool removePartialMatches);
    bool ContainsProfanity(string term);
    
    IAllowList AllowList { get; }
    string CensorString(string sentence);
    string CensorString(string sentence, char censorCharacter);
    string CensorString(string sentence, char censorCharacter, bool ignoreNumbers);
    (int, int, string)? GetCompleteWord(string toCheck, string profanity);
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
    public bool TryGetCompleteWord(string toCheck, string profanity, out int startIndex, out int endIndex);

    void AddProfanity(string profanity);
    void AddProfanity(IEnumerable<string> profanityList);

    bool RemoveProfanity(string profanity);
    bool RemoveProfanity(IEnumerable<string> profanities);

    void Clear();

    int Count { get; }
}