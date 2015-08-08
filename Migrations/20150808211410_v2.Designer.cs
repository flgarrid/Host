using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Host.Models;

namespace HostMigrations
{
    [ContextType(typeof(HostContext))]
    partial class v2
    {
        public override string Id
        {
            get { return "20150808211410_v2"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("Host.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Charge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurrencyId");

                    b.Property<string>("POS");

                    b.Property<string>("PaymentMethod");

                    b.Property<int>("Priority");

                    b.Property<string>("Restrictions");

                    b.Property<string>("Type");

                    b.Property<double>("Value");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Charges", b =>
                {
                    b.Property<int>("ChargeId");

                    b.Property<int>("Charge2Id");

                    b.Key("ChargeId", "Charge2Id");
                });

            builder.Entity("Host.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ISO");

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<bool>("Anonymous");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdentityDocument");

                    b.Property<string>("LastName");

                    b.Property<string>("Nationality");

                    b.Property<string>("Phone");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.CustomerTypeList", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerTypeId");

                    b.Key("CustomerId", "CustomerTypeId");
                });

            builder.Entity("Host.Models.FareClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("From");

                    b.Property<string>("Recurrency");

                    b.Property<DateTime>("To");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.PeriodCharges", b =>
                {
                    b.Property<int>("ChargeId");

                    b.Property<int>("PeriodId");

                    b.Key("ChargeId", "PeriodId");
                });

            builder.Entity("Host.Models.Protection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FareClassId");

                    b.Property<string>("Type");

                    b.Property<double>("Value");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrandId");

                    b.Property<int?>("ChargeId");

                    b.Property<int?>("DestinationId");

                    b.Property<int?>("OriginId");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.RouteFareClassList", b =>
                {
                    b.Property<int>("RouteId");

                    b.Property<int>("FareClassId");

                    b.Property<int?>("CurrencyId");

                    b.Property<double>("Mean");

                    b.Property<int?>("PeriodId");

                    b.Property<double>("StDev");

                    b.Property<double>("Value");

                    b.Key("RouteId", "FareClassId");
                });

            builder.Entity("Host.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Key("Id");
                });

            builder.Entity("Host.Models.Charge", b =>
                {
                    b.Reference("Host.Models.Currency")
                        .InverseCollection()
                        .ForeignKey("CurrencyId");
                });

            builder.Entity("Host.Models.Charges", b =>
                {
                    b.Reference("Host.Models.Charge")
                        .InverseCollection()
                        .ForeignKey("Charge2Id");

                    b.Reference("Host.Models.Charge")
                        .InverseCollection()
                        .ForeignKey("ChargeId");
                });

            builder.Entity("Host.Models.CustomerTypeList", b =>
                {
                    b.Reference("Host.Models.Customer")
                        .InverseCollection()
                        .ForeignKey("CustomerId");

                    b.Reference("Host.Models.CustomerType")
                        .InverseCollection()
                        .ForeignKey("CustomerTypeId");
                });

            builder.Entity("Host.Models.PeriodCharges", b =>
                {
                    b.Reference("Host.Models.Charge")
                        .InverseCollection()
                        .ForeignKey("ChargeId");

                    b.Reference("Host.Models.Period")
                        .InverseCollection()
                        .ForeignKey("PeriodId");
                });

            builder.Entity("Host.Models.Protection", b =>
                {
                    b.Reference("Host.Models.FareClass")
                        .InverseCollection()
                        .ForeignKey("FareClassId");
                });

            builder.Entity("Host.Models.Route", b =>
                {
                    b.Reference("Host.Models.Brand")
                        .InverseCollection()
                        .ForeignKey("BrandId");

                    b.Reference("Host.Models.Charge")
                        .InverseCollection()
                        .ForeignKey("ChargeId");

                    b.Reference("Host.Models.Station")
                        .InverseCollection()
                        .ForeignKey("DestinationId");

                    b.Reference("Host.Models.Station")
                        .InverseCollection()
                        .ForeignKey("OriginId");
                });

            builder.Entity("Host.Models.RouteFareClassList", b =>
                {
                    b.Reference("Host.Models.Currency")
                        .InverseCollection()
                        .ForeignKey("CurrencyId");

                    b.Reference("Host.Models.FareClass")
                        .InverseCollection()
                        .ForeignKey("FareClassId");

                    b.Reference("Host.Models.Period")
                        .InverseCollection()
                        .ForeignKey("PeriodId");

                    b.Reference("Host.Models.Route")
                        .InverseCollection()
                        .ForeignKey("RouteId");
                });
        }
    }
}
