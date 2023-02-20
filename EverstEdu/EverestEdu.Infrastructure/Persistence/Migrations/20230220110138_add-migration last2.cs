using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverestEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationlast2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "Adminn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "Admin");
        }
    }
}
