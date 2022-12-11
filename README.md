# ClUnit

ClUnit is a unit testing framework for command line interfaces (CLIs) written in C#. 
With ClUnit, you can easily create and run unit tests for your CLIs, ensuring that 
they are reliable and perform as expected.

## Features

- Easy to use, intuitive syntax for defining and running tests.
- Support for asserting the expected output and return code of your CLI.
- Cross-platform compatibility (Windows, macOS, and Linux).

## Getting Started

Simply install the [nuget package](...).

Like other testing frameworks, ClUnit uses attributed methods for tests;

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

To use it, call the release excutable:

```bash
> ./ClUnit <MyAssemblyPath>.dll
```
