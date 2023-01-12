namespace AocSolutions.Solutions.Base
{
    public abstract class AocSolution
    {
        public string DataFileName { get; }
        protected string Data { get; }
        protected string[] Lines { get; }

        protected AocSolution(string dataFileName)
        {
            DataFileName = dataFileName;
            Data = File.ReadAllText(dataFileName);
            Lines = Data.Split('\n');
        }

        public virtual object? Part1()
        {
            return null;
        }

        public virtual object? Part2()
        {
            return null;
        }
    }
}