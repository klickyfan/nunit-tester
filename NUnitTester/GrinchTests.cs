using NUnit.Framework;

namespace NUnitTester
{
    class GrinchTests : Tests
    {
        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("In GrinchTests:Test1!");

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("In GrinchTests:Test2!");

            Assert.AreEqual(1, 1);
        }
    }
}
