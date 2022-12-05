namespace AocSolutions.Runtime
{
    public class SolutionDataMissingException : SolutionException
    {
        public SolutionDataMissingException(string dataPath) 
            : base($"Solution data file '{dataPath}' is missing.")
        {
        }
    }
}