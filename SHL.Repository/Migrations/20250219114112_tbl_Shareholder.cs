using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_Shareholder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shareholders",
                table: "Shareholders");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Shareholders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Shareholders");

            migrationBuilder.DropColumn(
                name: "ShareholderNumber",
                table: "Shareholders");

            migrationBuilder.RenameTable(
                name: "Shareholders",
                newName: "tbl_Shareholder");

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderPhoneNumber",
                table: "tbl_Shareholder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderName",
                table: "tbl_Shareholder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderEmailAddress",
                table: "tbl_Shareholder",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderAddress",
                table: "tbl_Shareholder",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrokerId",
                table: "tbl_Shareholder",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ChnNumber",
                table: "tbl_Shareholder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "tbl_Shareholder",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CscsNumber",
                table: "tbl_Shareholder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Holding",
                table: "tbl_Shareholder",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageHolding",
                table: "tbl_Shareholder",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ShareHolderEmployeeId",
                table: "tbl_Shareholder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Shareholder",
                table: "tbl_Shareholder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Shareholder_CompanyId",
                table: "tbl_Shareholder",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Shareholder_Companies_CompanyId",
                table: "tbl_Shareholder",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Shareholder_Companies_CompanyId",
                table: "tbl_Shareholder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Shareholder",
                table: "tbl_Shareholder");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Shareholder_CompanyId",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "ChnNumber",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "CscsNumber",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "Holding",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "PercentageHolding",
                table: "tbl_Shareholder");

            migrationBuilder.DropColumn(
                name: "ShareHolderEmployeeId",
                table: "tbl_Shareholder");

            migrationBuilder.RenameTable(
                name: "tbl_Shareholder",
                newName: "Shareholders");

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderPhoneNumber",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderName",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderEmailAddress",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShareholderAddress",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShareholderNumber",
                table: "Shareholders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shareholders",
                table: "Shareholders",
                column: "Id");
        }
    }
}
