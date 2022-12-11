using ClUnit;

namespace DummySuiteTest;

public class Tests
{
    [CliTest]
    public void SomeTest()
    {
        CommandLine.AssertFailure("git");
    }
    
    [CliTest]
    public void SomeTest2()
    {
        CommandLine.AssertSuccess("git");
    }
    
    [CliTest]
    public void SomeTest3()
    {
        CommandLine.AssertCode("git", 1);
    }
    
    [CliTest]
    public void SomeTest4()
    {
        CommandLine.AssertFailure("psagjoaiebgak:13tqfs");
    }

    public class Nested
    {
        [CliTest]
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

        [CliTest]
        public void PassedTest()
        {
            CommandLine.AssertSuccess("ls");
        }
    }
}