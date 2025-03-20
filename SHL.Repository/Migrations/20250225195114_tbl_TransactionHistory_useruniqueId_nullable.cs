using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_TransactionHistory_useruniqueId_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserUniqueId",
                table: "tbl_TransactionHistory",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            //migrationBuilder.CreateTable(
            //    name: "tbl_CompanyInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CompanyCurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "NGN"),
            //        Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        DomainName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_CompanyInfo", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "tbl_CompanyInfo");

            migrationBuilder.AlterColumn<string>(
                name: "UserUniqueId",
                table: "tbl_TransactionHistory",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
