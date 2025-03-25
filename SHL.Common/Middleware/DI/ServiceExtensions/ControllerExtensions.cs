using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SHL.Domain.Models;

public static class ControllerExtensions
{
    public static IServiceCollection AddCustomValidationController(this IServiceCollection services)
    {
        var defaultBatchHandler = new DefaultODataBatchHandler();
        defaultBatchHandler.MessageQuotas.MaxNestingDepth = 2;
        defaultBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 10;
        defaultBatchHandler.MessageQuotas.MaxReceivedMessageSize = 100;

        services.AddControllers()
                    // .AddOData(options =>
                    //     options
                    //     .AddRouteComponents("shl/odata", GetEdmModel(),batchHandler: defaultBatchHandler)
                    //     .AddRouteComponents("shl/odata", GetEmployeeEdmModel())
                    //     .Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
                    //     )
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var response = new
            {
                status = false,
                responseCode = "400",
                ResponseMessage = "Validation errors occurred.",
                errors
            };
            return new BadRequestObjectResult(response);
        };
    });
        return services;
    }

    static string Namespace = "EquityPlan";
    private static IEdmModel GetEdmModel()
    {
        var modelBuilder = new ODataConventionModelBuilder()
        {
            Namespace = Namespace,
            ContainerName = "EquityPlanContainer"
        };
        var userEntity = modelBuilder.EntitySet<CompanyUser>(nameof(CompanyUser));
        userEntity.EntityType.Ignore(i => i.PasswordHash);
        userEntity.EntityType.Ignore(i => i.NormalizedUserName);
        userEntity.EntityType.Ignore(i => i.Email);
        userEntity.EntityType.Ignore(i => i.NormalizedEmail);
        userEntity.EntityType.Ignore(i => i.ConcurrencyStamp);
        userEntity.EntityType.Ignore(i => i.PhoneNumber);
        userEntity.EntityType.Ignore(i => i.PhoneNumberConfirmed);
        userEntity.EntityType.Ignore(i => i.TwoFactorEnabled);
        userEntity.EntityType.Ignore(i => i.SecurityStamp);


        modelBuilder.EntitySet<Broker>(nameof(Broker));
        modelBuilder.EntitySet<EquityPlan>(nameof(EquityPlan));
        modelBuilder.EntitySet<Offer>(nameof(Offer));
        modelBuilder.EntitySet<VestedShareTransfer>(nameof(VestedShareTransfer));
        modelBuilder.EntitySet<Company>(nameof(Company));
        modelBuilder.EntitySet<ContractDocument>(nameof(ContractDocument));
        modelBuilder.EntitySet<TransactionHistory>(nameof(TransactionHistory));
        modelBuilder.EntitySet<Shareholder>(nameof(Shareholder));
        modelBuilder.EntitySet<GenerateDividend>(nameof(GenerateDividend));
        modelBuilder.EntitySet<Dividend>(nameof(Dividend));
        modelBuilder.EntitySet<DividendTransactionHistory>(nameof(DividendTransactionHistory));
        modelBuilder.EntitySet<DividendPayoutRequest>(nameof(DividendPayoutRequest));
        modelBuilder.EntitySet<CompanyDepartment>(nameof(CompanyDepartment));
        modelBuilder.EntitySet<AppSetting>(nameof(AppSetting));
        modelBuilder.EntitySet<ExcerciseRequest>(nameof(ExcerciseRequest));

        return modelBuilder.GetEdmModel();
    }

    private static IEdmModel GetEmployeeEdmModel()
    {
        var modelBuilder = new ODataConventionModelBuilder()
        {
            Namespace = Namespace,
            ContainerName = "EquityPlanContainer"
        };
                      
        modelBuilder.EntitySet<EquityPlan>(nameof(EquityPlan));
        modelBuilder.EntitySet<Offer>(nameof(Offer));
        modelBuilder.EntitySet<VestedShareTransfer>(nameof(VestedShareTransfer));
        modelBuilder.EntitySet<TransactionHistory>(nameof(TransactionHistory));
        modelBuilder.EntitySet<Shareholder>(nameof(Shareholder));
        modelBuilder.EntitySet<ContractDocument>(nameof(ContractDocument));
        modelBuilder.EntitySet<Dividend>(nameof(Dividend));
        modelBuilder.EntitySet<DividendTransactionHistory>(nameof(DividendTransactionHistory));
        modelBuilder.EntitySet<DividendPayoutRequest>(nameof(DividendPayoutRequest));
        modelBuilder.EntitySet<CompanyDepartment>(nameof(CompanyDepartment));
        modelBuilder.EntitySet<ExcerciseRequest>(nameof(ExcerciseRequest));

        return modelBuilder.GetEdmModel();
    }
}
