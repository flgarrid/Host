using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace HostMigrations
{
    public partial class migration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    ISO = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
            migration.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Address = table.Column(type: "nvarchar(max)", nullable: true),
                    Anonymous = table.Column(type: "bit", nullable: false),
                    BirthDate = table.Column(type: "datetime2", nullable: false),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column(type: "nvarchar(max)", nullable: true),
                    IdentityDocument = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
            migration.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Type = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });
            migration.CreateTable(
                name: "FareClass",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareClass", x => x.Id);
                });
            migration.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    From = table.Column(type: "datetime2", nullable: false),
                    Recurrency = table.Column(type: "nvarchar(max)", nullable: true),
                    To = table.Column(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });
            migration.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    CurrencyId = table.Column(type: "int", nullable: true),
                    POS = table.Column(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column(type: "int", nullable: false),
                    Restrictions = table.Column(type: "nvarchar(max)", nullable: true),
                    Type = table.Column(type: "nvarchar(max)", nullable: true),
                    Value = table.Column(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Currency_CurrencyId",
                        columns: x => x.CurrencyId,
                        referencedTable: "Currency",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "CustomerTypeList",
                columns: table => new
                {
                    CustomerId = table.Column(type: "int", nullable: false),
                    CustomerTypeId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypeList", x => new { x.CustomerId, x.CustomerTypeId });
                    table.ForeignKey(
                        name: "FK_CustomerTypeList_Customer_CustomerId",
                        columns: x => x.CustomerId,
                        referencedTable: "Customer",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerTypeList_CustomerType_CustomerTypeId",
                        columns: x => x.CustomerTypeId,
                        referencedTable: "CustomerType",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Protection",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    FareClassId = table.Column(type: "int", nullable: true),
                    Type = table.Column(type: "nvarchar(max)", nullable: true),
                    Value = table.Column(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protection_FareClass_FareClassId",
                        columns: x => x.FareClassId,
                        referencedTable: "FareClass",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    ChargeId = table.Column(type: "int", nullable: false),
                    Charge2Id = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => new { x.ChargeId, x.Charge2Id });
                    table.ForeignKey(
                        name: "FK_Charges_Charge_Charge2Id",
                        columns: x => x.Charge2Id,
                        referencedTable: "Charge",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Charges_Charge_ChargeId",
                        columns: x => x.ChargeId,
                        referencedTable: "Charge",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "PeriodCharges",
                columns: table => new
                {
                    ChargeId = table.Column(type: "int", nullable: false),
                    PeriodId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodCharges", x => new { x.ChargeId, x.PeriodId });
                    table.ForeignKey(
                        name: "FK_PeriodCharges_Charge_ChargeId",
                        columns: x => x.ChargeId,
                        referencedTable: "Charge",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodCharges_Period_PeriodId",
                        columns: x => x.PeriodId,
                        referencedTable: "Period",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    ChargeId = table.Column(type: "int", nullable: true),
                    Destination = table.Column(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Charge_ChargeId",
                        columns: x => x.ChargeId,
                        referencedTable: "Charge",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "RouteFareClassList",
                columns: table => new
                {
                    RouteId = table.Column(type: "int", nullable: false),
                    FareClassId = table.Column(type: "int", nullable: false),
                    CurrencyId = table.Column(type: "int", nullable: true),
                    Mean = table.Column(type: "float", nullable: false),
                    PeriodId = table.Column(type: "int", nullable: true),
                    StDev = table.Column(type: "float", nullable: false),
                    Value = table.Column(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteFareClassList", x => new { x.RouteId, x.FareClassId });
                    table.ForeignKey(
                        name: "FK_RouteFareClassList_Currency_CurrencyId",
                        columns: x => x.CurrencyId,
                        referencedTable: "Currency",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteFareClassList_FareClass_FareClassId",
                        columns: x => x.FareClassId,
                        referencedTable: "FareClass",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteFareClassList_Period_PeriodId",
                        columns: x => x.PeriodId,
                        referencedTable: "Period",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteFareClassList_Route_RouteId",
                        columns: x => x.RouteId,
                        referencedTable: "Route",
                        referencedColumn: "Id");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Charges");
            migration.DropTable("CustomerTypeList");
            migration.DropTable("PeriodCharges");
            migration.DropTable("Protection");
            migration.DropTable("RouteFareClassList");
            migration.DropTable("Customer");
            migration.DropTable("CustomerType");
            migration.DropTable("FareClass");
            migration.DropTable("Period");
            migration.DropTable("Route");
            migration.DropTable("Charge");
            migration.DropTable("Currency");
        }
    }
}
