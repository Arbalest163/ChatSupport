namespace ChatSupport.Application.Chats.Commands.CreateChat;
public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, int>
{
    private readonly IChatSupportDbContext _chatSupportDbContext;

    public CreateChatCommandHandler(IChatSupportDbContext chatSupportDbContext)
    {
        _chatSupportDbContext = chatSupportDbContext;
    }

    public async Task<int> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var user = await _chatSupportDbContext.Users.FirstAsync(u => u.Id == request.UserId);

        var chat = new Chat
        {
            Title = request.Title,
            User = user,
            DateCreateChat = DateTime.UtcNow,
        };

        await _chatSupportDbContext.Chats.AddAsync(chat);
        await _chatSupportDbContext.SaveChangesAsync(cancellationToken);
        return chat.Id;
    }
}
