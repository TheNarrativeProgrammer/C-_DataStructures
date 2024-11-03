using System;

namespace VFS.GD.TestFramework
{
    /// <summary>
    /// Contains helper functions to display the results of multiple tests.
    /// </summary>
    class TestOutput
    {
        /// <summary>
        /// Shows a report of tests in the screen.
        /// </summary>
        static public void PrintTestResults(TestGroup[] testGroups)
        {
            int passed = 0;
            int total = 0;
            float passRate = 0;

            foreach (TestGroup group in testGroups)
            {
                PrintTestGroup(group);
                total += group.Tests.Length;
                passed += group.PassCount();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("TEST RESULTS");

            passRate = ((float)passed / (float)total) * 100;
            Console.WriteLine("Passed: " + passed + "/" + total);
            Console.Write("Pass rate: ");
            if (passRate == 100)
            {
                PrintSuccess(passRate.ToString());
            }
            else
            {
                PrintFail(passRate.ToString());
            }
            Console.WriteLine("%");
            if (passRate == 100)
            {
                PrintSuccess("Congratulations! Get yourself a cookie.\n");
            }
        }

        /// <summary>
        /// Show the results of all tests of a certain group
        /// </summary>
        static public void PrintTestGroup(TestGroup group)
        {
            int passed = 0;
            int total = group.Tests.Length;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(group.Name + " test group:");
            foreach (Test test in group.Tests)
            {
                Console.Write("[");
                if (test.Result)
                {
                    passed++;
                    PrintSuccess("PASS");
                }
                else
                {
                    PrintFail("FAIL");
                }
                Console.WriteLine("] " + test.Name);
            }

            Console.WriteLine("\nPassed: " + passed + "/" + total);
            Console.WriteLine("\n------------------------------------------------------------------\n");
        }

        /// <summary>
        /// Prints a message in green.
        /// Will not escape to the next line.
        /// </summary>
        static public void PrintSuccess(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ForegroundColor = currentColor;
        }

        /// <summary>
        /// Prints a message in red.
        /// Will not escape to the next line.
        /// </summary>
        static public void PrintFail(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = currentColor;
        }

    }
}
