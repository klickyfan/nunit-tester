using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTester
{
    class FlameTests : Tests
    {
        [Test]
        [TestCaseSource("TestATestCaseData")]
        public void TestA()
        {
            TestContext.Progress.WriteLine("In FlameTests:TestA!");

            Assert.AreEqual(1, 1);
        }

        [Test]
        [TestCaseSource("TestBTestCaseData")]
        public void TestB(int argument0, string argument1)
        {
            TestContext.Progress.WriteLine("In FlameTests:TestB!");

            // should fail!
            Assert.AreEqual(1, 2);
        }

        private static IEnumerable<TestCaseData> TestATestCaseData()
        {
            yield return new TestCaseData().SetName("TestA, Case 0");

            yield return new TestCaseData().SetName("TestA, Case 1");
        }

        private static IEnumerable<TestCaseData> TestBTestCaseData()
        {
            yield return new TestCaseData(0, "test string 0").SetName("TestB, Case 0");

            yield return new TestCaseData(1, "test string 1").SetName("TestB, Case 1");
        }
    }
}
