using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Migrations
{
    /// <inheritdoc />
    public partial class Addunivercityemployeedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "univers",
                columns: new[] { "id", "Name" },
                values: new object[] { new Guid("4b5aed57-60e4-4710-9855-a35970991117"), "Sham" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "BirthDate", "CityId", "Father", "Functional_ID", "IsActive", "LastName", "Mather", "Name", "Salary_basis", "UniverCityId", "UniversityDegree", "date_of_employment" },
                values: new object[] { new Guid("5e44452c-4f92-4461-9acb-84c9251ea9cf"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("685f4dec-1e5a-4881-817c-932cdd4caf67"), "Ismail", 0, true, "Ismail", "sss", "MohamedIsmail", 1m, new Guid("4b5aed57-60e4-4710-9855-a35970991117"), 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: new Guid("5e44452c-4f92-4461-9acb-84c9251ea9cf"));

            migrationBuilder.DeleteData(
                table: "univers",
                keyColumn: "id",
                keyValue: new Guid("4b5aed57-60e4-4710-9855-a35970991117"));
        }
    }
}
