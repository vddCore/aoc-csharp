namespace AocSolutions.Solutions._2022
{
    public partial class Day8
    {
        private class Grid
        {
            private readonly Tree[] _trees;

            public int Width { get; }
            public int Height { get; }

            public Tree this[int x, int y]
            {
                get => _trees[y * Width + x];
                set => _trees[y * Width + x] = value;
            }

            public int VisibleTrees => _trees.Count(t => t.IsVisibleFromEdge);
            public int BestTreeScore => _trees.Select(t => t.ScenicScore).Max();

            public Grid(string[] map)
            {
                var data = map.Select(x => x.ToCharArray().Select(d => int.Parse(d.ToString())).ToArray()).ToArray();

                Width = data[0].Length;
                Height = data.Length;
                
                _trees = new Tree[Width * Height];
                
                for (var y = 0; y < data.Length; y++)
                {
                    for (var x = 0; x < data[y].Length; x++)
                    {
                        this[x, y] = new Tree(this, x, y, data[x][y]);
                    }
                }
            }
        }
    }
}