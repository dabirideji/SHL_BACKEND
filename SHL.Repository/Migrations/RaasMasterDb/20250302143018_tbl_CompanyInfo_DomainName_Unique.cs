using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations.SHLMasterDb
{
    /// <inheritdoc />
    public partial class tbl_CompanyInfo_DomainName_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_CompanyInfo_CompanyName",
                table: "tbl_CompanyInfo",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CompanyInfo_DomainName",
                table: "tbl_CompanyInfo",
                column: "DomainName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_CompanyInfo_CompanyName",
                table: "tbl_CompanyInfo");

            migrationBuilder.DropIndex(
                name: "IX_tbl_CompanyInfo_DomainName",
                table: "tbl_CompanyInfo");
        }
    }
}
