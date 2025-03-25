using FluentValidation;

public static class ValidatorExtension
{
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        // services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault());
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}