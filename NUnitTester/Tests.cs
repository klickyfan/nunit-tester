using NUnit.Framework;

namespace NUnitTester
{
    [TestFixture]
    class Tests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            TestContext.Progress.WriteLine("Entering Tests:SetUp!");

            TestContext.Progress.WriteLine($"_testString = {_testString}");
            TestContext.Progress.WriteLine($"TestString = {TestString}");

            TestContext.Progress.WriteLine("Leaving Tests:SetUp!");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("In Tests:TearDown!");
        }

        // OneTimeSetUp/OneTimeTearDown methods placed here will be called multiple times, before/after 
        // the tests in each of the subclasses of the Tests class.

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.Progress.WriteLine("In Tests:OneTimeSetUp!");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestContext.Progress.WriteLine("In Tests:OneTimeTearDown!");
        }
    }
}
