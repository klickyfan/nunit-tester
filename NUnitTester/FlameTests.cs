using NUnit.Framework;

namespace NUnitTester
{
    class FlameTests : Tests
    {
        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("In FlameTests:Test1!");

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("In FlameTests:Test2!");

            Assert.AreEqual(1, 2);
        }
    }
}
