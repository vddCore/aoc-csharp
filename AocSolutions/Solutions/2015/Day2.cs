using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2015
{
    public class Day2 : AocSolution
    {
        public Day2(string dataFileName) 
            : base(dataFileName)
        {
        }

        public override object? Part1()
        {
            var area = 0;
            
            foreach (var line in Lines)
            {
                var dims = line.Split("x")
                    .Select(int.Parse)
                    .ToArray();
                
                var (w, l, h) = (dims[0], dims[1], dims[2]);
                var areas = new[] { (l * w), (w * h), (h * l) };
                area += 2 * areas.Sum() + areas.Min();
            }

            return area;
        }

        public override object? Part2()
        {
            var ribbon = 0;
            
            foreach (var line in Lines)
            {
                var dims = line.Split("x")
                    .Select(int.Parse)
                    .OrderBy(x => x)
                    .ToArray();

                ribbon += dims[0] * dims[1] * dims[2];
                ribbon += 2 * dims[0] + 2 * dims[1];
            }

            return ribbon;
        }
    }
}