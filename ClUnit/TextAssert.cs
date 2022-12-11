using System.Text.RegularExpressions;

namespace ClUnit;

public static class TextAssert
{
    public static void IsEqualTo(this string text, string other)
    {
        AssertCondition(() => text == other);
    }

    public static void MatchesFormat(this string text, Regex regex)
    {
        AssertCondition(() => regex.Match(text).Success);
    }
    
    public static void MatchesFormat(this string text, string regexPattern)
    {
        AssertCondition(() => Regex.Match(text, regexPattern).Success);
    }

    public static void Contains(this string text, string other)
    {
        AssertCondition(() => text.Contains(other));
    }

    public static void ContainsAll(this string text, string[] texts)
    {
        AssertCondition(() => texts.All(text.Contains));
    }

    public static void WithinBounds(this string text, int minLength, int maxLength)
    {
        AssertCondition(() => text.Length >= minLength);
        AssertCondition(() => text.Length <= maxLength);
    }

    public static void AboveLength(this string text, int length)
    {
        AssertCondition(() => text.Length > length);
    }

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