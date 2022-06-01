using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2PChat.Migrations
{
    public partial class lastseen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LastSeen",
                table: "Peers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSeen",
                table: "Peers");
        }
    }
}
