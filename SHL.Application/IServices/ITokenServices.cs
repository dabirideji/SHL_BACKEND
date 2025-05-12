using SHL.Domain.Models.Identity;


namespace SHL.Application.IServices
{
    public interface ITokenServices
    {
        ValueTask<string> CreateTokenAsync(ApplicationUser user);
    }
}
