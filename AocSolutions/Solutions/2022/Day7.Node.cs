namespace AocSolutions.Solutions._2022
{
    public partial class Day7
    {
        private abstract class Node
        {
            public string? Name { get; set; }
            public Node? Parent { get; set; }
            public abstract int Size { get; }
        }
    }
}