using ClUnit;

using NUnit.Framework;

namespace DummySuiteTest;

public class Tests
{
    [Test]
    public void SomeTest()
    {
        CommandLine.AssertFailure("git");
    }
    
    [Test]
    public void SomeTest2()
    {
        CommandLine.AssertSuccess("git");
    }
    
    [Test]
    public void SomeTest3()
    {
        CommandLine.AssertCode("git", 1);
    }
    
    [Test]
    public void SomeTest4()
    {
        CommandLine.AssertFailure("psagjoaiebgak:13tqfs");
    }

    public class Nested
    {
        [Test]
        public void SomeTest()
        {
            CommandLine.AssertSuccess("ls");
        }
    }

    public class Params
    {
        public Params(string something, bool anything)
        {
            
        }

        [Test]
        public void PassedTest()
        {
            CommandLine.AssertSuccess("ls");
        }
    }
}