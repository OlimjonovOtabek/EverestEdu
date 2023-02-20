using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverestEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addminverified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "0ECB2816A2503040F688FBCA733C728003EF613A0B7803DC1ACE1A01408630E0E9A52F18968A1F0B6D388950ABAD951685C934C4977251AED1F336650346C1E8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "CA5B9811BE39C13BA3F8265C006761214B85F36FFE177C482AA548A30FC2C8994F5AE33790A4AE6A302B65A05A906AAED4912F02C0E69FC6CE14A9C90AD998A0");
        }
    }
}
