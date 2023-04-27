namespace Challenges.Testers
{
    public static class TwoNumSumTester
    {
        private static readonly Tuple<List<int>, int> t1 = new(new List<int> { 22 }, 7);
        private static readonly List<List<int>> r1 = new() { new List<int>() };
        private static readonly Tuple<List<int>, int> t2 = new(new List<int> { 22 }, 22);
        private static readonly List<List<int>> r2 = new() { new List<int>() };
        private static readonly Tuple<List<int>, int> t3 = new(new List<int> { 3, 7 }, 10);
        private static readonly List<List<int>> r3 = new() { new List<int> { 3, 7 } };
        private static readonly Tuple<List<int>, int> t4 = new(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 17);
        private static readonly List<List<int>> r4 = new() { new List<int> { 7, 10 }, new List<int> { 8, 9 } };
        private static readonly Tuple<List<int>, int> t5 = new(new List<int> { -7, -5, -3, -1, 0, 1, 3, 5, 7 }, -5);
        private static readonly List<List<int>> r5 = new() { new List<int> { -5, 0 } };
        private static readonly Tuple<List<int>, int> t6 = new(new List<int> { -1, -3, 6, 4 }, 3);
        private static readonly List<List<int>> r6 = new() { new List<int> { -3, 6 }, new List<int> { -1, 4 } };

        private static readonly List<Tuple<List<int>, int>> tests = new() { t1, t2, t3, t4, t5, t6 };
        private static readonly List<List<List<int>>> expected = new() { r1, r2, r3, r4, r5, r6 };

        public static void Run()
        {
            Console.WriteLine("Running TwoNumSum tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $"list: {ResultBuilder.ConvertToString(tests[i].Item1)} | target: {tests[i].Item2}", Challenge.TwoNumSum(tests[i].Item1, tests[i].Item2), expected[i], false));
            }
            results.ForEach(result => result.Print());
        }
    }
}
