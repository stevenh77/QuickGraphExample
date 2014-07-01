using System.Collections.Generic;

namespace QuickGraphExample
{
    class StationFactory
    {
        public List<Station> Create ()
        {
            return new List<Station>
                {
                    /* victoria line */
                    new Station() {Name = StationNames.KingsCross},
                    new Station() {Name = StationNames.Euston},
                    new Station() {Name = StationNames.WarrenStreet},
                    new Station() {Name = StationNames.OxfordCircus},
                    new Station() {Name = StationNames.GreenPark},
                    new Station() {Name = StationNames.Victoria},
                    new Station() {Name = StationNames.Pimlico},
                    new Station() {Name = StationNames.Vauxhall},

                    /* unique to bakerloo line */
                    new Station() {Name = StationNames.Paddington},
                    new Station() {Name = StationNames.Marylebone},
                    new Station() {Name = StationNames.BakerStreet},
                    new Station() {Name = StationNames.RegentsPark},
                    //  oxford circus 
                    new Station() {Name = StationNames.PiccadillyCircus},
                    new Station() {Name = StationNames.CharingCross},
                    new Station() {Name = StationNames.Embankment},
                    new Station() {Name = StationNames.Waterloo},

                    /* unique to circle line */
                    // Baker Street
                    new Station() {Name = StationNames.GreatPortlandStreet},
                    // kings cross
                    new Station() {Name = StationNames.Farringdon},
                    new Station() {Name = StationNames.Monument},
                    // embankment
                    // victoria
                };
        }
    }
}
