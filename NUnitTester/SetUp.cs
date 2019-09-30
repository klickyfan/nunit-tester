using NUnit.Framework;

namespace NUnitTester
{
    [SetUpFixture]
    class SetUp : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestContext.Progress.WriteLine("Entering SetUp:OneTimeSetUp!");

            _testString = "I was initialized in OneTimeSetup!";
            TestString = "I was initialized in OneTimeSetup!";

            TestContext.Progress.WriteLine($"_testString = {_testString}");
            TestContext.Progress.WriteLine($"TestString = {TestString}");

            AssumePrerequisites();

            TestContext.Progress.WriteLine("Leaving SetUp:OneTimeSetUp!");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestContext.Progress.WriteLine("Entering Setup:OneTimeTearDown!");

            TestContext.Progress.WriteLine($"_testString = {_testString}");
            TestContext.Progress.WriteLine($"TestString = {TestString}");

            TestContext.Progress.WriteLine("Leaving Setup:OneTimeTearDown!");
        }

        private void AssumePrerequisites()
        {
            TestContext.Progress.WriteLine("Entering Setup:AssumePrerequisites!");

            Assume.That(1 == 1);

            // comment in if you want the tester to see the tester fail on one bad assumption
            // Assume.That(1 != 1);

            TestContext.Progress.WriteLine("Exiting Setup:AssumePrerequisites!");
        }
    }
}
