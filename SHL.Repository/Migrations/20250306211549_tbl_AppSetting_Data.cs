using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_AppSetting_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_AppSetting",
                columns: new[] { "Id", "AllowIncentive", "CanEmployeeTransferShares", "CreatedAt", "ToggleOptionsEquityType", "ToggleRsuEquityType", "ToggleSharePlan", "UpdatedAt" },
                values: new object[] { new Guid("820fbf71-5e1a-4bcc-8a22-be82309e1311"), false, false, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_AppSetting",
                keyColumn: "Id",
                keyValue: new Guid("820fbf71-5e1a-4bcc-8a22-be82309e1311"));
        }
    }
}
