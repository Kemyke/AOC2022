using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

int X = 173;
int Y = 40;

Graph<int, int> graph = new Graph<int, int>();
var field = File.ReadAllText("input.txt").Replace(Environment.NewLine, "");
var s = field.IndexOf("S");
var e = field.IndexOf("E");
field = field.Replace("S", "a").Replace("E", "z");

int i = 0;
Dictionary<int, uint> d = new Dictionary<int, uint>();
foreach(var ch in field)
{
    var nk = graph.AddNode(i);
    d.Add(i, nk);
    i++;
}

foreach (var kvp in d)
{
    foreach (var n in Neighbors(kvp.Key, field))
    {
        graph.Connect(kvp.Value, d[n], 1, 0);
    }

}

var ret1 = graph.Dijkstra(d[s], d[e]);
var ret2 = int.MaxValue;
i = 0;
foreach (var ch in field)
{
    if (ch == 'a')
    {
        var x = graph.Dijkstra(d[i], d[e]);
        if (x.Distance < ret2)
            ret2 = x.Distance;
    }
    i++;
}


Console.ReadLine();

List<int> Neighbors(int p, string field0)
{
    List<int> ret = new List<int>();
    var mh = (int)field[p] + 1;
    int y = p / X;
    int x = p % X;
    if(x > 0 && field[p-1] <= mh)
        ret.Add(p - 1);
    if (x < X - 1 && field[p + 1] <= mh)
        ret.Add(p + 1);
    if (y > 0 && field[p - X] <= mh)
        ret.Add(p - X);
    if (y < Y - 1 && field[p + X] <= mh)
        ret.Add(p + X);
    return ret;
}
