using NUnit.Framework;

namespace ClUnit;

public partial class CommandLine
{
    /// <summary>
    /// Execute a command.
    /// </summary>
    /// <returns>The textual output of the command.</returns>
    public static string Execute(string command)
    {
        return RunCommand(command).Output;
    }

    /// <summary>
    /// Attempt to execute a command, returning true if so and false if not.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="output">The textual output of the command.</param>
    /// <returns>Whether the command threw an exception.</returns>
    public static bool TryExecute(string command, out string output)
    {
        output = string.Empty;

        try
        {
            output = Execute(command);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }

    /// <summary>
    /// Assert that a command runs without encountering an exception.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The textual output of the command.</returns>
    public static string AssertSuccess(string command)
    {
        if (!TryExecute(command, out var output))
            Assert.Fail();

        return output;
    }

    /// <summary>
    /// Assert that a command throws an exception.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The textual output of the command.</returns>
    public static string AssertFailure(string command)
    {
        if (TryExecute(command, out var output))
            Assert.Fail();

        return output;
    }

    /// <summary>
    /// Assert that a command returns a specific exit code.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="code">The expected exit code.</param>
    /// <returns>The textual output of the command.</returns>
    public static string AssertCode(string command, int code)
    {
        var result = RunCommand(command);

        if (result.Code != code)
            Assert.Fail();

        return result.Output;
    }
}