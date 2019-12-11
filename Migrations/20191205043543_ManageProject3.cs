using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageProject.Migrations
{
    public partial class ManageProject3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PlanCost",
                table: "Project",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ActualCost",
                table: "Project",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PlanCost",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "ActualCost",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
