using System.Collections.Generic;
using System;

namespace Host.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public bool Anonymous { get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string IdentityDocument { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<CustomerTypeList> CustomerTypeList {get; set;}
    }
    public class CustomerType
    {
        public int Id { get; set; }
        public string Type {get; set; }
        public List<Charge> Charges {get; set;}
        public List<CustomerTypeList> CustomerTypeList {get; set;}
    }
    public class CustomerTypeList{
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}