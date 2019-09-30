using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTester
{
    class FlameTests : Tests
    {
        [Test]
        [TestCaseSource("Test1TestCaseData")]
        public void Test1()
        {
            TestContext.Progress.WriteLine("In FlameTests:Test1!");

            Assert.AreEqual(1, 1);
        }

        [Test]
        [TestCaseSource("Test2TestCaseData")]
        public void Test2()
        {
            TestContext.Progress.WriteLine("In FlameTests:Test2!");

            // should fail!
            Assert.AreEqual(1, 2);
        }

        private static IEnumerable<TestCaseData> Test1TestCaseData()
        {
            yield return new TestCaseData().SetName("Test 1, Case 1");

            yield return new TestCaseData().SetName("Test 1, Case 2");
        }

        private static IEnumerable<TestCaseData> Test2TestCaseData()
        {
            yield return new TestCaseData().SetName("Test 2, Case 1");

            yield return new TestCaseData().SetName("Test 2, Case 2");
        }
    }
}
