var input = File.ReadAllText("input.txt");
int markerLength = 4;
var ret1 = input.TakeWhile((ch, i) => i < markerLength || input.Substring(i - markerLength, markerLength).Distinct().Count() != markerLength).Count();
markerLength = 14;
var ret2 = input.TakeWhile((ch, i) => i < markerLength || input.Substring(i - markerLength, markerLength).Distinct().Count() != markerLength).Count();

Console.ReadLine();