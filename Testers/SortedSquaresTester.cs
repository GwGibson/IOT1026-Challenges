namespace Challenges.Testers
{
    public static class SortedSquaresTester
    {
        private static readonly List<int> t1 = new() { 1, 2, 3, 5, 6, 8, 9, 10 };
        private static readonly List<int> r1 = new() { 1, 4, 9, 25, 36, 64, 81, 100 };
        private static readonly List<int> t2 = new() { 1 };
        private static readonly List<int> r2 = new() { 1 };
        private static readonly List<int> t3 = new() { 0 };
        private static readonly List<int> r3 = new() { 0 };
        private static readonly List<int> t4 = new() { -1 };
        private static readonly List<int> r4 = new() { 1 };
        private static readonly List<int> t5 = new() { -5, -4, -3, -2, -1 };
        private static readonly List<int> r5 = new() { 1, 4, 9, 16, 25 };
        private static readonly List<int> t6 = new() { -50, -10, -2, -1, 0, 0, 1, 1, 5, 19, 22 };
        private static readonly List<int> r6 = new() { 0, 0, 1, 1, 1, 4, 25, 100, 361, 484, 2500 };
        private static readonly List<int> t7 = new() { 0, 0, 0, 0, 0 };
        private static readonly List<int> r7 = new() { 0, 0, 0, 0, 0 };

        private static readonly List<List<int>> tests = new() { t1, t2, t3, t4, t5, t6, t7 };
        private static readonly List<List<int>> expected = new() { r1, r2, r3, r4, r5, r6, r7 };

        public static void Run()
        {
            Console.WriteLine("Running SortedSquares tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $"list: {ResultBuilder.ConvertToString(tests[i])}", Challenge.SortedSquares(tests[i]), expected[i]));
            }
            results.ForEach(result => result.Print());
        }
    }
}
