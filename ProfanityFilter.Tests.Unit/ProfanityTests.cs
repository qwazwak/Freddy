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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfanityFilterTools.Interfaces;

namespace ProfanityFilterTools.Tests.Unit;

[TestClass]
public class ProfanityTests
{
    [TestMethod]
    public void ConstructorSetsAllowList()
    {
        IProfanityFilter filter = new ProfanityFilter();
        Assert.IsNotNull(filter.AllowList);
    }

    [TestMethod]
    public void IsProfanityReturnsTrueForSwearWord()
    {
        ProfanityFilter filter = new();
        Assert.IsTrue(filter.IsProfanity("arsehole"));
    }

    [TestMethod]
    public void IsProfanityReturnsTrueForSwearWord2()
    {
        ProfanityFilter filter = new();
        Assert.IsTrue(filter.IsProfanity("shitty"));
    }

    [TestMethod]
    public void IsProfanityReturnsFalseForNonSwearWord()
    {
        ProfanityFilter filter = new();
        Assert.IsFalse(filter.IsProfanity("fluffy"));
    }

    [TestMethod]
    public void IsProfanityReturnsFalseForEmptyString()
    {
        ProfanityFilter filter = new();
        Assert.IsFalse(filter.IsProfanity(string.Empty));
    }

    [TestMethod]
    public void IsProfanityReturnsFalseForNullString()
    {
        ProfanityFilter filter = new();
        Assert.IsFalse(filter.IsProfanity(null!));
    }

    [TestMethod]
    public void IsProfanityReturnsFalseForWordOnTheAllowList()
    {
        ProfanityFilter filter = new();
        Assert.IsTrue(filter.IsProfanity("shitty"));

        filter.AllowList.Add("shitty");

        Assert.IsFalse(filter.IsProfanity("shitty"));
    }

    [TestMethod]
    public void IsProfanityReturnsFalseForWordOnTheAllowListWithMixedCase()
    {
        ProfanityFilter filter = new();
        Assert.IsTrue(filter.IsProfanity("shitty"));

        filter.AllowList.Add("shitty");

        Assert.IsFalse(filter.IsProfanity("ShiTty"));
    }

    [TestMethod]
    public void DetectAllProfanitiesReturnsEmptyListForEmptyInput()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities(string.Empty);

        Assert.AreEqual(0, swearList.Count);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturnsNulListForEmptyInput()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities(null!);

        Assert.AreEqual(0, swearList.Count);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns2SwearWords()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("You are a complete twat and a dick.");

