namespace AocSolutions.Solutions._2022
{
    public partial class Day7
    {
        private class File : Node
        {
            public override int Size { get; }

            public File(int size)
            {
                Size = size;
            }
        }
    }
}