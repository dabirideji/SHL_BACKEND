using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SqlServerCleanMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LogType = table.Column<int>(type: "INTEGER", nullable: true),
                    LogBody = table.Column<string>(type: "TEXT", nullable: true),
                    LogInitiator = table.Column<string>(type: "TEXT", nullable: true),
                    LogAction = table.Column<string>(type: "TEXT", nullable: true),
                    LogPayload = table.Column<string>(type: "TEXT", nullable: true),
                    LogResponse = table.Column<string>(type: "TEXT", nullable: true),
                    LogEndpoint = table.Column<string>(type: "TEXT", nullable: true),
                    LogServerInformation = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDatabaseConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatabaseType = table.Column<int>(type: "INTEGER", nullable: true),
                    DatabaseStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    DatabaseConnectionString = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDatabaseConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationTitle = table.Column<string>(type: "TEXT", nullable: true),
                    NotificationType = table.Column<int>(type: "INTEGER", nullable: true),
                    NotificationAudience = table.Column<int>(type: "INTEGER", nullable: true),
                    NotificationMessage = table.Column<string>(type: "TEXT", nullable: true),
                    NotificationBody = table.Column<string>(type: "TEXT", nullable: true),
                    NotificationStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleName = table.Column<string>(type: "TEXT", nullable: true),
                    RoleDescription = table.Column<string>(type: "TEXT", nullable: true),
                    RoleStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubscriptionName = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriptionCode = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriptionPrice = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TokenType = table.Column<int>(type: "INTEGER", nullable: true),
                    UserReferenceValue = table.Column<string>(type: "TEXT", nullable: true),
                    TokenTitle = table.Column<string>(type: "TEXT", nullable: true),
                    TokenCode = table.Column<string>(type: "TEXT", nullable: true),
                    TokenStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TokenExpiryDurationInMins = table.Column<int>(type: "INTEGER", nullable: false),
                    TokenExpiryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationActivityNotificationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationActivityNotificationUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationActivityReadStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    NotificationActivityReadAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationActivities_Notifications_NotificationActivityNotificationId",
                        column: x => x.NotificationActivityNotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyCode = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyCurrencyCode = table.Column<string>(type: "TEXT", nullable: true),
                    CompanySharePriceValuation = table.Column<double>(type: "REAL", nullable: false),
                    CompanyAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyDomainName = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyTotalShareAmount = table.Column<double>(type: "REAL", nullable: true),
                    CompanyAvailableShareAmount = table.Column<double>(type: "REAL", nullable: true),
                    CompanyInfrastructureStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyInfrastructureType = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanyInfrastructureConnectionString = table.Column<string>(type: "TEXT", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySettings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanySubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanySubscriptionCompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanySubscriptionSubscriptionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanySubscriptionBilledDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompanySubscriptionExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompanySubscriptionNextBilledDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompanySubscriptionRenewalType = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanySubscriptionStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySubscriptions_Companies_CompanySubscriptionCompanyId",
                        column: x => x.CompanySubscriptionCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanySubscriptions_Subscriptions_CompanySubscriptionSubscriptionId",
                        column: x => x.CompanySubscriptionSubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPhoneNumberVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDisabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    StaffCompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    StaffCode = table.Column<string>(type: "TEXT", nullable: true),
                    StaffDepartment = table.Column<string>(type: "TEXT", nullable: true),
                    StaffGrade = table.Column<string>(type: "TEXT", nullable: true),
                    StaffStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_StaffCompanyId",
                        column: x => x.StaffCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SettingValueName = table.Column<string>(type: "TEXT", nullable: true),
                    SettingValueDescription = table.Column<string>(type: "TEXT", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingValue_CompanySettings_CompanySettingId",
                        column: x => x.CompanySettingId,
                        principalTable: "CompanySettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserRoleUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserRoleRoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserRoleStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_UserRoleRoleId",
                        column: x => x.UserRoleRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserRoleUserId",
                        column: x => x.UserRoleUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanySettingId",
                table: "Companies",
                column: "CompanySettingId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_CompanyId",
                table: "CompanySettings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_CompanySubscriptionCompanyId",
                table: "CompanySubscriptions",
                column: "CompanySubscriptionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySubscriptions_CompanySubscriptionSubscriptionId",
                table: "CompanySubscriptions",
                column: "CompanySubscriptionSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationActivities_NotificationActivityNotificationId",
                table: "NotificationActivities",
                column: "NotificationActivityNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValue_CompanySettingId",
                table: "SettingValue",
                column: "CompanySettingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserRoleRoleId",
                table: "UserRoles",
                column: "UserRoleRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserRoleUserId",
                table: "UserRoles",
                column: "UserRoleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StaffCompanyId",
                table: "Users",
                column: "StaffCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanySettings_CompanySettingId",
                table: "Companies",
                column: "CompanySettingId",
                principalTable: "CompanySettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanySettings_CompanySettingId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CompanyDatabaseConnections");

            migrationBuilder.DropTable(
                name: "CompanySubscriptions");

            migrationBuilder.DropTable(
                name: "NotificationActivities");

            migrationBuilder.DropTable(
                name: "SettingValue");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CompanySettings");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
