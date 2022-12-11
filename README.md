# ClUnit

ClUnit is a unit testing framework for command line interfaces (CLIs) written in C#. 
With ClUnit, you can easily create and run unit tests for your CLIs, ensuring that 
they are reliable and perform as expected.

## Features

- Easy to use, intuitive syntax for defining and running tests.
- Support for asserting the expected output and return code of your CLI.
- Cross-platform compatibility (Windows, macOS, and Linux).

## Getting Started

Like other testing frameworks, ClUnit uses attributed methods for tests;

### Via Nuget

If using the [nuget package](...):

```cs
namespace ClExample;

public class MyTestClass
{
    [CliTest]
    public void Test()
    {
        CommandLine.AssertSuccess("git init");
    }
}
```

From here, you are reccomended to create a Debug task in your project:

```msbuild
<Target Name="AfterBuild" Condition="'$(Configuration)' == 'Debug'">
    <Exec WorkingDirectory="$(OutDir)" Command="./ClUnit $(TargetPath)"/>
</Target>
```

Which will run your tests after every build.

### Via Executable

If you install it directly, use your desired [release excutable](https://github.com/zeplar-exe/ClUnit/releases/):

```bash
> ./ClUnit <MyAssemblyPath>.dll
```
