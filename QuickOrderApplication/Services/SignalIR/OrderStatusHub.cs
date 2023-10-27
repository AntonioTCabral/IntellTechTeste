using Microsoft.AspNetCore.SignalR;
using QuickOrderApplication.DTOs;

namespace QuickOrderApplication.Services.SignalIR;

public class OrderStatusHub : Hub
{
    public async Task JoinGroup(Guid orderId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, orderId.ToString());
    }
}