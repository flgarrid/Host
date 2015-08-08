using System;

namespace Host.Models
{
    public class Period
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To {get; set;}
        public string Recurrency { get; set; }
        public string Description { get; set; }
    }
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }
    }
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}