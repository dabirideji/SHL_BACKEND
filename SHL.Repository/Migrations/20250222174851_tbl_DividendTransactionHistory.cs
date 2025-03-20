using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_DividendTransactionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_DividendTransactionHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DividendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DividendTransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DividendTransactionHistory_tbl_Dividend_DividendId",
                        column: x => x.DividendId,
                        principalTable: "tbl_Dividend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DividendTransactionHistory_DividendId",
                table: "tbl_DividendTransactionHistory",
                column: "DividendId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DividendTransactionHistory");
        }
    }
}
