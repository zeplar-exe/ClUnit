namespace ClUnit.Runner;

public static class FormattedOutput
{
    public static void Plain(object o)
    {
        Console.WriteLine(o);
    }
    
    public static void Plain(string format, params object[] items)
    {
        Console.WriteLine(format, items);
    }
}