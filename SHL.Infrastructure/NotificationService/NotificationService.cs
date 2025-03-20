// using InventoryManagement.Application.INotification;
// using Microsoft.AspNetCore.SignalR;
// using static InventoryManagement.Application.Hubs.ChatHub;

// namespace InventoryManagement.Infrastructure.NotificationService
// {
//     public class NotificationService : INotificationService
//     {
//         private readonly IHubContext<NotificationHub> _hubContext;

//         public NotificationService(IHubContext<NotificationHub> hubContext)
//         {
//             _hubContext = hubContext;
//         }

//         public async Task SendOrderInformationToSeller(OrderNotificationToSellerDto dto)
//         {
//             string sellerIdString = dto.SellerId.ToString();
//             await _hubContext.Clients.Group(sellerIdString).SendAsync("ReceiveOrderInformation", dto);
//         }
//         public async Task SendMessageToAllAsync(string user, string message)
//         {
//             await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
//         }
//     }
// }
