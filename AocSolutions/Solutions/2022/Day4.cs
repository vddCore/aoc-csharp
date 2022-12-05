using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day4 : AocSolution
    {
        public Day4(string dataFileName)
            : base(dataFileName)
        {
        }

        public override object? Part1()
        {
            var total = 0;

            foreach (var line in Lines)
            {
                var (aSec, bSec) = ParseRanges(line);

                if (!aSec.Except(bSec).Any() || !bSec.Except(aSec).Any())
                    total++;
            }

            return total;
        }

        public override object? Part2()
        {
            var total = 0;

            foreach (var line in Lines)
            {
                var (aSec, bSec) = ParseRanges(line);

                if (aSec.Intersect(bSec).Any() || bSec.Intersect(aSec).Any())
                    total++;
            }

            return total;
        }

        private (List<int>, List<int>) ParseRanges(string line)
        {
            var sections = line.Split(',')
                .Select(
                    x => x.Split('-')
                        .Select(int.Parse)
                        .ToArray()
                ).ToArray();
                
            var (a1, a2, b1, b2) = (sections[0][0], sections[0][1], sections[1][0], sections[1][1]);
            return (BuildSections(a1, a2), BuildSections(b1, b2));
        }

        private List<int> BuildSections(int start, int end)
        {
            var list = new List<int>();

            for (var i = start; i <= end; i++)
                list.Add(i);

            return list;
        }
    }
}