namespace AocSolutions.Solutions._2022
{
    public partial class Day7
    {
        private class Directory : Node
        {
            public Dictionary<string, Node> Children { get; } = new();

            public override int Size
            {
                get
                {
                    var ret = 0;

                    foreach (var child in Children)
                        ret += child.Value.Size;

                    return ret;
                }
            }

            public void AddFile(string name, int size)
            {
                Children.Add(
                    name,
                    new File(size)
                    {
                        Parent = this,
                        Name = name
                    }
                );
            }

            public Directory AddDirectory(string name)
            {
                var ret = new Directory
                {
                    Parent = this,
                    Name = name
                };
                
                Children.Add(name, ret);
                return ret;
            }

            public void CreatePath(string path, int size)
            {
                var segs = path.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var fileName = segs[^1];
                segs = segs.Take(segs.Length - 1).ToArray();

                var current = this;
                foreach (var seg in segs)
                {
                    if (current!.Children.ContainsKey(seg))
                    {
                        current = current.Children[seg] as Directory;
                    }
                    else
                    {
                        current = current.AddDirectory(seg);
                    }
                }

                current!.AddFile(fileName, size);
            }

            public void Traverse(Action<Node> code)
            {
                foreach (var i in Children)
                {
                    code(i.Value);

                    if (i.Value is Directory d)
                        d.Traverse(code);
                }
            }
        }
    }
}