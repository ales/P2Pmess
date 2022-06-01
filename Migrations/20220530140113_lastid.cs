using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2PChat.Migrations
{
    public partial class lastid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastId",
                table: "Peers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastId",
                table: "Peers");
        }
    }
}
