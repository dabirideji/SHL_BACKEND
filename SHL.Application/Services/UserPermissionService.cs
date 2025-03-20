// using Microsoft.Extensions.Caching.Memory;
// using SampleSetup.Interfaces;

// namespace SHL.Application.Interfaces
// {
//     public class UserPermissionService : IUserPermissionService
//     {
//         private readonly IUserRepository _userRepository;
//         private readonly IMemoryCache _cache;

//         public UserPermissionService(IUserRepository userRepository, IMemoryCache cache)
//         {
//             _userRepository = userRepository;
//             _cache = cache;
//         }

//         public async Task<List<string>> GetUserPermissionsAsync(string userId)
//         {
//             if (_cache.TryGetValue(userId, out List<string> cachedPermissions))
//             {
//                 return cachedPermissions;
//             }

//             var permissions = await _userRepository.GetPermissionsByUserIdAsync(userId);
//             // Cache permissions for 30 minutes
//             _cache.Set(userId, permissions, TimeSpan.FromMinutes(30));
//             return permissions;
//         }
//     }
// }