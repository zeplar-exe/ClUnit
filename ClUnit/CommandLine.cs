using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ClUnit;

public static partial class CommandLine
{
    public static TimeSpan CommandTimeout { get; set; } = TimeSpan.FromMilliseconds(5000);

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