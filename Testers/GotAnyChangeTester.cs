namespace Challenges.Testers
{
    public static class GotAnyChangeTester
    {
        private static readonly List<int> t1 = new() { 22, 7, 1, 1, 2, 3, 5 };
        private const int R1 = 20;
        private static readonly List<int> t2 = new();
        private const int R2 = 1;
        private static readonly List<int> t3 = new() { 1, 1, 1, 1, 1, 1 };
        private const int R3 = 7;
        private static readonly List<int> t4 = new() { 2 };
        private const int R4 = 1;
        private static readonly List<int> t5 = new() { 1 };
        private const int R5 = 2;
        private static readonly List<int> t6 = new() { 1, 5, 1, 1, 1, 10, 15, 20, 100 };
        private const int R6 = 55;
        private static readonly List<int> t7 = new() { 6, 4, 5, 1, 1, 8, 9 };
        private const int R7 = 3;
        private static readonly List<int> t8 = new() { 109, 2000, 8765, 19, 18, 17, 16, 8, 1, 1, 2, 4 };
        private const int R8 = 87;

        private static readonly List<List<int>> tests = new() { t1, t2, t3, t4, t5, t6, t7, t8 };
        private static readonly List<int> expected = new() { R1, R2, R3, R4, R5, R6, R7, R8 };

        public static void Run()
        {
            Console.WriteLine("Running GotAnyChange tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $"coins: {ResultBuilder.ConvertToString(tests[i])}", Challenge.GotAnyChange(tests[i]), expected[i]));
            }
            results.ForEach(result => result.Print());
        }
    }
}
