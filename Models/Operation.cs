using System.Collections.Generic;

namespace Host.Models
{
    public class Vehicle{
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public Diagram Diagram {get; set;}
    }
    public class Diagram{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}