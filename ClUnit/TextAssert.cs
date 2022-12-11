using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClUnit;

/// <summary>
/// Various testing assertions for strings (primarily CMD output).
/// </summary>
public static class TextAssert
{
    /// <summary>
    /// Assert whether two strings are equal.
    /// </summary>
    public static void IsEqualTo(this string text, string other)
    {
        AssertCondition(() => text == other);
    }

    /// <summary>
    /// Assert whether the input string matches a Regex object.
    /// </summary>
    public static void MatchesFormat(this string text, Regex regex)
    {
        AssertCondition(() => regex.Match(text).Success);
    }
    
    /// <summary>
    /// Assert whether the input string matches a Regex pattern.
    /// </summary>
    public static void MatchesFormat(this string text, string regexPattern)
    {
        AssertCondition(() => Regex.Match(text, regexPattern).Success);
    }

    /// <summary>
    /// Assert whether the input string contains another string.
    /// </summary>
    public static void Contains(this string text, string other)
    {
        AssertCondition(() => text.Contains(other));
    }

    /// <summary>
    /// Assert whether the input string contains all of the given strings.
    /// </summary>
    public static void ContainsAll(this string text, string[] texts)
    {
        AssertCondition(() => texts.All(text.Contains));
    }

    /// <summary>
    /// Assert whether minLength &lt; stringLength &lt; maxLength.
    /// </summary>
    public static void WithinBounds(this string text, int minLength, int maxLength)
    {
        AssertCondition(() => text.Length >= minLength);
        AssertCondition(() => text.Length <= maxLength);
    }

    /// <summary>
    /// Assert whether the input string's length is larger than the given length.
    /// </summary>
    public static void AboveLength(this string text, int length)
    {
        AssertCondition(() => text.Length > length);
    }

    /// <summary>
    /// Assert whether the input string's length is smaller than the given length.
    /// </summary>
    public static void BelowLength(this string text, int length)
    {
        AssertCondition(() => text.Length < length);
    }

    private static void AssertCondition(Func<bool> func)
    {
        if (!func.Invoke())
            BasicAssert.Failure();
    }
}