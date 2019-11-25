using Microsoft.EntityFrameworkCore.Migrations;

namespace japan_dashboard_api.Migrations
{
  public partial class init : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "PrefecturePopulations",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            prefectureIso = table.Column<string>(nullable: true),
            gender = table.Column<string>(nullable: true),
            age = table.Column<string>(nullable: true),
            population = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PrefecturePopulations", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Prefectures",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            prefectureEn = table.Column<string>(nullable: true),
            prefectureJp = table.Column<string>(nullable: true),
            region = table.Column<string>(nullable: true),
            iso = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Prefectures", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "PrefecturePopulations");

      migrationBuilder.DropTable(
          name: "Prefectures");
    }
  }
}
