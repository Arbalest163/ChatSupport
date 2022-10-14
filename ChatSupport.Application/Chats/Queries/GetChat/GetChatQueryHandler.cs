using System.Data;

namespace ChatSupport.Application.Chats.Queries.GetChat;
public class GetChatQueryHandler : IRequestHandler<GetChatQuery, ChatVm>
{
    private readonly IChatSupportDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetChatQueryHandler(IChatSupportDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ChatVm> Handle(GetChatQuery request, CancellationToken cancellationToken)
    {
        var chat = await _dbContext.Chats.FirstOrDefaultAsync(x => x.Id == request.ChatId && x.User.Id == request.UserId);
        await _dbContext.Messages.Include(x => x.User).Where(x => x.Chat.Id == request.ChatId).ToArrayAsync(cancellationToken);

        if(chat == null)
        {
            throw new Exception("Попытка доступа к чужому или несуществующему чату!");
        }
        return _mapper.Map<ChatVm>(chat);
    }
}
