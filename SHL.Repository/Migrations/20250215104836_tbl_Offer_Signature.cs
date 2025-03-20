using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_Offer_Signature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EquityPrice",
                table: "Offer",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedValue",
                table: "Offer",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExcercisePrice",
                table: "Offer",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsOfferSigned",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SignatureUrl",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignedDate",
                table: "Offer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignedOfferUrl",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquityPrice",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "EstimatedValue",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ExcercisePrice",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "IsOfferSigned",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SignatureUrl",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SignedDate",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "SignedOfferUrl",
                table: "Offer");
        }
    }
}
