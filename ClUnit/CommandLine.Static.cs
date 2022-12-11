namespace ClUnit;

public partial class CommandLine
{
    public static string Execute(string command)
    {
        return RunCommand(command).Output;
    }

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

    public static string AssertSuccess(string command)
    {
        if (!TryExecute(command, out var output))
            BasicAssert.Failure();

        return output;
    }

    public static string AssertFailure(string command)
    {
        if (TryExecute(command, out var output))
            BasicAssert.Failure();

        return output;
    }

    public static string AssertCode(string command, int code)
    {
        try
        {
            var result = RunCommand(command);

            if (result.Code != code)
                BasicAssert.Failure();

            return result.Output;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            BasicAssert.Failure();
        }

        return string.Empty;
    }
}