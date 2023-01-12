using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day6 : AocSolution
    {
        public Day6(string dataFileName) 
            : base(dataFileName)
        {
        }

        public override object? Part1()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                if (Data.Skip(i).Take(4).Distinct().Count() == 4)
                    return i + 4;
            }

            return null;
        }
        
        public override object? Part2()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                if (Data.Skip(i).Take(14).Distinct().Count() == 14)
                    return i + 14;
            }

            return null;
        }
    }
}