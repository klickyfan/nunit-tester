using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTester
{
    class GrinchTests : Tests
    {
        [Test]
        [TestCaseSource("TestWithNoArgumentsTestCaseData")]
        public void TestWithNoArguments()
        {
            TestContext.Progress.WriteLine("In GrinchTests:Test1!");

            Assert.AreEqual(1, 1);
        }

        [Test]
        [TestCaseSource("TestWithTwoArgumentsTestCaseData")]
        public void TestWithTwoArguments(int argument0, string argument1)
        {
            TestContext.Progress.WriteLine("In GrinchTests:Test2!");

            Assert.AreEqual(1, 1);
        }

        private static IEnumerable<TestCaseData> TestWithNoArgumentsTestCaseData()
        {
            yield return new TestCaseData().SetName("TestWithNoArguments, Case 0");

            yield return new TestCaseData().SetName("TestWithNoArguments, Case 1");
        }

        private static IEnumerable<TestCaseData> TestWithTwoArgumentsTestCaseData()
        {
            yield return new TestCaseData(0, "test string 0").SetName("TestWithTwoArguments, Case 0");

            yield return new TestCaseData(1, "test string 1").SetName("TestWithTwoArguments, Case 1");
        }
    }
}
