namespace SHL.Interfaces
{
    public interface IUserPermissionService
    {
        Task<List<string>> GetUserPermissionsAsync(string userId);
    }
}