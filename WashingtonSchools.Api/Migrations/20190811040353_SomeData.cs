using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WashingtonSchools.Api.Migrations
{
    public partial class SomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "City", "Name", "State" },
                values: new object[] { new Guid("6cef9446-b814-45ef-bb2a-3a3519f7e998"), "New York City", "MySchool", "NY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("6cef9446-b814-45ef-bb2a-3a3519f7e998"));
        }
    }
}
