using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Migrations
{
    /// <inheritdoc />
    public partial class SalaryEdit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_employees_EmployeeId",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "salaries",
                newName: "Employeeid");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_EmployeeId",
                table: "salaries",
                newName: "IX_salaries_Employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_employees_Employeeid",
                table: "salaries",
                column: "Employeeid",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salaries_employees_Employeeid",
                table: "salaries");

            migrationBuilder.RenameColumn(
                name: "Employeeid",
                table: "salaries",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_salaries_Employeeid",
                table: "salaries",
                newName: "IX_salaries_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_salaries_employees_EmployeeId",
                table: "salaries",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
