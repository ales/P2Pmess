using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2PChat.Migrations
{
    public partial class peer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peers",
                columns: table => new
                {
                    IPPort = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peers", x => x.IPPort);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peers");
        }
    }
}
