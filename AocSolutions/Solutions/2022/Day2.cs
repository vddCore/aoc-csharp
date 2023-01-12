using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day2 : AocSolution
    {
        private readonly Dictionary<char, Dictionary<char, int>> _resolutions = new()
        {
            { 'A', new() { { 'X', 1 + 3 }, { 'Y', 2 + 6 }, { 'Z', 3 + 0 } } },
            { 'B', new() { { 'X', 1 + 0 }, { 'Y', 2 + 3 }, { 'Z', 3 + 6 } } },
            { 'C', new() { { 'X', 1 + 6 }, { 'Y', 2 + 0 }, { 'Z', 3 + 3 } } }
        };
        
        private readonly Dictionary<char, Dictionary<char, char>> _winningStrategy = new()
        {
            { 'A', new() { { 'X', 'Z' }, { 'Y', 'X' }, { 'Z', 'Y' } } },
            { 'B', new() { { 'X', 'X' }, { 'Y', 'Y' }, { 'Z', 'Z' } } },
            { 'C', new() { { 'X', 'Y' }, { 'Y', 'Z' }, { 'Z', 'X' } } },
        };

        public Day2(string dataFileName)
            : base(dataFileName)
        {
        }

        public override int? Part1()
        {
            var sum = 0;

            foreach (var line in Lines)
            {
                var movePair = line.Split(' ');
                var (opponent, me) = (movePair[0][0], movePair[1][0]);
                sum += _resolutions[opponent][me];
            }

            return sum;
        }

        public override int? Part2()
        {
            var sum = 0;

            foreach (var line in Lines)
            {
                var movePair = line.Split(' ');
                var (opponent, me) = (movePair[0][0], movePair[1][0]);
                var correctedMove = _winningStrategy[opponent][me];
                sum += _resolutions[opponent][correctedMove];
            }

            return sum;
        }
    }
}