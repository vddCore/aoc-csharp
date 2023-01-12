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

        public virtual int? Part1()
        {
            return null;
        }

        public virtual int? Part2()
        {
            return null;
        }
    }
}