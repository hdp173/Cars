using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyCars.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Driver''s Seat')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Heated Front Seats')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Active Blind-Spot Detection System')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Easy-to-Clean Seat & Floor Materials')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('USB Ports')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Built-In Navigation System')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Heated Windshield')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Power Front Passenger Seat')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Backup Collision Intervention/Auto Stop')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Leather Seats')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Side Mirror Turn Signals')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Hidden Storage for Computer/Purse')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Voice-Activated Controls')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Bluetooth Streaming Audio')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Push-button Ignition')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Features");
        }
    }
}
