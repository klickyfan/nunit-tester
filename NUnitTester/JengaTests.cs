using NUnit.Framework;

namespace NUnitTester
{
    class JengaTests : Tests
    {
        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Entering JengaTests:Test1!");

            TestContext.Progress.WriteLine($"_testString = {_testString}");
            TestContext.Progress.WriteLine($"TestString = {TestString}");

            Assert.AreEqual(1, 1);

            TestContext.Progress.WriteLine("Leaving JengaTests:Test1!");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("In JengaTests:Test2!");

            Assert.AreEqual(1, 1);
        }
    }
}
