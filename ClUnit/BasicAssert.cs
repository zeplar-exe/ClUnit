namespace ClUnit;

public static class BasicAssert
{
    public static void Success()
    {
        
    }
    
    public static void Failure()
    {
        throw new AssertFailedException();
    }

    public static void That(Func<bool> predicate)
    {
        if (!predicate.Invoke())
            Failure();
    }
}