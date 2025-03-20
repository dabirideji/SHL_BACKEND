using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_VestedShareTransfer_DeclineComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeclineComment",
                table: "tbl_VestedShareTransfer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ConnectionString",
            //    table: "tbl_CompanyInfo",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "NormalizedDomainName",
            //    table: "tbl_CompanyInfo",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclineComment",
                table: "tbl_VestedShareTransfer");

            //migrationBuilder.DropColumn(
            //    name: "ConnectionString",
            //    table: "tbl_CompanyInfo");

            //migrationBuilder.DropColumn(
            //    name: "NormalizedDomainName",
            //    table: "tbl_CompanyInfo");
        }
    }
}
