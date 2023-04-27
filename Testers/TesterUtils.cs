using System.Text;

namespace Challenges.Testers
{
    class Result
    {
        private int TestNo { get; }
        private string Input { get; }
        private string? Output { get; }
        private string? Expected { get; }
        private bool Passed { get; }

        /**
         * Initializes a new instance of the Result class with the given test number, input, output, and expected values.
         * Throws an IllegalArgumentException if the test number is less than 1.
         */
        public Result(int testNo, string input, string? output = null, string? expected = null)
        {
            if (testNo < 1)
            {
                throw new ArgumentException($"A test number of {testNo} is invalid. The test number should be >= 1.");
            }

            TestNo = testNo;
            Input = input;
            Output = output;
            Expected = expected;
            Passed = output == null;
        }

        /**
         * Prints the test result to the console in a formatted manner.
         * Indicates if the test passed or failed and displays the input, expected output, and actual output.
         */
        public void Print()
        {
            string resultString = Passed
                ? $"Test {TestNo}: PASSED - Input: {Input}"
                : $"Test {TestNo}: FAILED - Input: {Input} \n\tExpected Output: {Expected} \n\tYour Output:     {Output}";
            IOHelper.Print(resultString, Passed);
        }

        private static class IOHelper
        {
            private const string ColorRed = "\u001B[31m";
            private const string ColorReset = "\u001B[0m";
            private const string ColorGreen = "\u001B[32m";
            /**
             * Prints the given input to the console with the specified color based on the passed parameter.
             * Green color for passed tests and red color for failed tests.
             */
            public static void Print(string input, bool passed)
            {
                string color = passed ? ColorGreen : ColorRed;
                Console.WriteLine($"{color}{input}{ColorReset}");
            }
        }
    }

    static class ResultBuilder
    {
        /**
        * Builds a Result object based on the given test number, input, output, and expected values.
        * If the output and expected values are equal, initializes the Result object with passed status.
        * Otherwise, initializes the Result object with failed status and includes the output and expected values.
        */
        public static Result BuildResult<T>(int testNo, string input, T output, T expected) where T : IComparable<T>
        {
            return output.Equals(expected)
                ? new Result(testNo, input)
                : new Result(testNo, input, output.ToString(), expected.ToString());
        }

        /**
         * Builds a Result object based on the given test number, input, output, and expected list values.
         * If the output and expected lists match (taking the 'ordered' parameter into account), initializes the Result object with passed status.
         * Otherwise, initializes the Result object with failed status and includes the output and expected list values.
         */
        public static Result BuildResult<T>(int testNo, string input, List<T> output, List<T> expected, bool ordered = true) where T : IComparable<T>
        {
            return Verify(output, expected, ordered)
                ? new Result(testNo, input)
                : new Result(testNo, input, ConvertToString(output), ConvertToString(expected));
        }

        /**
         * Builds a Result object based on the given test number, input, output, and a list of expected lists.
         * If the output matches any of the expected lists (taking the 'ordered' parameter into account), initializes the Result object with passed status.
         * Otherwise, initializes the Result object with failed status and includes the output and all the possible expected list values.
         */
        public static Result BuildResult<T>(int testNo, string input, List<T> output, List<List<T>> expected, bool ordered = true) where T : IComparable<T>
        {
            if (expected.Any(list => Verify(output, list, ordered)))
            {
                return new Result(testNo, input);
            }

            return new Result(testNo, input, ConvertToString(output), ConvertToString(expected));
        }

        /**
         * Verifies if the output list matches the expected list.
         * Takes into account the 'ordered' parameter to determine if the order of the elements should be considered in the comparison.
         * Returns true if the output list matches the expected list, otherwise returns false.
         */
        private static bool Verify<T>(List<T> output, List<T> expected, bool ordered) where T : IComparable<T>
        {
            return ordered ? output.SequenceEqual(expected) : output.Count == expected.Count && output.All(expected.Contains);
        }

        private static string ConvertToString<T>(List<List<T>> lists)
        {
            StringBuilder sb = new();

            if (lists.Count > 1)
            {
                sb.Append("Any of the following: ");
            }

            foreach (List<T> list in lists)
            {
                sb.Append(ConvertToString(list)).Append(", ");
            }

            return sb.ToString().TrimEnd(',', ' ');
        }

        public static string ConvertToString<T>(List<T> list)
        {
            return '[' + string.Join(", ", list) + ']';
        }
    }
}
