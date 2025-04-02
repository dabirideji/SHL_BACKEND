using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using SHL.Repository.Repositories;
using SHL.Repository.Repositories.GenericRepositoryImplementations;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDbMigration, DbMigration>();
        services.AddScoped<IDbContextRepository, DbContextRepository>();
        services.AddScoped<IDbRepository, DapperDbRepository>();
        services.AddScoped<IUnitOfWork, SHL.Repository.Repositories.UnitOfWork>();

        // Registering all repository interfaces with their implementations
        services.AddScoped<IBrokerRepository, BrokerRepository>();
        services.AddScoped<ICompanyDepartmentRepository, CompanyDepartmentRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        //services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
        services.AddScoped<IContractDocumentRepository, ContractDocumentRepository>();
        services.AddScoped<IDividendPayoutRequestRepository, DividendPayoutRequestRepository>();
        services.AddScoped<IDividendRepository, DividendRepository>();
        services.AddScoped<IDividendTransactionHistoryRepository, DividendTransactionHistoryRepository>();
        services.AddScoped<IEquityPlanRepository, EquityPlanRepository>();
        services.AddScoped<IExcerciseRequestRepository, ExcerciseRequestRepository>();
        services.AddScoped<IGenerateDividendRepository, GenerateDividendRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IShareholderRepository, ShareholderRepository>();
        services.AddScoped<IStaffBankRepository, StaffBankRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
        services.AddScoped<IVestedShareTransferRepository, VestedShareTransferRepository>();
        services.AddScoped<IAppSettingRepository, AppSettingRepository>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

        return services;
    }
}
