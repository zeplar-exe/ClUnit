﻿namespace ClUnit;

/// <summary>
/// Low-level assert operations.
/// </summary>
public static class BasicAssert
{
    /// <summary>
    /// Does nothing, only here for show.
    /// </summary>
    public static void Success()
    {
        
    }
    
    /// <summary>
    /// Throws an <see cref="AssertFailedException"/>.
    /// </summary>
    public static void Failure()
    {
        throw new AssertFailedException();
    }

    /// <summary>
    /// Asserts whether a given predicate is true.
    /// </summary>
    public static void That(Func<bool> predicate)
    {
        if (!predicate.Invoke())
            Failure();
    }
    
    /// <summary>
    /// Asserts whether a given boolean is true.
    /// </summary>
    public static void That(bool b)
    {
        if (!b)
            Failure();
    }
}