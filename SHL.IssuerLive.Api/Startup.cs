namespace SHL.Api.EntryPoint
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            
             SHL.Common.DI.Middleware.CompilerExtensionForAllDependencies.BuildAndRegisterAllDependency(services,_configuration);
        }

        public void Configure(WebApplication app)
        {
            app.UseCustomMiddleware();
        }
    }
}