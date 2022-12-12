var lines = File.ReadAllLines("input.txt");
var ret1 = lines.Select(l => (l.Substring(0, l.Length / 2), l.Substring(l.Length / 2))).Select(p => p.Item1.Intersect(p.Item2).Single())
                .Select(c=>char.IsLower(c) ? c - 96 : c - 64 + 26).Sum();
var ret = new List<char>();
for(int i = 0; i < lines.Length; i+=3)
{
    ret.Add(lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]).Single());
}

var ret2 = ret.Select(c => char.IsLower(c) ? c - 96 : c - 64 + 26).Sum();

Console.ReadLine();
