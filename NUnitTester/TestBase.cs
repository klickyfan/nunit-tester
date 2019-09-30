using NUnit.Framework;

namespace NUnitTester
{
    [SingleThreaded]
    class TestBase
    {
        protected string _testString;
        protected static string TestString;

        public TestBase()
        {
            // This constructor shall remain unused since, per NUnit documentation: "it is advisable
            // that [a TestFixture] constructor not have any side effects, since NUnit may construct
            // object multiple times in the course of a session."
        }
    }
}
