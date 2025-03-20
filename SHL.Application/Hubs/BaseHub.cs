using Microsoft.AspNetCore.SignalR;

namespace InventoryManagement.Application.Hubs;

public class BaseHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);
        return base.OnConnectedAsync();
    }


/// <summary>
/// THIS SAVES A USER CONNECTION ID AGAINST HIS USERID
/// ::-  THIS MAKES IT EASIER TO CONNECT TO A PARTICULAR USER FROM ANYWHERE USING  THE GROUP
/// </summary>
/// <param name="UserId"></param>
/// <returns></returns>
    public async Task ConnectUser(Guid UserId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, UserId.ToString());
    }
}