        Assert.AreEqual(2, swearList.Count);
        Assert.AreEqual("twat", swearList[1]);
        Assert.AreEqual("dick", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns2SwearWordsWithCommas()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("You are, a complete twat, and a @dick:");

        Assert.AreEqual(2, swearList.Count);
        Assert.AreEqual("twat", swearList[1]);
        Assert.AreEqual("dick", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns2SwearWordsforMixedCase()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("You are a complete tWat and a DiCk.");

        Assert.AreEqual(2, swearList.Count);
        Assert.AreEqual("twat", swearList[1]);
        Assert.AreEqual("dick", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns1SwearPhrase()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("2 girls 1 cup is my favourite video");

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("2 girls 1 cup", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns3SwearPhrase()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("2 girls 1 cup is my favourite twatting video");

        Assert.AreEqual(2, swearList.Count);
        Assert.AreEqual("2 girls 1 cup", swearList[0]);
        Assert.AreEqual("twatting", swearList[1]);
    }

    [TestMethod]
    public void DetectAllProfanitiesReturns2SwearPhraseBecauseOfMatchDeduplication()
    {
        ProfanityFilter filter = new();
        var swearList = filter.DetectAllProfanities("2 girls 1 cup is my favourite twatting video", true);

        Assert.AreEqual(2, swearList.Count);
        Assert.AreEqual("2 girls 1 cup", swearList[0]);
        Assert.AreEqual("twatting", swearList[1]);
    }

    [TestMethod]
    public void DetectAllProfanitiesScunthorpe()
    {
        ProfanityFilter filter = new();
        filter.AllowList.Add("scunthorpe");
        filter.AllowList.Add("penistone");

        var swearList = filter.DetectAllProfanities("I fucking live in Scunthorpe and it is a shit place to live. I would much rather live in penistone you great big cock fuck.");

        Assert.AreEqual(4, swearList.Count);
        Assert.AreEqual("fucking", swearList[0]);
        Assert.AreEqual("cock", swearList[1]);
        Assert.AreEqual("fuck", swearList[2]);
        Assert.AreEqual("shit", swearList[3]);
    }

    [TestMethod]
    public void DetectAllProfanitiesBlocksAllowlist()
    {
        ProfanityFilter filter = new();
        filter.AllowList.Add("tit");

        var swearList = filter.DetectAllProfanities("You are a complete twat and a total tit.", true);

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("twat", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesScunthorpeWithDuplicatesTurnedOff()
    {
        ProfanityFilter filter = new();
        filter.AllowList.Add("scunthorpe");
        filter.AllowList.Add("penistone");

        var swearList = filter.DetectAllProfanities("I fucking live in Scunthorpe and it is a shit place to live. I would much rather live in penistone you great big cock fuck.", true);

        Assert.AreEqual(3, swearList.Count);
        Assert.AreEqual("cock", swearList[1]);
        Assert.AreEqual("fucking", swearList[0]);
        Assert.AreEqual("shit", swearList[2]);
    }

    [TestMethod]
    public void DetectAllProfanitiesScunthorpeWithDuplicatesTurnedOffAndNoAllowList()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("I fucking live in Scunthorpe and it is a shit place to live. I would much rather live in penistone you great big cock fuck.", true);

        Assert.AreEqual(3, swearList.Count);
        Assert.AreEqual("cock", swearList[1]);
        Assert.AreEqual("fucking", swearList[0]);
        Assert.AreEqual("shit", swearList[2]);
    }

    [TestMethod]
    public void DetectAllProfanitiesMultipleScunthorpes()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("Scunthorpe Scunthorpe", true);

        Assert.AreEqual(0, swearList.Count);
    }

    [TestMethod]
    public void DetectAllProfanitiesMultipleScunthorpesSingleCunt()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("Scunthorpe cunt Scunthorpe", true);

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("cunt", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesMultipleScunthorpesMultiCunt()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("Scunthorpe cunt Scunthorpe cunt", true);

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("cunt", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesScunthorpePenistone()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("ScUnThOrPePeNiStOnE", true);

        Assert.AreEqual(0, swearList.Count);
    }

    [TestMethod]
    public void DetectAllProfanitiesScunthorpePenistoneOneKnob()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("ScUnThOrPePeNiStOnE KnOb", true);

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("knob", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesLongerSentence()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("You are a stupid little twat, and you like to blow your load in an alaskan pipeline.", true);

        Assert.AreEqual(4, swearList.Count);
        Assert.AreEqual("alaskan pipeline", swearList[0]);
        Assert.AreEqual("blow your load", swearList[1]);
        Assert.AreEqual("stupid", swearList[2]);
        Assert.AreEqual("twat", swearList[3]);
    }

    [TestMethod]
    public void DetectAllProfanitiesForSingleWord()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("cock", true);

        Assert.AreEqual(1, swearList.Count);
        Assert.AreEqual("cock", swearList[0]);
    }

    [TestMethod]
    public void DetectAllProfanitiesForEmptyString()
    {
        ProfanityFilter filter = new();

        var swearList = filter.DetectAllProfanities("", true);

        Assert.AreEqual(0, swearList.Count);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut()
    {
        ProfanityFilter filter = new();
        filter.AllowList.Add("scunthorpe");
        filter.AllowList.Add("penistone");

        var censored = filter.CensorString("I fucking live in Scunthorpe and it is a shit place to live. I would much rather live in penistone you great big cock fuck.", '*');
        var result = "I ******* live in Scunthorpe and it is a **** place to live. I would much rather live in penistone you great big **** ****.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOutNoAllowList()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("I fucking live in Scunthorpe and it is a shit place to live. I would much rather live in penistone you great big cock fuck.", '*');
        var result = "I ******* live in Scunthorpe and it is a **** place to live. I would much rather live in penistone you great big **** ****.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOutNoAllowListMixedCase()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("I Fucking Live In Scunthorpe And It Is A Shit Place To Live. I Would Much Rather Live In Penistone You Great Big Cock Fuck.", '*');
        var result = "I ******* Live In Scunthorpe And It Is A **** Place To Live. I Would Much Rather Live In Penistone You Great Big **** ****.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut2()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("2 girls 1 cup, is my favourite twatting video.");
        var result = "* ***** * ***, is my favourite ******** video.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut3()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("Mary had a little shit lamb who was a little fucker.");
        var result = "Mary had a little **** lamb who was a little ******.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut4()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a stupid little twat, and you like to blow your load in an alaskan pipeline.");
        var result = "You are a ****** little ****, and you like to **** **** **** in an ******* ********.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithSingleScunthorpe()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("Scunthorpe");
        var result = "Scunthorpe";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithSingleScunthorpeMixedCase()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("ScUnThOrPe");
        var result = "ScUnThOrPe";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithSingleScunthorpeMixedCase2()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("ScUnThOrPePeNiStOnE");
        var result = "ScUnThOrPePeNiStOnE";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithSingleScunthorpeAllLower()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("scunthorpe");
        var result = "scunthorpe";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringDoubleCunt()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("cunt cunt");
        var result = "**** ****";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithScunthorpeBasedDoubleCunt()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("scunthorpe cunt");
        var result = "scunthorpe ****";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithDoubleScunthorpeBasedDoubleCunt()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("scunthorpe scunthorpe cunt");
        var result = "scunthorpe scunthorpe ****";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithMultiScunthorpeBasedMultiCunt()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("cunt scunthorpe cunt scunthorpe cunt");
        var result = "**** scunthorpe **** scunthorpe ****";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut2WithDifferentCharacter()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("2 girls 1 cup, is my favourite twatting video.", '@');
        var result = "@ @@@@@ @ @@@, is my favourite @@@@@@@@ video.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut2WithSlashes()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("2 girls 1 cup, is my favourite twatting video.", '/');
        var result = "/ ///// / ///, is my favourite //////// video.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut2WithQuotes()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("2 girls 1 cup, is my favourite twatting video.", '\"');
        var result = "\" \"\"\"\"\" \" \"\"\", is my favourite \"\"\"\"\"\"\"\" video.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithProfanitiesBleepedOut2WithExclaimationMark()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("2 girls 1 cup, is my favourite twatting video.", '!');
        var result = "! !!!!! ! !!!, is my favourite !!!!!!!! video.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsEmptyString()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("", '@');
        var result = "";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsStringWithNoCensorship()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("Hello, I am a fish.", '*');
        var result = "Hello, I am a fish.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringWithTrailingSpace()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("Hello you little fuck ");
        var result = "Hello you little **** ";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringThatIsOnlySpaces()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("     ");
        var result = "     ";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringThatisOnlyNonAlphaNumericCharacters()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("!@£$*&^&$%^$£%£$@£$£@$£$%%^");
        var result = "!@£$*&^&$%^$£%£$@£$£@$£$%%^";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a motherfucker1", '*', true);
        var result = "You are a *************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker2()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a motherfucker123", '*', true);
        var result = "You are a ***************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker3()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a 1motherfucker", '*', true);
        var result = "You are a *************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker4()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a 123motherfucker", '*', true);
        var result = "You are a ***************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker5()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a 123motherfucker123", '*', true);
        var result = "You are a ******************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker6()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("motherfucker1", '*', true);
        var result = "*************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker7()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("motherfucker1  ", '*', true);
        var result = "*************  ";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker8()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("  motherfucker1", '*', true);
        var result = "  *************";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker9()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("  motherfucker1  ", '*', true);
        var result = "  *************  ";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker10()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a motherfucker1 and a fucking twat3.", '*', true);
        var result = "You are a ************* and a ******* *****.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker11()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("You are a motherfucker1 and a 'fucking twat3'.", '*', true);
        var result = "You are a ************* and a '******* *****'.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringMotherfucker12()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("I've had 10 beers, and you are a motherfucker1 and a 'fucking twat3'.", '*', true);
        var result = "I've had 10 beers, and you are a ************* and a '******* *****'.";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void CensoredStringReturnsCensoredStringonEmptytString()
    {
        ProfanityFilter filter = new();

        var censored = filter.CensorString("");
        var result = "";

        Assert.AreEqual(censored, result);
    }

