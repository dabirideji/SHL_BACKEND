using InventoryManagement.Application.Services.Customer;
using SHL.Application.Interface.Jwt;
using SHL.Application.Interfaces;
using SHL.Application.Services;



public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAppSettingAccessor, AppSettingAccessor>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IClientIdService, ClientIdService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IHttpContextService, HttpContextService>();
        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IOptionPoolService, OptionPoolService>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();
        services.AddScoped<IInvitationService, InvitationService>();
        services.AddScoped<IGrantService, GrantService>();
        services.AddScoped<IUploadedDocumentService, UploadedDocumentService>();
        services.AddScoped<IOptionPoolApprovalService, OptionPoolApprovalService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEmploymentDetailService, EmploymentDetailService>();
        services.AddScoped<IPayoutAccountService, PayoutAccountService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IOptionHolderService, OptionHolderService>();
        services.AddScoped<IPoolDocumentService, PoolDocumentService>();
        services.AddScoped<IPortfolioService, PortfolioService>();
        services.AddScoped<IOptionHolderSignatureService, OptionHolderSignatureService>();
        services.AddScoped<IVestingScheduleService, VestingScheduleService>();
        services.AddScoped<IBulkUploadService, BulkUploadService>();
        services.AddScoped<IShareholderService, ShareholderService>();
        services.AddScoped<ISurveyService, SurveyService>();
        return services;
    }
}