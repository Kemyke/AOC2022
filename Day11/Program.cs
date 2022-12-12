
using Day11;

var lines = File.ReadAllLines("input.txt").ToList();
var monkeys = lines.Split("");

foreach(var monkey in monkeys)
{
    int mn = int.Parse(monkey.First().Split(" ").Last().TrimEnd(':'));
    Monkey m = new Monkey();

    m.Items.AddRange(monkey.Skip(1).First().Split(":")[1].Split(',').Select(w => ulong.Parse(w)).ToList());
    var op = monkey.Skip(2).First().Split("=").Last().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    m.Operation = (op[0] == "old" ? null : ulong.Parse(op[0]), op[1], op[2] == "old" ? null : ulong.Parse(op[2]));
    m.Test = ulong.Parse(monkey.Skip(3).First().Split(" ").Last());
    m.TestTrue = int.Parse(monkey.Skip(4).First().Split(" ").Last());
    m.TestFalse = int.Parse(monkey.Skip(5).First().Split(" ").Last());

    Monkey.Monkeys.Add(mn, m);
}

foreach (var mm in Monkey.Monkeys.Select(m => m.Value.Test))
{
    Monkey.MMM = Monkey.MMM * mm;
}

for(int i = 0; i < 10000; i++)
{
    foreach(var m in Monkey.Monkeys)
    {
        m.Value.Turn();
    }
}

var ms = Monkey.Monkeys.Values.OrderByDescending(m => m.Inspect).Take(2).ToList();
var ret2 = ms[0].Inspect * ms[1].Inspect;

Console.ReadLine();

public class Monkey
{
    public static Dictionary<int, Monkey> Monkeys = new Dictionary<int, Monkey>();
    public static ulong MMM { get; set; } = 1;

    public List<ulong> Items { get; set; } = new List<ulong>();
    public (ulong?, string, ulong?) Operation { get; set; }
    public ulong Test { get; set; }
    public int TestFalse { get; set; }
    public int TestTrue { get; set; }
    public ulong Inspect { get; set; }

    public void Turn()
    {
        foreach(var item in Items)
        {
            Inspect++;
            var lp = Operation.Item1 == null ? item : Operation.Item1.Value;
            var rp = Operation.Item3 == null ? item : Operation.Item3.Value;

            ulong wl = 0;
            if (Operation.Item2 == "+")
                wl = lp + rp;
            else if (Operation.Item2 == "*")
                wl = lp * rp;
            else
                throw new Exception();

            //wl = (ulong)Math.Floor(wl / 3m); //ret1
            if(wl == 500)
            {

            }
            if(wl % Test == 0)
            {
                Monkeys[TestTrue].Items.Add((wl % MMM));
            }
            else
            {
                Monkeys[TestFalse].Items.Add((wl % MMM));
            }
        }
        Items.Clear();
    }
}