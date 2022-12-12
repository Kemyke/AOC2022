using Day01;

var lines = File.ReadAllLines("input.txt");
var part1 =  lines.Split("").Select(sl=>sl.Sum(n=>int.Parse(n))).OrderByDescending(k=>k).First();
var part2 = lines.Split("").Select(sl => sl.Sum(n => int.Parse(n))).OrderByDescending(k => k).Take(3).Sum();

Console.ReadLine();