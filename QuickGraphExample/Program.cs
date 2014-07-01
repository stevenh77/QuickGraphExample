using System;
using System.Linq;

namespace QuickGraphExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var map = new LondonUnderground();
            var start = map.Stations.First(x => x.Name == StationNames.Marylebone);
            var destination = map.Stations.First(x => x.Name == StationNames.Victoria);

            var result = map.GetShortestPath(start, destination);

            Console.WriteLine(string.Format("Finding the shortest path between {0} and {1}", start, destination));

            if (result == null)
            {
                Console.WriteLine("  Cannot find shortest path");
            }
            else
            {
                foreach (var edge in result)
                    Console.WriteLine(string.Concat("  ", edge.Source, " > ", edge.Target));
            }
        }
    }
}