namespace VFS.GD.TestFramework
{
    /// <summary>
    /// Responsible for holding the result of a unit test
    /// </summary>
    class Test
    {
        private string name;
        public string Name { get { return name; } }

        private bool result;
        public bool Result { get { return result; } }

        public Test(string name)
        {
            this.name = name;
            this.result = true;
        }

        public void Assert(bool assertion)
        {
            result &= assertion;
        }
    }

    class TestGroup
    {
        private string name;
        public string Name { get => name; }

        private Test[] tests;
        public Test[] Tests { get => tests; set => tests = value; }

        public TestGroup(string name)
        {
            this.name = name;
        }

        public int PassCount()
        {
            int result = 0;
            foreach (Test test in tests)
            {
                if (test.Result)
                { 
                    result++;
                }
            }
            return result;
        }
    }
}
