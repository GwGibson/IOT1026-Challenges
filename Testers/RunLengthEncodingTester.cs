namespace Challenges.Testers
{
    public static class RunLengthEncodingTester
    {
        private const string t1 = "AAAAAAAAAAAAABBCCCCDDDDDDDDDDD";
        private const string r1 = "9A4A2B4C9D2D";
        private const string t2 = ";;;;;;;;;;;;''''''''''''''''''''1233333332222211112222111s";
        private const string r2 = "9;3;9'9'2'111273524142311s";
        private const string t3 = "aAaAaaaaaAaaaAAAABbbbBBBB";
        private const string r3 = "1a1A1a1A5a1A3a4A1B3b4B";
        private const string t4 = "                          ";
        private const string r4 = "9 9 8 ";
        private const string t5 = "1  222 333    444  555";
        private const string r5 = "112 321 334 342 35";
        private const string t6 = "AAAAAAAAAAAAABBCCCCDD";
        private const string r6 = "9A4A2B4C2D";
        private const string t7 = "1A2BB3CCC4DDDD";
        private const string r7 = "111A122B133C144D";
        private const string t8 = "aA";
        private const string r8 = "1a1A";
        private const string t9 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private const string r9 = "9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a9a3a";

        private static readonly List<string> tests = new() { t1, t2, t3, t4, t5, t6, t7, t8, t9 };
        private static readonly List<string> expected = new() { r1, r2, r3, r4, r5, r6, r7, r8, r9 };

        public static void Run()
        {
            Console.WriteLine("Running RunLengthEncoding tester.");
            List<Result> results = new();
            int index = 1;
            for (int i = 0; i < tests.Count; i++)
            {
                results.Add(ResultBuilder.BuildResult(index++, $" {tests[i]}", Challenge.RunLengthEncoding(tests[i]), expected[i]));
            }
            results.ForEach(result => result.Print());
        }
    }
}
