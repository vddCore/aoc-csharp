namespace AocSolutions.Runtime
{
    public class SolutionLogicMissingException : SolutionException
    {
        public SolutionLogicMissingException(string typeName) 
            : base($"Solution logic type '{typeName}' is missing.")
        {
        }
    }
}