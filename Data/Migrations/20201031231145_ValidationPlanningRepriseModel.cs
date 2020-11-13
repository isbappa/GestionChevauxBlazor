using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class ValidationPlanningRepriseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValidationPlanningRepriseModel",
                columns: table => new
                {
                    IdValidation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCheval_v = table.Column<string>(nullable: true),
                    HorseName_v = table.Column<string>(nullable: true),
                    MonitorID_v = table.Column<string>(nullable: true),
                    MonitorFirstname_v = table.Column<string>(nullable: true),
                    MonitorLastname_v = table.Column<string>(nullable: true),
                    RiderID_v = table.Column<string>(nullable: true),
                    RiderFirstname_v = table.Column<string>(nullable: true),
                    RiderLastname_v = table.Column<string>(nullable: true),
                    Date_v = table.Column<DateTime>(nullable: false),
                    Time_v = table.Column<DateTime>(nullable: false),
                    Available_v = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationPlanningRepriseModel", x => x.IdValidation);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationPlanningRepriseModel");
        }
    }
}
