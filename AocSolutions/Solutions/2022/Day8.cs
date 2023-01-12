using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public partial class Day8 : AocSolution
    {
        private readonly Grid _treeGrid;
        
        public Day8(string dataFileName)
            : base(dataFileName)
        {
            _treeGrid = new Grid(Lines);
        }

        public override object Part1()
            => _treeGrid.VisibleTrees;

        public override object Part2()
            => _treeGrid.BestTreeScore;
    }
}