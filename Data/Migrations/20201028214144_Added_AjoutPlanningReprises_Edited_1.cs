using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class Added_AjoutPlanningReprises_Edited_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningReprisesModel_AspNetUsers_ApplicationUserId",
                table: "PlanningReprisesModel");

            migrationBuilder.DropIndex(
                name: "IX_PlanningReprisesModel_ApplicationUserId",
                table: "PlanningReprisesModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PlanningReprisesModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PlanningReprisesModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanningReprisesModel_ApplicationUserId",
                table: "PlanningReprisesModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningReprisesModel_AspNetUsers_ApplicationUserId",
                table: "PlanningReprisesModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