    [TestMethod]
    public void GetCompleteWordReturnsScunthorpeRangeMidSentence()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("I live in Scunthorpe and it is full of twats", "cunt");

        Assert.AreEqual(result.Value.Item1, 10);
        Assert.AreEqual(result.Value.Item2, 20);
        Assert.AreEqual(result.Value.Item3, "scunthorpe");
    }

    [TestMethod]
    public void GetCompleteWordReturnsScunthorpeRangeAtStartOfSentence()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("Scunthorpe is my favourite place and it is full of cunts.", "cunt");

        Assert.AreEqual(result.Value.Item1, 0);
        Assert.AreEqual(result.Value.Item2, 10);
        Assert.AreEqual(result.Value.Item3, "scunthorpe");
    }

    [TestMethod]
    public void GetCompleteWordReturnsScunthorpeRangeAtEndOfSentence()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("I totally hate living in Scunthorpe.", "cunt");

        Assert.AreEqual(result.Value.Item1, 25);
        Assert.AreEqual(result.Value.Item2, 35);
        Assert.AreEqual(result.Value.Item3, "scunthorpe");
    }

    [TestMethod]
    public void GetCompleteWordReturnsScunthorpeRangeAtEndOfSentenceNoFullStop()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("I totally hate living in Scunthorpe", "cunt");

        Assert.AreEqual(result.Value.Item1, 25);
        Assert.AreEqual(result.Value.Item2, 35);
        Assert.AreEqual(result.Value.Item3, "scunthorpe");
    }

    [TestMethod]
    public void GetCompleteWordReturnsCuntFromMidSentence()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("You are a cunt flap.", "cunt");

        Assert.AreEqual(result.Value.Item1, 10);
        Assert.AreEqual(result.Value.Item2, 14);
        Assert.AreEqual(result.Value.Item3, "cunt");
    }

    [TestMethod]
    public void GetCompleteWordReturnsCuntFromSingleWordString()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("cunt", "cunt");

        Assert.AreEqual(result.Value.Item1, 0);
        Assert.AreEqual(result.Value.Item2, 4);
        Assert.AreEqual(result.Value.Item3, "cunt");
    }

    [TestMethod]
    public void GetCompleteWordReturnsCuntFromSingleWordStringDoubleCunt()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("cunt cunt", "cunt");

        Assert.AreEqual(result.Value.Item1, 0);
        Assert.AreEqual(result.Value.Item2, 4);
        Assert.AreEqual(result.Value.Item3, "cunt");
    }

    [TestMethod]
    public void GetCompleteWordReturnsNullIfWordNotFound()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("I am a banana and I like to jump.", "cunt");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void GetCompleteWordReturnsNullIfEmptyInputString()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord("", "cunt");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void GetCompleteWordReturnsNullIfNullInputString()
    {
        ProfanityFilter filter = new();
        var result = filter.GetCompleteWord(null!, "cunt");

        Assert.IsNull(result);
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow("  ")]
    public void ContainsProfanityReturnsFalseIfNullOrEmptyInputString(string input)
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity(input);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsTrueWhenProfanityExists()
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity("Scunthorpe");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsTrueWhenMultipleProfanitiesExist()
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity("Scuntarsefuckhorpe");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsFalseWhenMultipleProfanitiesExistAndAreAllowed()
    {
        ProfanityFilter filter = new();
        filter.AllowList.Add("cunt");
        filter.AllowList.Add("arse");

        var result = filter.ContainsProfanity("Scuntarsehorpe");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsFalseWhenProfanityDoesNotExist()
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity("Ireland");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsFalseWhenProfanityIsAaa()
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity("aaa");

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ContainsProfanityReturnsTrueWhenProfanityIsADollarDollar()
    {
        ProfanityFilter filter = new();
        var result = filter.ContainsProfanity("a$$");

        Assert.IsTrue(result);
    }
}