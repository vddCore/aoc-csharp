using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2015
{
    public class Day3 : AocSolution
    {
        public Day3(string dataFileName) 
            : base(dataFileName)
        {
        }

        public override object? Part1()
        {
            int x = 0, y = 0;
            var map = new Dictionary<string, int>();

            foreach (var c in Data)
                DropPresent(c, map, ref x, ref y);

            return map.Count();
        }
        
        public override object? Part2()
        {
            int sx = 0, sy = 0;
            int rx = 0, ry = 0;
            
            var map = new Dictionary<string, int>();

            for (var i = 0; i < Data.Length; i++)
            {
                if (i % 2 == 0)
                {
                    DropPresent(Data[i], map, ref sx, ref sy);
                }
                else
                {
                    DropPresent(Data[i], map, ref rx, ref ry);
                }
            }

            return map.Count();
        }

        private void DropPresent(char dir, Dictionary<string, int> map, ref int x, ref int y)
        {
            switch (dir)
            {
                case 'v': y++; break;
                case '^': y--; break;
                case '>': x++; break;
                case '<': x--; break;
            }

            if (!map.TryAdd($"{x}_{y}", 1))
                map[$"{x}_{y}"]++;
        }
    }
}