using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using SHL.Repository.Data.Context;
using SHL.Repository.Repositories;
using SHL.Repository.Repositories.GenericRepositoryImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEquityPlanRepository, EquityPlanRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            services.AddScoped<IVestedShareTransferRepository, VestedShareTransferRepository>();
            services.AddScoped<IBrokerRepository, BrokerRepository>();
            services.AddScoped<IShareholderRepository, ShareholderRepository>();
            services.AddScoped<IContractDocumentRepository, ContractDocumentRepository>();
            services.AddScoped<IDividendRepository, DividendRepository>();
            services.AddScoped<IGenerateDividendRepository, GenerateDividendRepository>();
            services.AddScoped<IDividendTransactionHistoryRepository, DividendTransactionHistoryRepository>();
            services.AddScoped<IDividendPayoutRequestRepository, DividendPayoutRequestRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffBankRepository, StaffBankRepository>();
            services.AddScoped<ICompanyDepartmentRepository, CompanyDepartmentRepository>();
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<IExcerciseRequestRepository, ExcerciseRequestRepository>();

            services.AddScoped<IUnitOfWork>(c => { return c.GetRequiredService<SHLTennantDbContext>(); });
            //services.AddScoped<TotpTokenProvider<OmniXUser>>();
            return services;
        }
    }
}
