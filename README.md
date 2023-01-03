## This project has been discontinued

# ClUnit

ClUnit is an NUnit extension for command line interfaces (CLIs). 
With ClUnit, you can easily create and run unit tests for your CLIs, ensuring that 
they are reliable and perform as expected.

## Features

- Support for asserting the expected output and return code of your CLI.

## Getting Started

When using the [nuget package](...):

```cs
using NUnit;
using ClUnit;

namespace ClExample;

public class MyTestClass
{
    [Test]
    public void Test()
    {
        CommandLine.AssertSuccess("git init");
    }
}
```
