using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_AppSetting_ExerciseRequestTax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExerciseRequestTaxValue",
                table: "tbl_AppSetting",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0.0m);

            //migrationBuilder.UpdateData(
            //    table: "tbl_AppSetting",
            //    keyColumn: "Id",
            //    keyValue: new Guid("820fbf71-5e1a-4bcc-8a22-be82309e1311"),
            //    columns: new string[0],
            //    values: new object[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseRequestTaxValue",
                table: "tbl_AppSetting");
        }
    }
}
