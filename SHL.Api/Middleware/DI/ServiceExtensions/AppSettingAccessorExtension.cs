using SHL.Application.Interfaces;
using SHL.Application.Services;

public static class AppSettingAccessorExtension
{
    public static IServiceCollection AddAppSettingAccessor(this IServiceCollection services)
    {
        services.AddScoped<IAppSettingAccessor, AppSettingAccessor>();
        return services;
    }
}
