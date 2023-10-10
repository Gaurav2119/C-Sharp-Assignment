using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[5] { 2, 3, 4, 5, 6 };
            Console.WriteLine(array.CustomAll(x => x > 1));
            Console.WriteLine(array.CustomAny(x => x < 0));
            Console.WriteLine(array.CustomMax(x => x * 2));
            Console.WriteLine(array.CustomMin(x => x - 1));
            Console.WriteLine(string.Join(", ", array.CustomWhere(x => x > 3)));
            Console.WriteLine(string.Join(", ", array.CustomSelect(x => x + 1)));

            Console.ReadLine();
        }
    }
    public static class IEnumerableExtensions
    {
        public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool>predicate)
        {
            foreach (T item in source)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item)) return true;
            }
            return false;
        }

        public static T CustomMax<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            T max = default;
            double maxVal = double.MinValue;
            foreach (T item in source)
            {
                double val = selector(item);
                if (val > maxVal)
                {
                    max = item;
                    maxVal = val;
                }
            }
            return max;
        }

        public static T CustomMin<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            T min = default;
            double minVal = double.MaxValue;
            foreach (T item in source)
            {
                double val = selector(item);
                if (val < minVal)
                {
                    min = item;
                    minVal = val;
                }
            }
            return min;
        }

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }
    }
}
