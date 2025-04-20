using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SHL.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedFakeUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: true),
                    LogBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogInitiator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogPayload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogServerInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDatabaseConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatabaseType = table.Column<int>(type: "int", nullable: true),
                    DatabaseStatus = table.Column<int>(type: "int", nullable: true),
                    DatabaseConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDatabaseConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactHeldInTrust = table.Column<double>(type: "float", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmployeeIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanCompanyUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StaffStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "ACTIVE"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanCompanyUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcerciseSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExcerciseSettingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcerciseSettingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExerciseCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FakeUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationSenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationReceiverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitationType = table.Column<int>(type: "int", nullable: true),
                    InvitationStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationType = table.Column<int>(type: "int", nullable: true),
                    NotificationAudience = table.Column<int>(type: "int", nullable: true),
                    NotificationMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayoutAccountUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayoutAccountIsVerified = table.Column<bool>(type: "bit", nullable: false),
                    PayoutAccountBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayoutAccountIdentificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayoutAccountAccountType = table.Column<int>(type: "int", nullable: true),
                    PayoutAccountStatus = table.Column<int>(type: "int", nullable: true),
                    PayoutAccountAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AppSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanEmployeeTransferShares = table.Column<bool>(type: "bit", nullable: false),
                    AllowIncentive = table.Column<bool>(type: "bit", nullable: false),
                    ToggleRsuEquityType = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ToggleOptionsEquityType = table.Column<bool>(type: "bit", nullable: false),
                    ToggleSharePlan = table.Column<bool>(type: "bit", nullable: false),
                    ExerciseRequestTaxValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Broker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrokerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Broker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyCurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "NGN"),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NormalizedDomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DividendPayoutRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DividendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeclineComment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DividendPayoutRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_GenerateDividend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DividendPerShare = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxInPercentage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GenerateDividend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUniqueId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UserEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenType = table.Column<int>(type: "int", nullable: true),
                    UserReferenceValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenStatus = table.Column<int>(type: "int", nullable: false),
                    TokenExpiryDurationInMins = table.Column<int>(type: "int", nullable: false),
                    TokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentFileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletStatus = table.Column<int>(type: "int", nullable: true),
                    WalletType = table.Column<int>(type: "int", nullable: true),
                    WalletCheckedBalance = table.Column<double>(type: "float", nullable: false),
                    WalletAvailableBalance = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquityPlanUserClaim_EquityPlanCompanyUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EquityPlanCompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_EquityPlanUserLogin_EquityPlanCompanyUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EquityPlanCompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_EquityPlanUserToken_EquityPlanCompanyUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EquityPlanCompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquityPlanRoleClaim_EquityPlanRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EquityPlanRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquityPlanUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlanUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EquityPlanUserRole_EquityPlanCompanyUser_UserId",
                        column: x => x.UserId,
                        principalTable: "EquityPlanCompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquityPlanUserRole_EquityPlanRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EquityPlanRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationActivityNotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationActivityNotificationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationActivityReadStatus = table.Column<int>(type: "int", nullable: true),
                    NotificationActivityReadAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "tbl_Dividend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenerateDividendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityPlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DividendValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnClaimedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClaimedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxInPercentage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Dividend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Dividend_tbl_GenerateDividend_GenerateDividendId",
                        column: x => x.GenerateDividendId,
                        principalTable: "tbl_GenerateDividend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DividendTransactionHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DividendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DividendTransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_DividendTransactionHistory_tbl_Dividend_DividendId",
                        column: x => x.DividendId,
                        principalTable: "tbl_Dividend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySharePriceValuation = table.Column<double>(type: "float", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTotalShareAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CompanyAvailableShareAmount = table.Column<double>(type: "float", nullable: true),
                    CompanyInfrastructureStatus = table.Column<int>(type: "int", nullable: true),
                    CompanyInfrastructureType = table.Column<int>(type: "int", nullable: true),
                    CompanyInfrastructureConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanySubscriptionCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanySubscriptionSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanySubscriptionBilledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanySubscriptionExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanySubscriptionNextBilledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanySubscriptionRenewalType = table.Column<int>(type: "int", nullable: true),
                    CompanySubscriptionStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "EquityPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalEquity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Allocated = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnAllocated = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PercentageTotalEquity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PercentageAllocated = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EquityType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquityPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquityPlan_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionPools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionPoolCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptionPoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionPoolTotalShares = table.Column<double>(type: "float", nullable: false),
                    OptionPoolType = table.Column<int>(type: "int", nullable: false),
                    OptionPoolStatus = table.Column<int>(type: "int", nullable: true),
                    OptionPoolApprovalStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionPools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionPools_Companies_OptionPoolCompanyId",
                        column: x => x.OptionPoolCompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_CompanyDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedDepartment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CompanyDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CompanyDepartment_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Shareholder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CscsNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChnNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BrokerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShareHolderEmployeeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShareholderPhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShareholderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShareholderAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ShareholderEmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Holding = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PercentageHolding = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Shareholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Shareholder_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    CompanyUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StaffDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StaffGrade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CscsNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChnNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StaffStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Staff_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Staff_EquityPlanCompanyUser_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "EquityPlanCompanyUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SettingValueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingValueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "ContractDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquityPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContractDocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDocument_EquityPlan_EquityPlanId",
                        column: x => x.EquityPlanId,
                        principalTable: "EquityPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    BalanceOfferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EstimatedOfferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Ownership in percentage"),
                    VestStartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when vesting starts"),
                    VestEndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when vesting ends"),
                    VestingPeriod = table.Column<double>(type: "float", nullable: false, comment: "duration for vesting"),
                    GrantDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "date when record was added"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "such as awaiting, vesting, vested. Awaiting means offer while vesting and vested means Portfolio"),
                    EquityPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExcercisePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsOfferSigned = table.Column<bool>(type: "bit", nullable: false),
                    SignatureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SignedOfferUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Grants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrantOptionPoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrantStrikePrice = table.Column<double>(type: "float", nullable: false),
                    GrantExercisePrice = table.Column<double>(type: "float", nullable: false),
                    GrantShareAmountTotal = table.Column<double>(type: "float", nullable: false),
                    GrantShareAmountAvailable = table.Column<double>(type: "float", nullable: false),
                    GrantShareAmountVested = table.Column<double>(type: "float", nullable: false),
                    GrantShareAmountUnvested = table.Column<double>(type: "float", nullable: false),
                    GrantStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grants_OptionPools_GrantOptionPoolId",
                        column: x => x.GrantOptionPoolId,
                        principalTable: "OptionPools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OptionPoolApprovals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionPoolOptionPoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptionPoolApprovalApproverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionPoolApprovalApprovalValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionPoolApprovalApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionPoolApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionPoolApprovals_OptionPools_OptionPoolOptionPoolId",
                        column: x => x.OptionPoolOptionPoolId,
                        principalTable: "OptionPools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoolDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferPoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolDocuments_OptionPools_OfferPoolId",
                        column: x => x.OfferPoolId,
                        principalTable: "OptionPools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_tbl_Staff_EmployeeStaffId",
                        column: x => x.EmployeeStaffId,
                        principalTable: "tbl_Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_StaffBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SwitfCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StaffBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_StaffBank_tbl_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "tbl_Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ExcerciseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HolderEmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExercisePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeclineReason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ExcerciseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ExcerciseRequest_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_VestedShareTransfer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolderEmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransferValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CscsNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChnNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BrokerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcessedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeclineComment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_VestedShareTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_VestedShareTransfer_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionHolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionHolderGrantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionHolderEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionHolderStaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionHolderAmount = table.Column<double>(type: "float", nullable: false),
                    OptionHolderDilutedEquityPercentage = table.Column<double>(type: "float", nullable: false),
                    OptionHolderStatus = table.Column<int>(type: "int", nullable: false),
                    OptionHolderVestingStatus = table.Column<int>(type: "int", nullable: false),
                    OptionHoldingIsSent = table.Column<bool>(type: "bit", nullable: false),
                    OptionHoldingIsSigned = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionHolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionHolders_Grants_OptionHolderGrantId",
                        column: x => x.OptionHolderGrantId,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionHolders_tbl_Staff_OptionHolderStaffId",
                        column: x => x.OptionHolderStaffId,
                        principalTable: "tbl_Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalShareAmount = table.Column<double>(type: "float", nullable: true),
                    TotalShareValuation = table.Column<double>(type: "float", nullable: true),
                    DilutedOwnershipPercentage = table.Column<double>(type: "float", nullable: true),
                    TotalShareUnits = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Grants_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Grants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Portfolios_tbl_Staff_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tbl_Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VestingSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VestingType = table.Column<int>(type: "int", nullable: true),
                    VestingForPeriod = table.Column<int>(type: "int", nullable: true),
                    VestingForValue = table.Column<int>(type: "int", nullable: true),
                    VestingEveryPeriod = table.Column<int>(type: "int", nullable: true),
                    VestingEveryValue = table.Column<int>(type: "int", nullable: true),
                    VestSpecificAmount = table.Column<double>(type: "float", nullable: true),
                    VestRelativePercentage = table.Column<double>(type: "float", nullable: true),
                    VestAmountInUnit = table.Column<double>(type: "float", nullable: true),
                    VestingAvailability = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VestingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VestingSchedules_Grants_GrantId",
                        column: x => x.GrantId,
                        principalTable: "Grants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionHolderSignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionHolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignatureFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionHolderSignatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionHolderSignatures_OptionHolders_OptionHolderId",
                        column: x => x.OptionHolderId,
                        principalTable: "OptionHolders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VestingActivations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionHolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VestingScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VestingActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VestingRelativePercentage = table.Column<double>(type: "float", nullable: false),
                    VestingDilutedPercentage = table.Column<double>(type: "float", nullable: false),
                    VestingOpeningPercentage = table.Column<double>(type: "float", nullable: false),
                    VestingAmountInShares = table.Column<double>(type: "float", nullable: false),
                    VestingAmountInValuation = table.Column<double>(type: "float", nullable: false),
                    VestingStatus = table.Column<int>(type: "int", nullable: false),
                    IsCliff = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VestingActivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VestingActivations_OptionHolders_OptionHolderId",
                        column: x => x.OptionHolderId,
                        principalTable: "OptionHolders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VestingActivations_VestingSchedules_VestingScheduleId",
                        column: x => x.VestingScheduleId,
                        principalTable: "VestingSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EquityPlanRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93be1e09-c686-4bb2-8e1b-8594f5585dd9", "32a5a6e8-0ade-45fb-a751-f469e975b66d", "Employer", "EMPLOYER" },
                    { "acac7fb6-7c4a-4da8-a22e-47caab9928a9", "2fca74f5-8568-4b34-ac21-5b8a91de0372", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "tbl_AppSetting",
                columns: new[] { "Id", "AllowIncentive", "CanEmployeeTransferShares", "CreatedAt", "ExerciseRequestTaxValue", "ToggleOptionsEquityType", "ToggleRsuEquityType", "ToggleSharePlan", "UpdatedAt" },
                values: new object[] { new Guid("820fbf71-5e1a-4bcc-8a22-be82309e1311"), false, false, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, false, true, false, null });

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
                name: "IX_ContractDocument_EquityPlanId",
                table: "ContractDocument",
                column: "EquityPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentDetails_EmployeeStaffId",
                table: "EmploymentDetails",
                column: "EmployeeStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EquityPlan_CompanyId",
                table: "EquityPlan",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "EquityPlanCompanyUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "EquityPlanCompanyUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "EquityPlanRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EquityPlanRoleClaim_RoleId",
                table: "EquityPlanRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EquityPlanUserClaim_UserId",
                table: "EquityPlanUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquityPlanUserLogin_UserId",
                table: "EquityPlanUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquityPlanUserRole_RoleId",
                table: "EquityPlanUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Grants_GrantOptionPoolId",
                table: "Grants",
                column: "GrantOptionPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationActivities_NotificationActivityNotificationId",
                table: "NotificationActivities",
                column: "NotificationActivityNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_EquityPlanId",
                table: "Offer",
                column: "EquityPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionHolders_OptionHolderGrantId",
                table: "OptionHolders",
                column: "OptionHolderGrantId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionHolders_OptionHolderStaffId",
                table: "OptionHolders",
                column: "OptionHolderStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionHolderSignatures_OptionHolderId",
                table: "OptionHolderSignatures",
                column: "OptionHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionPoolApprovals_OptionPoolOptionPoolId",
                table: "OptionPoolApprovals",
                column: "OptionPoolOptionPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionPools_OptionPoolCompanyId",
                table: "OptionPools",
                column: "OptionPoolCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolDocuments_OfferPoolId",
                table: "PoolDocuments",
                column: "OfferPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_EmployeeId",
                table: "Portfolios",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_OptionId",
                table: "Portfolios",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingValue_CompanySettingId",
                table: "SettingValue",
                column: "CompanySettingId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CompanyDepartment_CompanyId",
                table: "tbl_CompanyDepartment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Dividend_GenerateDividendId",
                table: "tbl_Dividend",
                column: "GenerateDividendId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DividendTransactionHistory_DividendId",
                table: "tbl_DividendTransactionHistory",
                column: "DividendId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExcerciseRequest_OfferId",
                table: "tbl_ExcerciseRequest",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Shareholder_CompanyId",
                table: "tbl_Shareholder",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Staff_CompanyId",
                table: "tbl_Staff",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Staff_CompanyUserId",
                table: "tbl_Staff",
                column: "CompanyUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StaffBank_StaffId",
                table: "tbl_StaffBank",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_VestedShareTransfer_OfferId",
                table: "tbl_VestedShareTransfer",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VestingActivations_OptionHolderId",
                table: "VestingActivations",
                column: "OptionHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_VestingActivations_VestingScheduleId",
                table: "VestingActivations",
                column: "VestingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_VestingSchedules_GrantId",
                table: "VestingSchedules",
                column: "GrantId");

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
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContractDocument");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "EquityPlanRoleClaim");

            migrationBuilder.DropTable(
                name: "EquityPlanUserClaim");

            migrationBuilder.DropTable(
                name: "EquityPlanUserLogin");

            migrationBuilder.DropTable(
                name: "EquityPlanUserRole");

            migrationBuilder.DropTable(
                name: "EquityPlanUserToken");

            migrationBuilder.DropTable(
                name: "ExcerciseSettings");

            migrationBuilder.DropTable(
                name: "FakeUsers");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "NotificationActivities");

            migrationBuilder.DropTable(
                name: "OptionHolderSignatures");

            migrationBuilder.DropTable(
                name: "OptionPoolApprovals");

            migrationBuilder.DropTable(
                name: "PayoutAccounts");

            migrationBuilder.DropTable(
                name: "PoolDocuments");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "SettingValue");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "tbl_AppSetting");

            migrationBuilder.DropTable(
                name: "tbl_Broker");

            migrationBuilder.DropTable(
                name: "tbl_CompanyDepartment");

            migrationBuilder.DropTable(
                name: "tbl_CompanyInfo");

            migrationBuilder.DropTable(
                name: "tbl_DividendPayoutRequest");

            migrationBuilder.DropTable(
                name: "tbl_DividendTransactionHistory");

            migrationBuilder.DropTable(
                name: "tbl_ExcerciseRequest");

            migrationBuilder.DropTable(
                name: "tbl_Shareholder");

            migrationBuilder.DropTable(
                name: "tbl_StaffBank");

            migrationBuilder.DropTable(
                name: "tbl_TransactionHistory");

            migrationBuilder.DropTable(
                name: "tbl_VestedShareTransfer");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UploadedDocuments");

            migrationBuilder.DropTable(
                name: "VestingActivations");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "EquityPlanRole");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "tbl_Dividend");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "OptionHolders");

            migrationBuilder.DropTable(
                name: "VestingSchedules");

            migrationBuilder.DropTable(
                name: "tbl_GenerateDividend");

            migrationBuilder.DropTable(
                name: "EquityPlan");

            migrationBuilder.DropTable(
                name: "tbl_Staff");

            migrationBuilder.DropTable(
                name: "Grants");

            migrationBuilder.DropTable(
                name: "EquityPlanCompanyUser");

            migrationBuilder.DropTable(
                name: "OptionPools");

            migrationBuilder.DropTable(
                name: "CompanySettings");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
