using System;
using System.Collections.Generic;
using NUnitLite;

namespace NUnitTester
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine($"Running tests...");

            List<string> nunitliteArgs = new List<string>();

            // comment in if you want the tester to stop after the first error
            // nunitliteArgs.Add($"--stoponerror");

            return new AutoRun().Execute(nunitliteArgs.ToArray());
        }
    }
}
