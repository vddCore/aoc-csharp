using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day3 : AocSolution
    {
        private readonly int _lowPriorityBase = 'a';
        private readonly int _highPriorityBase = 'A' - 26;

        public Day3(string dataFileName)
            : base(dataFileName)
        {
        }

        public override object? Part1()
        {
            var sum = 0;

            foreach (var line in Lines)
            {
                var (c1, c2) = (line.Take(line.Length / 2), line.Skip(line.Length / 2));
                var commonItems = c1.Intersect(c2);

                foreach (var item in commonItems)
                    sum += PriorityOf(item);
            }

            return sum;
        }

        public override object? Part2()
        {
            var sum = 0;
            var chunks = Lines.Chunk(3);

            foreach (var chunk in chunks)
            {
                var commonItems = chunk.ElementAt(0)
                    .Intersect(chunk.ElementAt(1))
                    .Intersect(chunk.ElementAt(2));

                foreach (var item in commonItems)
                    sum += PriorityOf(item);
            }

            return sum;
        }

        private int PriorityOf(char item)
        {
            return char.IsUpper(item)
                ? item - _highPriorityBase + 1
                : item - _lowPriorityBase + 1;
        }
    }
}