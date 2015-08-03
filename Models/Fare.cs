using System.Collections.Generic;

namespace Host.Models
{
    public class FareClass{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Protection> Protections {get; set;}
        public List<RouteFareClassList> RouteFareClassList {get; set;}
    }
    public class Protection{
        public int Id { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
    }
    public class RouteFareClassList{
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int FareClassId { get; set; }
        public FareClass FareClass { get; set; }
        public Period Period {get;set;}
        public double Mean {get; set; }
        public double StDev {get; set; }
        public double Value { get; set; }
        public Currency Currency { get; set; }
    }
}