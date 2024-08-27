using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Migrations
{
    /// <inheritdoc />
    public partial class Addcitydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "citys",
                columns: new[] { "id", "city" },
                values: new object[] { new Guid("685f4dec-1e5a-4881-817c-932cdd4caf67"), "mozambic" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "citys",
                keyColumn: "id",
                keyValue: new Guid("685f4dec-1e5a-4881-817c-932cdd4caf67"));
        }
    }
}
