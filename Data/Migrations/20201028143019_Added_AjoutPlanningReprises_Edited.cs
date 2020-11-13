using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class Added_AjoutPlanningReprises_Edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MonitorId",
                table: "PlanningReprisesModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MonitorId",
                table: "PlanningReprisesModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
