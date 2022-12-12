var lines = File.ReadAllLines("input.txt");
var root = new AocDirectory { Name = "/" };

var currentDir = root;

foreach(var line in lines.Skip(1))
{
    if (line.StartsWith("$"))
    {
        if (line.StartsWith("$ cd "))
        {
            var dirname = line.Replace("$ cd ", "");
            if (dirname == "..")
            {
                currentDir = currentDir.Parent;
            }
            else
            {
                var ncd = currentDir.Subdirectories.SingleOrDefault(d => d.Name == dirname);
                currentDir = ncd;
                if (ncd == null)
                {
                    throw new Exception();
                }
            }
        }
    }
    else if (line.StartsWith("dir "))
    {
        var dirname = line.Replace("dir ", "");
        currentDir.Subdirectories.Add(new AocDirectory { Name = dirname, Parent = currentDir });
    }
    else
    {
        var pars = line.Split(" ");
        currentDir.Files.Add(new AocFile { Name = pars[1], Size = long.Parse(pars[0]), Parent = currentDir });
    }
}

var ret1 =  root.AllSubdirectories.Where(d => d.Size() < 100000).ToList();
if (root.Size() < 100000) ret1.Add(root);

var ret11 = ret1.Sum(r => r.Size());

var updateSize = 30000000;
var totalSpace = 70000000;
var totalUsed = root.Size();

var toFree = totalSpace - totalUsed - updateSize;
var ret2 = root.AllSubdirectories.Where(d => d.Size() > -1 * toFree).OrderBy(d => d.Size()).First().Size();


Console.ReadLine();

public class AocDirectory
{
    public string Name { get; set; }
    public AocDirectory Parent { get; set; } = null;
    public List<AocDirectory> Subdirectories { get; set; } = new List<AocDirectory>();
    public List<AocFile> Files { get; set; } = new List<AocFile>();

    public long Size()
        => Files.Sum(f => f.Size) + Subdirectories.Sum(d => d.Size());

    public IEnumerable<AocDirectory> AllSubdirectories =>
        Subdirectories.Concat(Subdirectories.SelectMany(s => s.AllSubdirectories));
}

public class AocFile
{
    public AocDirectory Parent { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
}