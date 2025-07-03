using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Admin" },
                { 2, "User" },
                { 3, "Guest" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Roles", keyColumn: "Id", keyValues: new object[] { 1 });
            migrationBuilder.DeleteData(table: "Roles", keyColumn: "Id", keyValues: new object[] { 2 });
            migrationBuilder.DeleteData(table: "Roles", keyColumn: "Id", keyValues: new object[] { 3 });
        }
    }
}
