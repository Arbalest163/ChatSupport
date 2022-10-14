using ChatSupport.Application.Chats.Commands.SendMessage;
namespace ChatSupport.Application.Chats.Commands.SendMessageByStaff;
public class SendMessageByStaffCommandHandler : IRequestHandler<SendMessageByStaffCommand>
{
    private readonly IChatSupportDbContext _chatSupportDbContext;

    public SendMessageByStaffCommandHandler(IChatSupportDbContext chatSupportDbContext)
    {
        _chatSupportDbContext = chatSupportDbContext;
    }

    public async Task<Unit> Handle(SendMessageByStaffCommand request, CancellationToken cancellationToken)
    {
        var user = await _chatSupportDbContext.Users.FirstAsync(u => u.Id == request.UserId);
        var chat = await _chatSupportDbContext.Chats.FirstAsync(ch => ch.Id == request.ChatId);

        var message = new Message
        {
            Chat = chat,
            User = user,
            DateSendMessage = DateTime.Now,
            Text = request.Message
        };

        await _chatSupportDbContext.Messages.AddAsync(message);
        await _chatSupportDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
