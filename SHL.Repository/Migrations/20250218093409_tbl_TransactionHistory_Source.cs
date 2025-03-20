using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_TransactionHistory_Source : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "tbl_TransactionHistory",
                newName: "UserUniqueId");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "tbl_TransactionHistory",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "tbl_TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "UserUniqueId",
                table: "tbl_TransactionHistory",
                newName: "CompanyUserId");
        }
    }
}
