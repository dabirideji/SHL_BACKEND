using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations.SHLMasterDb
{
    /// <inheritdoc />
    public partial class tbl_CompanyInfo_ConString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "tbl_CompanyInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedDomainName",
                table: "tbl_CompanyInfo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "tbl_CompanyInfo");

            migrationBuilder.DropColumn(
                name: "NormalizedDomainName",
                table: "tbl_CompanyInfo");
        }
    }
}
