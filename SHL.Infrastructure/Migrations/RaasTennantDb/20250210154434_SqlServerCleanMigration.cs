using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHL.Infrastructure.Migrations.SHLTennantDb
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcerciseSettings", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shareholders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareholderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareholderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareholderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareholderEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareholderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shareholders", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocuments", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySharePriceValuation = table.Column<double>(type: "float", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTotalShareAmount = table.Column<double>(type: "float", nullable: true),
                    CompanyAvailableShareAmount = table.Column<double>(type: "float", nullable: true),
                    CompanyInfrastructureStatus = table.Column<int>(type: "int", nullable: true),
                    CompanyInfrastructureType = table.Column<int>(type: "int", nullable: true),
                    CompanyInfrastructureConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsPhoneNumberVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SettingValueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingValueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_Users_EmployeeStaffId",
                        column: x => x.EmployeeStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitations_Users_InvitationSenderId",
                        column: x => x.InvitationSenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayoutAccounts_Users_PayoutAccountUserId",
                        column: x => x.PayoutAccountUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCardDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCardDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_WalletUserId",
                        column: x => x.WalletUserId,
                        principalTable: "Users",
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_OptionHolders_Users_OptionHolderStaffId",
                        column: x => x.OptionHolderStaffId,
                        principalTable: "Users",
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_Portfolios_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_EmploymentDetails_EmployeeStaffId",
                table: "EmploymentDetails",
                column: "EmployeeStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Grants_GrantOptionPoolId",
                table: "Grants",
                column: "GrantOptionPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_InvitationSenderId",
                table: "Invitations",
                column: "InvitationSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationActivities_NotificationActivityNotificationId",
                table: "NotificationActivities",
                column: "NotificationActivityNotificationId");

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
                name: "IX_PayoutAccounts_PayoutAccountUserId",
                table: "PayoutAccounts",
                column: "PayoutAccountUserId");

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
                name: "IX_UserCardDetails_UserId",
                table: "UserCardDetails",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletUserId",
                table: "Wallets",
                column: "WalletUserId");

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
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "ExcerciseSettings");

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
                name: "Shareholders");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UploadedDocuments");

            migrationBuilder.DropTable(
                name: "UserCardDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "VestingActivations");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "OptionHolders");

            migrationBuilder.DropTable(
                name: "VestingSchedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Grants");

            migrationBuilder.DropTable(
                name: "OptionPools");

            migrationBuilder.DropTable(
                name: "CompanySettings");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
