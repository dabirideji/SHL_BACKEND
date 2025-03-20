using SHL.Application.Interfaces;
using SHL.Domain.Models.Categories;

public class DatabaseContextAccessor : IDatabaseContextAccessor

{
    private readonly IHttpContextService _httpContextService;
    public DatabaseContextAccessor(IHttpContextService httpContextService)
    {
        this._httpContextService = httpContextService;

    }

    public DatabaseContextType GetDatabaseContextType()
    {
        var type = _httpContextService.Get<DatabaseContextType>("X-DATABASE-TYPE");
        if (type == null)
        {
            return DatabaseContextType.TENNANT;
        }
        return type;
    }
}