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
            TestContext.Progress.WriteLine("Entering Setup:GetListOfTestCaseSourceTestCases!");

            var implementedTests = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();

            var allTypes = assembly?.GetTypes();

            foreach (var type in allTypes)
            {
                TestContext.Progress.WriteLine($"type = {type.Name} ({type.FullName}, {type.DeclaringType}, {type.GetCustomAttributes(typeof(TestFixtureAttribute)).Count()})");
            }

            var fixtures = allTypes?.Where(x => x.GetCustomAttributes(typeof(TestFixtureAttribute)).Count() > 0);

            foreach (var fixture in fixtures)
            {
                TestContext.Progress.WriteLine($"fixture = {fixture.Name}");

                var allMethods = allTypes.SelectMany(t => t.GetMethods().Where(m => m.DeclaringType == fixture));

                TestContext.Progress.WriteLine($"   found {allMethods.Count()} methods: ");

                foreach (var method in allMethods)
                {
                    TestContext.Progress.WriteLine($"       method = {method.Name}");

                    var sourceAttributes = method.GetCustomAttributes(typeof(TestCaseSourceAttribute)) as IEnumerable<TestCaseSourceAttribute>;

                    foreach (var sourceAttribute in sourceAttributes)
                    {
                        if (!string.IsNullOrEmpty(sourceAttribute.SourceName))
                        {
                            var source = fixture.GetMethod(sourceAttribute.SourceName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

                            var defaultArgumentValues = source.GetParameters().Select(p => GetDefaultValue(p.ParameterType)).ToArray();

                            var result = (IEnumerable<TestCaseData>)source.Invoke(null, defaultArgumentValues);

                            foreach (var item in result)
                            {
                                TestContext.Progress.WriteLine($"         adding {item.TestName}");
                                implementedTests.Add(item.TestName);
                            }

                        }
                    }
                }

            }

            TestContext.Progress.WriteLine($"implementedTests = {string.Join(", ", implementedTests.ToArray())}");

            TestContext.Progress.WriteLine("Exiting Setup:GetListOfTestCaseSourceTestCases!");

            return implementedTests;
        }

        private object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
