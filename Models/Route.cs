using System.Collections.Generic;

namespace Host.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination {get; set; }
        public List<RouteFareClassList> RouteFareClassList {get; set;}
    }
}