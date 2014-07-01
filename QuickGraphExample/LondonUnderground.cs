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
        public BidirectionalGraph<Station, TaggedEdge<Station, TrainLine>> Map { get; set; }

        private void InitialiseMap()
        {
            Map = new BidirectionalGraph<Station, TaggedEdge<Station, TrainLine>>(false);
            foreach (var trainLine in TrainLines)
            {
                Station previous = null;
                foreach (var station in trainLine.Stations)
                {
                    if (!Map.ContainsVertex(station))
                        Map.AddVertex(station);

                    if (station != trainLine.Stations.First())
                    {
                        var edge = new TaggedEdge<Station, TrainLine>(previous, station, trainLine);
                        Map.AddEdge(edge);
                    }
                    previous = station;
                }
            }
        }

        public IEnumerable<TaggedEdge<Station, TrainLine>> GetShortestPath(Station start, Station destination)
        {
            // a delegate that gives the distance between stations (default to 1)
            Func<TaggedEdge<Station, TrainLine>, double> stationDistances = x => 1;

            var tryGetShortestPath = Map.ShortestPathsDijkstra(stationDistances, start);

            IEnumerable<TaggedEdge<Station, TrainLine>> path;
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