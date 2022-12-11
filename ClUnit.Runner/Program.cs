using System.Reflection;

using ClUnit;

using CommandDotNet;

internal class Program
{
    public static int Main(string[] args)
    {
        return new AppRunner<Program>().Run(args);
    }

    [DefaultCommand]
    public int Execute(string filePath, [Option('v', "verbose")] bool verbose = false)
    {
        var absolutePath = GetAbsolutePath(filePath);
        
        if (!File.Exists(absolutePath))
        {
            Console.WriteLine($"Expected a file ({filePath} does not exist).");

            return 1;
        }

        Assembly assembly;

        try
        {
            assembly = Assembly.LoadFrom(absolutePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"The assembly could not be opened: [{e.GetType().Name}] {e.Message}");

            return 1;
        }        

        if (Assembly.GetAssembly(typeof(CliTestAttribute)) == null)
        {
            Console.WriteLine("The input assembly does not use ClUnit (or has a differing version).");

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
                        var exceptionMessage = $"[{e.GetType().Name}] {e.Message}";

                        if (verbose)
                        {
                            Console.WriteLine($"Test '{FullMethodName(method)}' will be skipped due to a creation exception: {exceptionMessage}");
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
                        Console.WriteLine($"Test '{FullMethodName(method)}' succeeded.");
                    }

                    succeeded++;
                }
                catch (Exception e)
                {
                    if (e.InnerException is not AssertFailedException)
                        throw; // See https://stackoverflow.com/a/27242130/16324801

                    if (verbose)
                    {
                        Console.WriteLine($"Test '{FullMethodName(method)}' failed.");
                    }

                    failed++;
                }
            }
        }
        
        Console.WriteLine($"Test Run Result: {succeeded} Succeeded, {failed} Failed, {skipped} Skipped");

        return 0;
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