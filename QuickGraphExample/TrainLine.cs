using System;
using System.Collections.Generic;

namespace QuickGraphExample
{
    public class TrainLine
    {
        private readonly LinkedList<Station> stations = new LinkedList<Station>();

        public TrainLine(string name, IEnumerable<Station> orderedStations)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name must be set");
            if (stations.IsNullOrEmpty()) throw new Exception("Stations must be set");

            this.Name = name;
            foreach (var station in orderedStations)
                AddStation(station);
        }

        public string Name { get; set; }

        public LinkedList<Station> Stations
        {
            get { return stations; }
        }

        public void AddStation(Station station)
        {
            var stationNode = new LinkedListNode<Station>(station);
            stations.AddLast(stationNode);
            station.AddTrainLine(this);
        }

        public void RemoveStation(Station station)
        {
            stations.Remove(station);
            station.RemoveTrainLine(this);
        }
    }
}
