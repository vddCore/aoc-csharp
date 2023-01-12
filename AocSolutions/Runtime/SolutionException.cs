namespace AocSolutions.Runtime
{
    public class SolutionException : Exception
    {
        public SolutionException(string message) 
            : base(message)
        {
        }
    }
}