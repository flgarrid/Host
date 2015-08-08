using System.Collections.Generic;

namespace Host.Models
{
    public class Route
    {
        public int Id { get; set; }
        public Station Origin { get; set; }
        public Station Destination {get; set; }
        public List<RouteFareClassList> RouteFareClassList {get; set;}
        public Brand Brand {get; set;}
    }
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}