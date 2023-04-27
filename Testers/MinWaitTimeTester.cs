namespace Challenges.Testers
{
    public static class MinWaitTimeTester
    {
        private static readonly List<int> t1 = new() { 17, 4, 3 };
        private const int R1 = 10;
        private static readonly List<int> t2 = new() { 7 };
        private const int R2 = 0;
        private static readonly List<int> t3 = new() { 9, 10 };
        private const int R3 = 9;
        private static readonly List<int> t4 = new() { 10, 9 };
        private const int R4 = 9;
        private static readonly List<int> t5 = new() { 1, 2, 3, 4 };
        private const int R5 = 10;
        private static readonly List<int> t6 = new() { 4, 3, 2, 1 };
        private const int R6 = 10;
        private static readonly List<int> t7 = new() { 5, 1, 22 };
        private const int R7 = 7;
        private static readonly List<int> t8 = new() { 1, 1, 1, 2, 1, 1, 4, 1, 8, 5, 6 };
        private const int R8 = 81;

        private static readonly List<List<int>> tests = new() { t1, t2, t3, t4, t5, t6, t7, t8 };
        private static readonly List<int> expected = new() { R1, R2, R3, R4, R5, R6, R7, R8 };

        public static void Run()
        {
            Console.WriteLine("Running MinWaitTime tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $"queries: {ResultBuilder.ConvertToString(tests[i])}", Challenge.MinWaitTime(tests[i]), expected[i]));
            }
            results.ForEach(result => result.Print());
        }
    }
}
