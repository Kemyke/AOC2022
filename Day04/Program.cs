var lines = File.ReadAllLines("input.txt");
var ret1 = lines.Select(l => l.Split(",")).Select(iv => (iv[0].Split("-").Select(s => int.Parse(s)).ToArray(), iv[1].Split("-").Select(s => int.Parse(s)).ToArray()))
 .Where(t => (t.Item1[0] >= t.Item2[0] && t.Item1[1] <= t.Item2[1]) || (t.Item2[0] >= t.Item1[0] && t.Item2[1] <= t.Item1[1])).Count();

var ret2 = lines.Select(l => l.Split(",")).Select(iv => (iv[0].Split("-").Select(s => int.Parse(s)).ToArray(), iv[1].Split("-").Select(s => int.Parse(s)).ToArray()))
 .Where(t => (t.Item1[0] >= t.Item2[0] && t.Item1[0] <= t.Item2[1]) || (t.Item1[1] >= t.Item2[0] && t.Item1[1] <= t.Item2[1]) || (t.Item2[0] >= t.Item1[0] && t.Item2[0] <= t.Item1[1]) || (t.Item2[1] >= t.Item1[0] && t.Item2[1] <= t.Item1[1])).Count();


Console.ReadLine();