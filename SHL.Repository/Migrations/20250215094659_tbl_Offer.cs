using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tbl_Offer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferHolder = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Fullname of the offer owner"),
                    EquityHolderEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquityHolderUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Ownership"),
                    EstimatedOfferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Ownership in percentage"),
                    VestStartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when vesting starts"),
                    VestEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when vesting ends"),
                    VestingPeriod = table.Column<int>(type: "int", nullable: false, comment: "duration for vesting"),
                    GrantDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when record was added"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "such as awaiting, vesting, vested. Awaiting means offer while vesting and vested means Portfolio"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_EquityPlan_EquityPlanId",
                        column: x => x.EquityPlanId,
                        principalTable: "EquityPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_EquityPlanId",
                table: "Offer",
                column: "EquityPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");
        }
    }
}
