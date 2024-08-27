using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "accessEmployees",
                columns: new[] { "Id", "IdEmployee", "Role" },
                values: new object[] { new Guid("ec72e51d-8c19-41b0-9e64-fe8c636f65fc"), new Guid("5e44452c-4f92-4461-9acb-84c9251ea9cf"), "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accessEmployees",
                keyColumn: "Id",
                keyValue: new Guid("ec72e51d-8c19-41b0-9e64-fe8c636f65fc"));
        }
    }
}
