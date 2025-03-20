
public static class HttpContextAccessorExtension
{
    public static IServiceCollection RegisterHttpContextAccessor(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}
