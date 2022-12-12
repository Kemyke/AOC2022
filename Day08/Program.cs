var lines = File.ReadAllLines("input.txt").ToList();
var forest = new Forest { Width = lines.First().Length, Height = lines.Count, TreesA = new Tree[lines.Count, lines.First().Length] };

for (int y = 0; y < forest.Height; y++)
{
    var line = lines[y];
    for(int x = 0; x < forest.Width; x++)
    {
        var t = new Tree { X = x, Y = y, Height = int.Parse(line[x].ToString()), Visible = false };
        forest.Trees.Add(t);
        forest.TreesA[y,x] = t;
    }
}

forest.CalculateLeft();
forest.CalculateRight();
forest.CalculateUp();
forest.CalculateBottom();

//forest.Draw();
var ret1 = forest.Trees.Where(t => t.Visible).Count();

forest.CalculateScenic();

var ret2 = forest.Trees.OrderBy(t => t.ScenicScore).Last().ScenicScore;

Console.ReadLine();

class Tree
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public bool Visible { get; set; }
    public int ScenicScore { get; set; }

    public Tree Top { get; set; }
    public Tree Bottom { get; set; }
    public Tree Left { get; set; }
    public Tree Right { get; set; }
}
class Forest
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Tree> Trees { get; set; } = new List<Tree>();
    public Tree[,] TreesA { get; set; }

    public void Draw()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var tree = Trees.Single(t => t.X == x && t.Y == y);
                if(tree.Visible) Console.Write(tree.Height+ "_");
                else Console.Write(tree.Height + " ");
            }
            Console.WriteLine();
        }
    }

    public void CalculateScenic()
    {
        for (int y = 1; y < Height - 1; y++)
        {
            for (int x = 1; x < Width - 1; x++)
            {
                var tree = TreesA[y,x];
                var ls = 1;
                var rs = 1;
                var us = 1;
                var ds = 1;

                var dx = x - 1;
                var dt = TreesA[y,dx];

                while(dx >= 0 && dt.Height < tree.Height)
                {
                    dx--;
                    if (dx >= 0)
                    {
                        ls++;
                        dt = TreesA[y, dx];
                    }
                }

                dx = x + 1;
                dt = TreesA[y,dx];

                while (dx < Width && dt.Height < tree.Height)
                {
                    dx++;
                    if (dx < Width)
                    {
                        rs++;
                        dt = TreesA[y, dx];
                    }
                }

                var dy = y - 1;
                dt = TreesA[dy,x];
                while (dy >= 0 && dt.Height < tree.Height)
                {
                    dy--;
                    if (dy >= 0)
                    {
                        us++;
                        dt = TreesA[dy, x];
                    }
                }

                dy = y + 1;
                dt = TreesA[dy,x];
                while (dy < Height && dt.Height < tree.Height)
                {
                    dy++;
                    if (dy < Height)
                    {
                        ds++;
                        dt = TreesA[dy, x];
                    }
                }

                tree.ScenicScore = ls * rs * us * ds;
            }
        }
    }

    public void CalculateLeft()
    {
        for (int i = 0; i < Height; i++)
        {
            var line = Trees.Where(t => t.X == i).ToList();
            int max = -1;
            for (int j = 0; j < Width; j++)
            {
                if(line[j].Height > max)
                {
                    line[j].Visible = true;
                    max = line[j].Height;
                }
            }
        }
    }

    public void CalculateRight()
    {
        for (int i = 0; i < Height; i++)
        {
            var line = Trees.Where(t => t.X == i).ToList();
            int max = -1;
            for (int j = Width - 1; j >= 0; j--)
            {
                if (line[j].Height > max)
                {
                    line[j].Visible = true;
                    max = line[j].Height;
                }
            }
        }
    }

    public void CalculateUp()
    {
        for (int i = 0; i < Width; i++)
        {
            var line = Trees.Where(t => t.Y == i).ToList();
            int max = -1;
            for (int j = 0; j < Height; j++)
            {
                if (line[j].Height > max)
                {
                    line[j].Visible = true;
                    max = line[j].Height;
                }
            }
        }
    }

    public void CalculateBottom()
    {
        for (int i = 0; i < Width; i++)
            {
                var line = Trees.Where(t => t.Y == i).ToList();
            int max = -1;
            for (int j = Height - 1; j >= 0; j--)
            {
                if (line[j].Height > max)
                {
                    line[j].Visible = true;
                    max = line[j].Height;
                }
            }
        }
    }
}

