namespace ChatSupport.Application.Chats.Commands.SendMessage;
public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
{
    private readonly IChatSupportDbContext _chatSupportDbContext;

    public SendMessageCommandHandler(IChatSupportDbContext chatSupportDbContext)
    {
        _chatSupportDbContext = chatSupportDbContext;
    }

    public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var user = await _chatSupportDbContext.Users.FirstAsync(u => u.Id == request.UserId);
        var chat = await _chatSupportDbContext.Chats.FirstOrDefaultAsync(ch => ch.Id == request.ChatId && ch.User.Id == request.UserId);

        if(chat == null)
        {
            throw new Exception("Ошибка доступа!");
        }

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
