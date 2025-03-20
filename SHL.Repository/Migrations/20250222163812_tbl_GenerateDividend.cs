using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_GenerateDividend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GenerateDividendId",
                table: "tbl_Dividend",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbl_GenerateDividend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DividendPerShare = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxInPercentage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GenerateDividend", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Dividend_GenerateDividendId",
                table: "tbl_Dividend",
                column: "GenerateDividendId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Dividend_tbl_GenerateDividend_GenerateDividendId",
                table: "tbl_Dividend",
                column: "GenerateDividendId",
                principalTable: "tbl_GenerateDividend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Dividend_tbl_GenerateDividend_GenerateDividendId",
                table: "tbl_Dividend");

            migrationBuilder.DropTable(
                name: "tbl_GenerateDividend");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Dividend_GenerateDividendId",
                table: "tbl_Dividend");

            migrationBuilder.DropColumn(
                name: "GenerateDividendId",
                table: "tbl_Dividend");
        }
    }
}
