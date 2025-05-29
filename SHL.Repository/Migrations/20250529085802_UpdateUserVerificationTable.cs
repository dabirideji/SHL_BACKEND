using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserVerificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserVerification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "UserVerification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "UserVerification",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "False");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "UserVerification",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "False");

            migrationBuilder.AddColumn<int>(
                name: "lgaId",
                table: "UserVerification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DialingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lga_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_lgaId",
                table: "UserVerification",
                column: "lgaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_StateId",
                table: "UserVerification",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Lga_StateId",
                table: "Lga",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVerification_Country_lgaId",
                table: "UserVerification",
                column: "lgaId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVerification_Lga_lgaId",
                table: "UserVerification",
                column: "lgaId",
                principalTable: "Lga",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVerification_State_StateId",
                table: "UserVerification",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVerification_Country_lgaId",
                table: "UserVerification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVerification_Lga_lgaId",
                table: "UserVerification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVerification_State_StateId",
                table: "UserVerification");

            migrationBuilder.DropTable(
                name: "Lga");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_UserVerification_lgaId",
                table: "UserVerification");

            migrationBuilder.DropIndex(
                name: "IX_UserVerification_StateId",
                table: "UserVerification");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserVerification");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "UserVerification");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "UserVerification");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "UserVerification");

            migrationBuilder.DropColumn(
                name: "lgaId",
                table: "UserVerification");
        }
    }
}
