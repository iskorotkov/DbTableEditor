using Microsoft.EntityFrameworkCore.Migrations;

namespace DbTableEditor.AspNetApp.Migrations
{
    public partial class Addalliances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "alliances",
                columns: new[] { "id", "name", "power" },
                values: new object[,]
                {
                    { 11, "Trade League", 300 },
                    { 12, "Eternal Alliance", 400 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "alliances",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "alliances",
                keyColumn: "id",
                keyValue: 12);
        }
    }
}
