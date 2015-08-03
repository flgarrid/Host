using Microsoft.Data.Entity;

namespace Host.Models
{
    public class HostContext : DbContext
    {
        /* FARE */
        public DbSet<FareClass> FareClass { get; set; }
        public DbSet<Protection> Protection { get; set; }
        public DbSet<RouteFareClassList> RouteFareClassList { get; set; }
        /* CUSTOMER */
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<CustomerTypeList> CustomerTypeList { get; set; }
        /* PRICE */
        public DbSet<Charge> Charge { get; set; }
        public DbSet<Charges> Charges { get; set; }
        /* ROUTE */
        public DbSet<Route> Route { get; set; }
        /* COMMON */
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Period> Period { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomerTypeList>()
                .Key(c => new { c.CustomerId, c.CustomerTypeId });
            builder.Entity<RouteFareClassList>()
                .Key(c => new { c.RouteId, c.FareClassId });
            builder.Entity<Charges>()
                .Key(c => new { c.ChargeId, c.Charge2Id });
            builder.Entity<PeriodCharges>()
                .Key(c => new { c.ChargeId, c.PeriodId });
        }
    }
}