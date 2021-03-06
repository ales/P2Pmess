using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2PChat.Migrations
{
    public partial class timestamp_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Messages_Timestamp",
                table: "Messages",
                column: "Timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_Timestamp",
                table: "Messages");
        }
    }
}
