var lines = File.ReadAllLines("input.txt");
var part1 = lines.Select(l => l.Split(" ")).Select(t => RPS.Match(RPS.Parse(t[0]), RPS.Parse(t[1]))).Select(r => r.Item2).Sum();
var part2 = lines.Select(l => l.Split(" ")).Select(t=> RPS.Match(RPS.Parse(t[0]), RPS.Parse2(t[1], RPS.Parse(t[0])))).Select(r=>r.Item2).Sum();

Console.ReadLine();

public enum Shape
{
    Rock = 1,
    Paper = 2,
    Sciccors = 3
}

public static class RPS
{
    public static Shape Parse(string s)
    {
        if (s == "A" || s == "X")
            return Shape.Rock;
        if (s == "B" || s == "Y")
            return Shape.Paper;
        if (s == "C" || s == "Z")
            return Shape.Sciccors;
        throw new ArgumentException(s);
    }
    public static Shape Parse2(string s, Shape op)
    {
        int ret = (int)op;
        if (s == "X")
        {
            ret = ret - 1;
            ret = ret == 0 ? 3 : ret;
        }
        if (s == "Z")
        {
            ret = ret + 1;
            ret = ret == 4 ? 1 : ret;
        }
        return (Shape)ret;
    }

    public static (int, int) Match(Shape lp, Shape rp)
    {
        (int, int) ret = ((int)lp, (int)rp);
        if (lp == rp)
        {
            return (ret.Item1 + 3, ret.Item2 + 3);
        }
        if(lp == Shape.Rock)
        {
            if (rp == Shape.Paper)
                return (ret.Item1, ret.Item2 + 6);
            else
                return (ret.Item1 + 6, ret.Item2);
        }
        if (lp == Shape.Paper)
        {
            if (rp == Shape.Sciccors)
                return (ret.Item1, ret.Item2 + 6);
            else
                return (ret.Item1 + 6, ret.Item2);
        }
        if (lp == Shape.Sciccors)
        {
            if (rp == Shape.Rock)
                return (ret.Item1, ret.Item2 + 6);
            else
                return (ret.Item1 + 6, ret.Item2);
        }
        throw new ArgumentException();
    }
}
