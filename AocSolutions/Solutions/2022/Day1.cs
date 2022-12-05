using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day1 : AocSolution
    {
        public Day1(string dataFileName)
            : base(dataFileName)
        {
        }

        public override object? Part1()
            => ComputeElfCalories()
                .Max();

        public override object? Part2()
            => ComputeElfCalories()
                .OrderByDescending(x => x)
                .Take(3)
                .Sum();

        private IEnumerable<int> ComputeElfCalories()
        {
            var elves = new List<int>();
            var current = 0;

            foreach (var line in Lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(current);
                    current = 0;

                    continue;
                }

                current += int.Parse(line);
            }

            return elves;
        }
    }
}