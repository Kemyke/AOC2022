const int stackNum = 9;
var lines = File.ReadAllLines("input.txt");
var sep = lines.Select((l, i) => (i, l)).Where(t => t.l == "").Single().i;
var stack = new Stack(stackNum);

var init = lines.Take(sep - 1).Select(l => Enumerable.Range(0, stackNum).Select(i => l[i * 4 + 1]).ToList()).Reverse().ToList();
foreach (var l in init)
{
    for (int i = 0; i < stackNum; i++)
    {
        if (l[i] != ' ')
        {
            stack.Stacks[i] += l[i].ToString();
        }
    }
}

var moves = lines.Skip(sep+1).Select(l => l.Replace("move ", "").Replace("from ", "").Replace("to ", "").Split(" "));
foreach(var move in moves)
{
    stack.Move(int.Parse(move[0]), int.Parse(move[1]) - 1, int.Parse(move[2]) - 1);
}
var ret1 = stack.Ret1();

Console.ReadLine();

class Stack
{
    public List<string> Stacks { get; set; } 
    public Stack(int num)
    {
        Stacks = Enumerable.Range(0, num).Select(i => "").ToList();
    }
    public void Move(int n, int s, int d)
    {
        Stacks[d] += string.Concat(Stacks[s].TakeLast(n)); //ret1: .Reverse()
        Stacks[s] = Stacks[s].Substring(0, Stacks[s].Length - n);
    }

    public string Ret1()
    {
        return string.Concat(Stacks.Select(s => s.Last()));
    }
}