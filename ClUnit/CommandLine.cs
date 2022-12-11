using System;
using System.Diagnostics;
using System.IO;

namespace ClUnit;

/// <summary>
/// Helper class for invoking commands on the command line.
/// </summary>
public static partial class CommandLine
{
    private static string? WorkingDirectory { get; set; }
    private static TimeSpan CommandTimeout { get; set; }

    static CommandLine()
    {
        CommandTimeout = TimeSpan.FromMilliseconds(5000);
    }
    
    /// <summary>
    /// Set the working directory to be used in any future commands.
    /// </summary>
    /// <param name="directory">The absolute path of the directory to use.</param>
    public static void UseWorkingDirectory(string directory)
    {
        WorkingDirectory = directory;
    }

    /// <summary>
    /// Set the timeout to wait for any future commands to finish.
    /// </summary>
    /// <param name="time">The <see cref="TimeSpan"/> to wait before timing out.</param>
    public static void UseCommandTimeout(TimeSpan time)
    {
        CommandTimeout = time;
    }
    
    /// <summary>
    /// Run a command on a new cmd.exe process.
    /// </summary>
    /// <param name="command">The command to run.</param>
    /// <returns>The output text and error code of the command (in a <see cref="CommandResult"/> object).</returns>
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

    /// <summary>
    /// The result of a command.
    /// </summary>
    /// <param name="Output">Textual output of a command.</param>
    /// <param name="Code">Error/Success code of a command.</param>
    public record CommandResult(string Output, int Code);
}