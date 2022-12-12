using System.Reflection;

using ClUnit;
using ClUnit.Runner;

using CommandDotNet;

internal class Program
{
    public static int Main(string[] args)
    {
        return new AppRunner<Program>().Run(args);
    }

    [DefaultCommand]
    public int Execute(string filePath, 
        [Option('v', "verbose")] bool verbose = false,
        [Option('q', "quiet")] bool quiet = false,
        [Option("simpleResult")] bool simpleResult = false)
    {
        if (quiet)
            verbose = false;
        
        var absolutePath = GetAbsolutePath(filePath);
        
        if (!File.Exists(absolutePath))
        {
            FormattedOutput.Plain(OutputMessages.FileNotFound, filePath);

            return 1;
        }

        Assembly assembly;

        try
        {
            assembly = Assembly.LoadFrom(absolutePath);
        }
        catch (Exception e)
        {
            FormattedOutput.Plain(OutputMessages.AssemblyLoadFailure, CreateExceptionMessage(e));

            return 1;
        }        

        if (Assembly.GetAssembly(typeof(CliTestAttribute)) == null)
        {
            FormattedOutput.Plain(OutputMessages.InvalidAssembly);

            return 1;
        }

        var succeeded = 0;
        var failed = 0;
        var skipped = 0;
        
        foreach (var type in assembly.GetTypes())
        {
            foreach (var method in type.GetMethods())
            {
                var attribute = method.GetCustomAttribute<CliTestAttribute>();

                if (attribute == null)
                    continue;

                object? instance = null;

                if ((method.Attributes & MethodAttributes.Static) == 0)
                {
                    try
                    {
                        instance = Activator.CreateInstance(type);
                    }
                    catch (Exception e)
                    {
                        if (verbose)
                        {
                            FormattedOutput.Plain(
                                OutputMessages.CreationException,
                                FullMethodName(method), CreateExceptionMessage(e));
                        }

                        skipped++;
                        
                        continue;
                    }
                }

                try
                {
                    method.Invoke(instance, null);

                    if (verbose)
                    {
                        FormattedOutput.Plain(OutputMessages.TestSuccess, FullMethodName(method));
                        Console.WriteLine();
                    }

                    succeeded++;
                }
                catch (Exception e)
                {
                    if (e.InnerException is not AssertFailedException)
                        throw; // See https://stackoverflow.com/a/27242130/16324801

                    if (verbose)
                    {
                        FormattedOutput.Plain(OutputMessages.TestFailure, FullMethodName(method));
                    }

                    failed++;
                }
            }
        }

        if (simpleResult)
        {
            FormattedOutput.Plain(succeeded);
            FormattedOutput.Plain(failed);
            FormattedOutput.Plain(skipped);
        }
        else if (!quiet)
        {
            FormattedOutput.Plain(OutputMessages.RunResult, succeeded, failed, skipped);
        }

        return 0;
    }

    private string CreateExceptionMessage(Exception exception)
    {
        return $"[{exception.GetType().Name}] {exception.Message}";
    }

    private string FullMethodName(MethodInfo info)
    {
        return (info.DeclaringType?.FullName ?? "null") + "." + info.Name;
        // I hate operator precedence
    }

    private string GetAbsolutePath(string path)
    {
        if (Path.IsPathRooted(path) || Path.IsPathFullyQualified(path))
            return path;

        return Path.Join(Directory.GetCurrentDirectory(), path);
    }
}