using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;
using QuickGraph.Algorithms;

namespace QuickGraphExample
{
    public class LondonUnderground
    {
        public LondonUnderground()
        {
            InitialiseStations();
            InitialiseTrainLines();
            InitialiseMap();
        }

        public List<TrainLine> TrainLines { get; set; }
        public List<Station> Stations { get; set; }
        public AdjacencyGraph<Station, Edge<Station>> Map { get; set; }

        private void InitialiseMap()
        {
            Map = new AdjacencyGraph<Station, Edge<Station>>(false);
            foreach (var trainLine in TrainLines)
            {
                Station previous = null;
                foreach (var station in trainLine.Stations)
                {
                    if (!Map.ContainsVertex(station))
                        Map.AddVertex(station);

                    if (station != trainLine.Stations.First())
                    {
                        var edge = new Edge<Station>(previous, station);
                        Map.AddEdge(edge);
                    }
                    previous = station;
                }
            }
        }

        public IEnumerable<Edge<Station>> GetShortestPath(Station start, Station destination)
        {
            // a delegate that gives the distance between stations (default to 1)
            Func<Edge<Station>, double> stationDistances = x => 1;

            var tryGetShortestPath = Map.ShortestPathsDijkstra(stationDistances, start);

            IEnumerable<Edge<Station>> path;
            return tryGetShortestPath(destination, out path) ? path : null;
        }

        private void InitialiseTrainLines()
        {
            var trainLineFactory = new TrainLineFactory();
            var victoriaLine = trainLineFactory.CreateVictoriaLine(Stations);
            var bakerlooLine = trainLineFactory.CreateBakerlooLine(Stations);
            var circleLine = trainLineFactory.CreateCircleLine(Stations);

            TrainLines = new List<TrainLine> { victoriaLine, bakerlooLine, circleLine };
        }

        private void InitialiseStations()
        {
            var stationFactory = new StationFactory();
            Stations = stationFactory.Create();
        }
    }
}