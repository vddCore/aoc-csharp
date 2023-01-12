using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2015
{
    public class Day1 : AocSolution
    {
        public Day1(string dataFileName) 
            : base(dataFileName)
        {
        }

        public override object? Part1()
            => Data.Count(c => c == '(') - Data.Count(c => c == ')');

        public override object? Part2()
        {
            for (int i = 0, j = 0; i < Data.Length; i++)
            {
                if (j < 0)
                    return i;

                if (Data[i] == '(') j++;
                else if (Data[i] == ')') j--;
            }

            return null;
        }
    }
}