namespace Day01
{
    public static class Utils
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> l, T separator)
        {
            List<IEnumerable<T>> ret = new List<IEnumerable<T>>();
            while (l.Any())
            {
                var pl = l.TakeWhile(i => !EqualityComparer<T>.Default.Equals(i, separator));
                ret.Add(pl);
                l = l.Skip(pl.Count() + 1);
            }
            return ret;
        }
    }
}
