using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            GetListOfTestCaseSourceTestCases();

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

        /* This method returns a list of all test cases returned by TestCaseSource methods. */
        private List<string> GetListOfTestCaseSourceTestCases()
        {
            var implementedTests = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();

            var allTypes = assembly?.GetTypes();

            var fixture = allTypes.Where(x => x.GetCustomAttributes(typeof(TestFixtureAttribute)).Count() > 0).First();

            var allMethods = allTypes.Where(t => t.BaseType == typeof(Tests)).SelectMany(t => t.GetMethods());

            TestContext.Progress.WriteLine($"found {allMethods.Count()} methods: ");

            foreach (var method in allMethods)
            {
                TestContext.Progress.WriteLine("method: {0}", method.Name);

                var sourceAttributes = method.GetCustomAttributes(typeof(TestCaseSourceAttribute)) as IEnumerable<TestCaseSourceAttribute>;

                foreach (var sourceAttribute in sourceAttributes)
                {
                    TestContext.Progress.WriteLine(sourceAttribute.SourceName);

                    var sourceName = sourceAttribute.SourceName;
                    if (!string.IsNullOrEmpty(sourceName))
                    {
                        var source = fixture.GetMethod(sourceName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

                        var result = (IEnumerable<TestCaseData>)source.Invoke(null, new object[] { });
                        foreach (var item in result)
                        {
                            implementedTests.Add(item.TestName);
                        }
                    }
                }
            }

            TestContext.Progress.WriteLine($"implementedTests: {string.Join(", ", implementedTests.ToArray())}");

            return implementedTests;
        }  
    }
}
