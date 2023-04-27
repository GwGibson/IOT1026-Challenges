namespace Challenges.Testers
{
    public static class ThreeLargestTester
    {
        private static readonly List<int> t1 = new() { 22, 7, 15 };
        private static readonly List<int> r1 = new() { 7, 15, 22 };
        private static readonly List<int> t2 = new() { 38, 19, -100, 289, 29, 1, 20, 49, 219 };
        private static readonly List<int> r2 = new() { 49, 219, 289 };
        private static readonly List<int> t3 = new() { 7, 7, 7, 7, 7, 7, 7 };
        private static readonly List<int> r3 = new() { 7, 7, 7 };
        private static readonly List<int> t4 = new() { 7, 7, 7, 7, 22, 7, 7, 7, 7, 7 };
        private static readonly List<int> r4 = new() { 7, 7, 22 };
        private static readonly List<int> t5 = new() { -1, -2, -3, -7, -22, -17, -543, -8, -7, -7, -77 };
        private static readonly List<int> r5 = new() { -3, -2, -1 };

        private static readonly List<List<int>> tests = new() { t1, t2, t3, t4, t5 };
        private static readonly List<List<int>> expected = new() { r1, r2, r3, r4, r5 };

        public static void Run()
        {
            Console.WriteLine("Running ThreeLargest tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $"list: {ResultBuilder.ConvertToString(tests[i])}", Challenge.ThreeLargest(tests[i]), expected[i]));
            }
            results.ForEach(result => result.Print());
        }
    }
}
