using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyCars.Migrations
{
    public partial class ModifyVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRegistered",
                table: "Vehicles",
                newName: "IsOwned");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "IsOwned",
                table: "Vehicles",
                newName: "IsRegistered");
        }
    }
}
