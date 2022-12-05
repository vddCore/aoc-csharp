using System.Reflection;
using AocSolutions.Solutions.Base;

namespace AocSolutions.Runtime
{
    public class SolutionRunner
    {
        public string PuzzleDataDirectory { get; }

        public SolutionRunner(string puzzleDataDirectory)
        {
            PuzzleDataDirectory = puzzleDataDirectory;
        }

        public void RunTodays()
        {
            var dt = DateTime.Now;
            Run(dt.Year, dt.Day);
        }

        public void RunAllFromYear(int year)
        {
            Console.WriteLine($"Running all from year {year}!");

            for (var i = 1; i <= 25; i++)
            {
                try
                {
                    Run(year, i);
                }
                catch (SolutionDataMissingException sdme)
                {
                    Console.WriteLine($"{sdme.Message}");
                }
                catch (SolutionLogicMissingException slme)
                {
                    Console.WriteLine($"{slme.Message}");
                }
            }
        }

        public void Run(int year, int day)
        {
            var puzzleDataPath = Path.Combine(
                AppContext.BaseDirectory, 
                PuzzleDataDirectory, 
                $"{year}", 
                $"Day{day}"
            );

            if (!File.Exists(puzzleDataPath))
            {
                throw new SolutionDataMissingException(puzzleDataPath);
            }

            var type = FindSolutionType(year, day, out var typeName)
                       ?? throw new SolutionLogicMissingException(typeName);
            
            var solution = CreateSolutionInstance(type, puzzleDataPath)
                ?? throw new SolutionException($"Failed to create a solution instance for day {day}.");
            
            ExecuteSolution(year, day, solution);
        }

        private void ExecuteSolution(int year, int day, AocSolution solution)
        {
            var (answer1, answer2) = (solution.Part1(), solution.Part2());

            Console.WriteLine($"{year} DAY {day}:");
            if (answer1 != null)
            {
                Console.WriteLine($" => [P1: {answer1}]");
            }

            if (answer2 != null)
            {
                Console.WriteLine($" => [P2: {answer2}]");
            }
        }

        private IEnumerable<Type> FindSolutionTypes(int year)
        {
            var typeName = $"AocSolutions.Solutions._{year}";

            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.FullName!.StartsWith(typeName));
        }

        private Type? FindSolutionType(int year, int day, out string typeName)
        {
            var localTypeName = typeName = $"AocSolutions.Solutions._{year}.Day{day}";

            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.FullName == localTypeName);
        }

        private AocSolution? CreateSolutionInstance(Type type, string puzzleDataPath)
            => Activator.CreateInstance(type, new object[] { puzzleDataPath }) as AocSolution;
    }
}