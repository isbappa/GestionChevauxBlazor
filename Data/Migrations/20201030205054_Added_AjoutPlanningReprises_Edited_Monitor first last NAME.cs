using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class Added_AjoutPlanningReprises_Edited_MonitorfirstlastNAME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MonitorFisrtname",
                table: "PlanningReprisesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonitorLastname",
                table: "PlanningReprisesModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonitorFisrtname",
                table: "PlanningReprisesModel");

            migrationBuilder.DropColumn(
                name: "MonitorLastname",
                table: "PlanningReprisesModel");
        }
    }
}
