using AocSolutions.Solutions.Base;

namespace AocSolutions.Solutions._2022
{
    public partial class Day7 : AocSolution
    {
        private Directory _directory;

        public Day7(string dataFileName)
            : base(dataFileName)
        {
            _directory = ConstructFileSystem();
        }

        public override object? Part1()
        {
            var sz = 0;

            _directory.Traverse((n) =>
            {
                if (n is Directory)
                {
                    if (n.Size <= 100000)
                        sz += n.Size;
                }
            });

            return sz;
        }

        public override object Part2()
        {
            var dirs = new List<Directory>();
            
            var free = 70000000 - _directory.Size;
            var required = 30000000 - free;
            
            _directory.Traverse((n) =>
            {
                if (n is Directory d)
                {
                    if (n.Size >= required)
                        dirs.Add(d);
                }
            });

            return dirs.OrderBy(x => x.Size).First().Size;
        }

        private Directory ConstructFileSystem()
        {
            var paths = new Dictionary<string, int>();
            var pwd = "/";

            foreach (var line in Lines)
            {
                var spl = line.Split(' ');

                if (line.StartsWith("$"))
                {
                    if (spl[1] == "cd")
                    {
                        if (spl[2] == "..")
                        {
                            pwd = pwd.Substring(0, pwd.LastIndexOf('/'));
                            pwd = pwd.Substring(0, pwd.LastIndexOf('/')) + "/";
                        }
                        else if (spl[2] != "/")
                        {
                            pwd += $"{spl[2]}/";
                        }
                    }
                }
                else
                {
                    if (line.StartsWith("dir"))
                        continue;

                    var size = int.Parse(spl[0]);

                    paths.Add(pwd + spl[1], size);
                }
            }

            var dir = new Directory { Name = "/" };
            foreach (var path in paths)
            {
                dir.CreatePath(path.Key, path.Value);
            }

            return dir;
        }
    }
}