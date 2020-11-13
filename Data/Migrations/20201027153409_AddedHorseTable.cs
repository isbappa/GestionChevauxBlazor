using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionChevauxBlazor.Data.Migrations
{
    public partial class AddedHorseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GestionChevauxModel",
                columns: table => new
                {
                    IdCheval = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionChevauxModel", x => x.IdCheval);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestionChevauxModel");
        }
    }
}
