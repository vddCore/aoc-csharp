using System.Text.RegularExpressions;
using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public class Day5 : AocSolution
    {
        private Regex _stacksRegex = new(@"(\[(?<crate>\w)\])\s?|(\s{3})?\s");
        private Regex _insnRegex = new(@"move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)");

        public Day5(string dataFileName)
            : base(dataFileName)
        {   
        }

        public override object Part1()
        {
            var stackRowCount = Array.IndexOf(Lines, Lines.First(x => string.IsNullOrEmpty(x))) - 1;
            var stackRows = Lines.Take(stackRowCount).ToArray();
            var instructions = Lines.Skip(stackRowCount + 2);
            var transposed = ParseTranspose(stackRows);

            foreach (var insn in instructions)
            {
                var (count, from, to) = ParseInstruction(insn);

                for (var i = 0; i < count; i++)
                {
                    transposed[to].Push(transposed[from].Pop());
                }
            }

            return string.Concat(transposed.Select(x => x.ElementAt(0)));
        }
        
        public override object Part2()
        {
            var stackRowCount = Array.IndexOf(Lines, Lines.First(x => string.IsNullOrEmpty(x))) - 1;
            var stackRows = Lines.Take(stackRowCount).ToArray();
            var instructions = Lines.Skip(stackRowCount + 2);
            var transposed = ParseTranspose(stackRows);

            foreach (var insn in instructions)
            {
                var (count, from, to) = ParseInstruction(insn);

                if (count == 1)
                {
                    transposed[to].Push(transposed[from].Pop());
                }
                else
                {
                    var elements = transposed[from].Take(count).Reverse().ToArray();
                    
                    for (var i = 0; i < count; i++)
                    {
                        transposed[from].Pop();
                        transposed[to].Push(elements[i]);
                    }
                }
            }

            return string.Concat(transposed.Select(x => x.ElementAt(0)));
        }

        private void PrintStacks(IEnumerable<Stack<char>> stacks)
        {
            foreach (var x in stacks)
            {
                Console.WriteLine(string.Concat(x));
            }
        }

        private (int, int, int) ParseInstruction(string line)
        {
            var match = _insnRegex.Match(line);

            return (
                int.Parse(match.Groups["count"].Value),
                int.Parse(match.Groups["from"].Value) - 1,
                int.Parse(match.Groups["to"].Value) - 1
            );
        }

        private List<Stack<char>> ParseTranspose(string[] stackRows)
        {
            var ret = new List<List<char>>();

            for (var i = 0; i < 10; i++)
                ret.Add(new List<char>());

            for (var i = stackRows.Length - 1; i >= 0; i--)
            {
                var matches = _stacksRegex.Matches(stackRows[i]);

                for (var j = 0; j < matches.Count; j++)
                {
                    if (!string.IsNullOrWhiteSpace(matches[j].Groups["crate"].Value))
                        ret[j].Add(matches[j].Groups["crate"].Value[0]);
                }
            }

            ret.RemoveAll(x => !x.Any());
            return ret.Select(x => new Stack<char>(x)).ToList();
        }
    }
}