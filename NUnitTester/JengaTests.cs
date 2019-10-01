using NUnit.Framework;

namespace NUnitTester
{
    class JengaTests : Tests
    {
        [Test]
        [TestCase(0, "test string 0")]
        [TestCase(1, "test string 1")]
        public void TestA(int argument0, string argument1)
        {
            TestContext.Progress.WriteLine("Entering JengaTests:TestA!");

            TestContext.Progress.WriteLine($"_testString = {_testString}");
            TestContext.Progress.WriteLine($"TestString = {TestString}");

            Assert.AreEqual(1, 1);

            TestContext.Progress.WriteLine("Leaving JengaTests:TestA!");
        }

        [Test]
        public void TestB()
        {
            TestContext.Progress.WriteLine("In JengaTests:TestB!");

            Assert.AreEqual(1, 1);
        }
    }
}
