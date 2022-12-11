using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ClUnit;

public static partial class CommandLine
{
    private static string? WorkingDirectory { get; set; }
    private static TimeSpan CommandTimeout { get; set; }

    static CommandLine()
    {
        CommandTimeout = TimeSpan.FromMilliseconds(5000);
    }
    
    public static void UseWorkingDirectory(string directory)
    {
        WorkingDirectory = directory;
    }

    public static void UseCommandTimeout(TimeSpan time)
    {
        CommandTimeout = time;
    }
    
    public static CommandResult RunCommand(string command)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                WorkingDirectory = WorkingDirectory ?? Directory.GetCurrentDirectory(),
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };
        
        process.Start();
        
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit(CommandTimeout.Milliseconds);
        
        return new CommandResult(output, process.ExitCode);
    }

    public record CommandResult(string Output, int Code);
}