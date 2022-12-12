using System.Runtime.ExceptionServices;

var lines = File.ReadAllLines("input.txt");
var bridge = new Bridge();
foreach(var line in lines)
{
    var c = line.Split(" ");
    var num = int.Parse(c[1]);
    for(int i = 0; i < num; i++)
    {
        if (c[0] == "U")
            bridge.MoveHeadUp();
        else if (c[0] == "D")
            bridge.MoveHeadDown();
        else if (c[0] == "L")
            bridge.MoveHeadLeft();
        else if (c[0] == "R")
            bridge.MoveHeadRight();
    }
}

var ret2 = Bridge.Ret2.Distinct().Count();

Console.ReadLine();


class Pos
{
    public int X { get; set; }
    public int Y { get; set; }  

    public Pos Diff(Pos p)
    {
        return new Pos { X = X - p.X, Y = Y - p.Y };
    }

    public bool Adjacent(Pos p)
    {
        var d = Diff(p);
        return Math.Abs(d.X) <= 1 && Math.Abs(d.Y) <= 1;
    }

    public string Ret1() { return $"{X},{Y}"; }
}
class Bridge
{
    public static HashSet<string> Ret1 = new HashSet<string> { "0,0" };
    public static HashSet<string> Ret2 = new HashSet<string> { "0,0" };
    public Pos Head { get; set; } = new Pos { X = 0, Y = 0 };
    public Pos Tail { get; set; } = new Pos { X = 0, Y = 0 };
    public List<Pos> Tails { get; set; } = new List<Pos>();

    public void MoveHeadUp() { Head.Y--; MoveTails(); }
    public void MoveHeadDown() { Head.Y++; MoveTails(); }
    public void MoveHeadRight() { Head.X++; MoveTails(); }
    public void MoveHeadLeft() { Head.X--; MoveTails(); }

    public Bridge()
    {
        for (int i = 0; i < 9; i++)
            Tails.Add(new Pos { X = 0, Y = 0 });
    }

    public void MoveTail()
    {
        if (!Head.Adjacent(Tail))
        {
            var d = Head.Diff(Tail);
            if (d.X != 0) { Tail.X += d.X / Math.Abs(d.X); }
            if (d.Y != 0) { Tail.Y += d.Y / Math.Abs(d.Y); }

            Ret1.Add(Tail.Ret1());
        }
    }

    public void MoveTails()
    {
        for(int i=-1; i<Tails.Count - 1;i++)
        {
            Pos h, t;
            if (i == -1) h = Head; else h = Tails[i];
            t = Tails[i + 1];

            if (!h.Adjacent(t))
            {
                var d = h.Diff(t);
                if (d.X != 0) { t.X += d.X / Math.Abs(d.X); }
                if (d.Y != 0) { t.Y += d.Y / Math.Abs(d.Y); }

                if (i == Tails.Count - 2)
                {
                    Ret2.Add(t.Ret1());
                }
            }
        }
    }
}