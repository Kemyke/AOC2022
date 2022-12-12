var lines = File.ReadAllLines("input.txt");

var c = new Computer();
c.Instructions = lines.SelectMany(l=> l.StartsWith("noop") ? new List<string> { "noop" } : new List<string> { "noop", l }).ToList();
c.X = 1;

for(int i = 0; i < 240; i++)
{
    c.DoCycle();
}

Console.ReadLine();

public class Computer
{
    public long Ret1 { get; set; }
    public HashSet<int> VIPCycles = new HashSet<int> { 20, 60, 100, 140, 180, 220 };
    public long X { get; set; }
    public int Cycle { get; set; }
    public List<string> Instructions { get; set; }


    public void Draw()
    {
        var pos = Cycle % 40;
        if (pos == 0)
            Console.WriteLine();

        if (pos >= X - 1 && pos <= X + 1)
            Console.Write("#");
        else
            Console.Write(".");
    }

    public void DoCycle()
    {
        Draw();
        var inst = Instructions[Cycle++];
        if(VIPCycles.Contains(Cycle))
        {
            Ret1 += Cycle * X;
        }
        if(inst.StartsWith("noop"))
        {
            return;
        }
        else
        {
            X += int.Parse(inst.Split(" ")[1]);
        }

    }
}