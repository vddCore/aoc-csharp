namespace AocSolutions.Solutions._2022
{
    public partial class Day8
    {
        private class Tree
        {
            public Grid Grid { get; }
            public int X { get; }
            public int Y { get; }
            public int Height { get; }

            public Tree(Grid grid, int x, int y, int height)
            {
                Grid = grid;
                X = x;
                Y = y;
                Height = height;
            }

            public bool IsVisibleFromEdge
            {
                get
                {
                    if (X == 0 || X == Grid.Width - 1 || Y == 0 || Y == Grid.Height - 1)
                        return true;

                    // left
                    return LeftProperties.Item1
                           || TopPropeties.Item1
                           || RightPropeties.Item1
                           || BottomProperties.Item1;
                }
            }

            public int ScenicScore => LeftProperties.Item2
                                      * TopPropeties.Item2
                                      * RightPropeties.Item2
                                      * BottomProperties.Item2;

            public (bool, int) LeftProperties
            {
                get
                {
                    var viewDistance = 0;

                    for (var x = X - 1; x >= 0; x--, viewDistance++)
                    {
                        if (Grid[x, Y].Height >= Height)
                            return (false, ++viewDistance);
                    }

                    return (true, viewDistance);
                }
            }

            public (bool, int) RightPropeties
            {
                get
                {
                    var viewDistance = 0;

                    for (var x = X + 1; x < Grid.Width; x++, viewDistance++)
                    {
                        if (Grid[x, Y].Height >= Height)
                            return (false, ++viewDistance);
                    }

                    return (true, viewDistance);
                }
            }

            public (bool, int) TopPropeties
            {
                get
                {
                    var viewDistance = 0;

                    for (var y = Y - 1; y >= 0; y--, viewDistance++)
                    {
                        if (Grid[X, y].Height >= Height)
                            return (false, ++viewDistance);
                    }

                    return (true, viewDistance);
                }
            }

            public (bool, int) BottomProperties
            {
                get
                {
                    var viewDistance = 0;

                    for (var y = Y + 1; y < Grid.Height; y++, viewDistance++)
                    {
                        if (Grid[X, y].Height >= Height)
                            return (false, ++viewDistance);
                    }

                    return (true, viewDistance);
                }
            }
        }
    }
}