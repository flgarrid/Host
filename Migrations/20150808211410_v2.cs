using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace HostMigrations
{
    public partial class v2 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropColumn(name: "Destination", table: "Route");
            migration.DropColumn(name: "Origin", table: "Route");
            migration.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });
            migration.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                });
            migration.AddColumn(
                name: "BrandId",
                table: "Route",
                type: "int",
                nullable: true);
            migration.AddColumn(
                name: "DestinationId",
                table: "Route",
                type: "int",
                nullable: true);
            migration.AddColumn(
                name: "OriginId",
                table: "Route",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Route_Brand_BrandId",
                table: "Route",
                column: "BrandId",
                referencedTable: "Brand",
                referencedColumn: "Id");
            migration.AddForeignKey(
                name: "FK_Route_Station_DestinationId",
                table: "Route",
                column: "DestinationId",
                referencedTable: "Station",
                referencedColumn: "Id");
            migration.AddForeignKey(
                name: "FK_Route_Station_OriginId",
                table: "Route",
                column: "OriginId",
                referencedTable: "Station",
                referencedColumn: "Id");
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Route_Brand_BrandId", table: "Route");
            migration.DropForeignKey(name: "FK_Route_Station_DestinationId", table: "Route");
            migration.DropForeignKey(name: "FK_Route_Station_OriginId", table: "Route");
            migration.DropColumn(name: "BrandId", table: "Route");
            migration.DropColumn(name: "DestinationId", table: "Route");
            migration.DropColumn(name: "OriginId", table: "Route");
            migration.DropTable("Brand");
            migration.DropTable("Station");
            migration.AddColumn(
                name: "Destination",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddColumn(
                name: "Origin",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
