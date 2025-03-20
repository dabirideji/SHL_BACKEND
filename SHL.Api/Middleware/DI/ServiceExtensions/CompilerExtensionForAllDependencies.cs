
using SHL.Repository;
using SHL.Api;
using SHL.Api.BackgroundServices;
using SHL.Api.Middleware.DI.ServiceExtensions;
using SHL.Application;
using SHL.Application.AppSettings;
using SHL.Infrastructure;

public static class CompilerExtensionForAllDependencies
{
    public static IServiceCollection BuildAndRegisterAllDependency(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddMapper();
        services.AddSignalR();
        services.AddHttpContextAccessor();
        services.AddMemoryCache();
        services.RegisterFactories();
        services.AddUnitOfWork();

        services.RegisterLogging();
        //services.RegisterHttpContextAccessor();
        services.AddManagers();
       // services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => c.ResolveConflictingActions(c => c.First()));
        services.AddValidations();
        services.AddDbContexts(configuration);
        services.AddCustomValidationController();
        services.AddEndpointsApiExplorer();
        services.AddAutoMapperConfig()
            .AddIdentity()
            .AddRepositories()
            .AddApplicationService(configuration)
            .AddInfrastructureService();


        services.AddHostedService<CreateStaffFromOfferBackgroundService>();
        services.AddHostedService<EmailBackgroundService>();
        services.AddHostedService<BulkCreateEmployeeBackgroundService>();

        #region BASIC SETUP
        services.Configure<JwtOptions>(configuration.GetSection("JWTCredentials"));
        #endregion


        #region DB CONTEXT SETUP
        #endregion

        #region DB CONNECTION ACCESSOR
        services.AddDbConnectionAccessor();
        #endregion

        #region APP SETTING ACCESSOR
        services.AddAppSettingAccessor();
        #endregion

        #region SERVICE REGISTRATION
        services.AddApplicationServices();
        #endregion

        #region SWAGGER SETUP
        services.AddSwaggerDocumentation();
        #endregion

        #region JWT AUTHENTICATION SETUP
        services.AddJwtAuthentication(configuration);
        #endregion

        #region Authorization
        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(SHLAuthorizationPolicy.Employer, policy => policy.RequireRole("Employer"));
            opt.AddPolicy(SHLAuthorizationPolicy.Employee, policy => policy.RequireRole("Employee"));
            opt.AddPolicy(SHLAuthorizationPolicy.All, policy => policy.RequireRole("Employee", "Employer"));
            
        });
        #endregion

        #region CORS POLICIES
        services.AddCorsPolicies();
        #endregion

        #region CACHING SETUP
        services.AddCaching();
        #endregion

        #region MISCELLANEOUS SERVICES
        services.AddDefaultHangfireConfiguration();
        services.AddMiscellaneousServices();
        #endregion
        return services;
    }
}
