using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class Added_AjoutPlanningReprises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "GestionChevauxModel",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "GestionChevauxModel",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PlanningReprisesModel",
                columns: table => new
                {
                    IdProgram = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitorId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningReprisesModel", x => x.IdProgram);
                    table.ForeignKey(
                        name: "FK_PlanningReprisesModel_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningReprisesModel_ApplicationUserId",
                table: "PlanningReprisesModel",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningReprisesModel");

            migrationBuilder.AlterColumn<string>(
                name: "HorseName",
                table: "GestionChevauxModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "GestionChevauxModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }
    }
}
