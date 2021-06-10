using System;
using System.Collections.Generic;
using System.Linq;

namespace Algor
{
    public class Program
    {
        /// <summary>
        /// Входные данные
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static (int, List<(int, int)>) HandleArgs(string[] args)
        {
            var counter = 0;
            var segments = new List<(int, int)>();
            if (args is null || args.Length == 0)
            {
                counter = int.Parse(Console.ReadLine());
                for (int i = 0; i < counter; i++)
                {
                    var temp = Console.ReadLine().Split(" ");
                    segments.Add((int.Parse(temp[0]), int.Parse(temp[1])));
                }
            }
            else
            {
                counter = int.Parse(args[0]);
                for (int i = 1; i <= counter; i++)
                {
                    var temp = args[i].Split(" ");
                    segments.Add((int.Parse(temp[0]), int.Parse(temp[1])));
                }
            }
            return (counter, segments);

        }

        /// <summary>
        /// Main епт
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var (counter, segments) = HandleArgs(args);

            MySort(segments);

            var set = Calculate(segments);

            Console.WriteLine(set.Count);
            foreach (var item in set)
            {
                Console.Write($"{item} ");
            }
        }

        public static SortedSet<int> Calculate(List<(int, int)> segments)
        {
            if (segments.Count == 1)
            {
                return new SortedSet<int>()
                {
                    segments[0].Item1
                };
            }

            var points = new SortedSet<int>();
            var previousStart = segments[0].Item1;
            var previousEnd = segments[0].Item2;

            for (int i = 1; i < segments.Count; i++)
            {
                if (segments[i].Item2 > previousEnd)
                {
                    if (!points.Any() || points.Last() < previousStart)
                    {
                        points.Add(previousEnd);
                    }
                }
                else if (segments[i].Item1 > previousStart)
                {
                    if (!points.Any() || points.Last() < segments[i].Item1)
                    {
                        points.Add(segments[i].Item1);
                    }

                }
                previousStart = segments[i].Item1;
                previousEnd = segments[i].Item2;

            }
            return points;
        }

        /// <summary>
        /// Просто сортировка
        /// </summary>
        /// <param name="segments"></param>
        public static void MySort(List<(int, int)> segments)
        {
            segments.Sort(new TupleComparer());
        }
    }

    class TupleComparer : IComparer<(int, int)>
    {
        public int Compare((int, int) x, (int, int) y)
        {
            if (x.Item1 > y.Item1)
            {
                return 1;
            }
            if (x.Item1 == y.Item1)
            {
                if (x.Item2 > y.Item2)
                {
                    return 1;
                }
                if (x.Item2 < y.Item2)
                {
                    return -1;
                }
                return 0;
            }
            return -1;
        }
    }
}

