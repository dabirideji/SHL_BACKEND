using InventoryManagement.Application.Services.Customer;
using SHL.Application.Interface.Jwt;

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
        services.AddScoped<IMailService, MailService>();
        return services;
    }
}