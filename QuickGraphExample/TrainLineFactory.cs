using System.Collections.Generic;
using System.Linq;

namespace QuickGraphExample
{
    class TrainLineFactory
    {
        public TrainLine Create(string name, IEnumerable<Station> stations)
        {
            return new TrainLine(name, stations);
        }

        public TrainLine CreateVictoriaLine(IEnumerable<Station> stations)
        {
            var victoriaLineStations = new List<Station>()
                {
                    stations.First(x => x.Name == StationNames.KingsCross),
                    stations.First(x => x.Name == StationNames.Euston),
                    stations.First(x => x.Name == StationNames.WarrenStreet),
                    stations.First(x => x.Name == StationNames.OxfordCircus),
                    stations.First(x => x.Name == StationNames.GreenPark),
                    stations.First(x => x.Name == StationNames.Victoria),
                    stations.First(x => x.Name == StationNames.Pimlico),
                    stations.First(x => x.Name == StationNames.Vauxhall),
                };
            return Create("Victoria", victoriaLineStations);;
        }

        public TrainLine CreateBakerlooLine(IEnumerable<Station> stations)
        {
            var bakerlooLineStations = new List<Station>()
                {
                    stations.First(x => x.Name == StationNames.Paddington),
                    stations.First(x => x.Name == StationNames.Marylebone),
                    stations.First(x => x.Name == StationNames.BakerStreet),
                    stations.First(x => x.Name == StationNames.RegentsPark),
                    stations.First(x => x.Name == StationNames.OxfordCircus),
                    stations.First(x => x.Name == StationNames.PiccadillyCircus),
                    stations.First(x => x.Name == StationNames.CharingCross),
                    stations.First(x => x.Name == StationNames.Embankment),
                    stations.First(x => x.Name == StationNames.Waterloo),
                };
            return Create("Bakerloo", bakerlooLineStations); ;
        }

        public TrainLine CreateCircleLine(IEnumerable<Station> stations)
        {
            var circleLineStations = new List<Station>()
                {
                    stations.First(x => x.Name == StationNames.BakerStreet),
                    stations.First(x => x.Name == StationNames.GreatPortlandStreet),
                    stations.First(x => x.Name == StationNames.KingsCross),
                    stations.First(x => x.Name == StationNames.Farringdon),
                    stations.First(x => x.Name == StationNames.Monument),
                    stations.First(x => x.Name == StationNames.Embankment),
                    stations.First(x => x.Name == StationNames.Victoria)
                };
            return Create("Circle", circleLineStations); ;
        }
    }
}