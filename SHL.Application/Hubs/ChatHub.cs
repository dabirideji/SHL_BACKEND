using SHL.Application.Interfaces.GenericRepositoryPattern;

namespace InventoryManagement.Application.Hubs;

public class ChatHub:BaseHub
{
    private readonly IUnitOfWork _unit;
    public ChatHub(IUnitOfWork unit)
    {
        _unit = unit;
    }

    ///this is for chars
    ///THE USER SHOULD BE ABLE TO SEE WHEN ONLINE 
    ///SEE LAST SEEN  .
    ///SEE TYPING , BETWEEN EACH  CHATS AND USERS 
    /// LOADS ALL CHATS  AND CONNECTS THE USER TO ALL CHATS
    /// 


public async Task ConnectUserToGroup(Guid UserId)
{
    // var allChats = await _unit.Chats.GetAll();
    // var userChats = allChats.Where(x => x.UserIdOne == UserId || x.UserIdTwo == UserId).ToList();
    
    // foreach(var chat in userChats)
    // {
    //     await Groups.AddToGroupAsync(Context.ConnectionId, chat.ChatId.ToString());
    // }

    // // Consider using logging instead of Console.WriteLine if this is a web application
    // Console.WriteLine(UserId);
}


    public class NotificationHub : ChatHub

    {
        public NotificationHub(IUnitOfWork unit) : base(unit)
        {
        }
    }

}
