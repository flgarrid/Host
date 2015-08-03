using System.Collections.Generic;

namespace Host.Models
{
    public class Charge{
        public int Id { get; set; }
        public double Value { get; set; }
        public string Type {get; set; }
        public string Restrictions { get; set; }
        public string PaymentMethod { get; set; }
        public int Priority { get; set; }
        public string POS { get; set; }
        public Currency Currency { get; set; }
        public List<CustomerType> CustomerTypes {get; set;}
        public List<Route> Routes {get; set;}
        public List<PeriodCharges> PeriodCharges {get;set;}
    }
    public class Charges{
        public int ChargeId {get;set;}
        public Charge Charge {get; set;}
        public int Charge2Id{get;set;}
        public Charge Charge2 {get; set;}
    }
    public class PeriodCharges{
        public int PeriodId {get; set;}
        public Period Period {get; set;}
        public int ChargeId {get;set;}
        public Charge Charge {get;set;}
    }
}